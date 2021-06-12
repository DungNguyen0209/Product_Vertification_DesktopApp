using AutoMapper;
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Domain.Models.Resource;
using ProductVertificationDesktopApp.Domain.ViewModel;
using ProductVertificationDesktopApp.Service.Interfaces;
using ProductVertificationDesktopApp.Views.Interface.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.ReportPresenter
{
    public class ReportReliabilityPresenter
    {
        private readonly IViewReportRiliability _viewReportRiliability;
        private readonly ISupervisor _supervisor;
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly IExcel _excel;
        private bool FlagOpen = false;
        public ReportReliabilityPresenter(IViewReportRiliability viewReportRiliability, ISupervisor supervisor, IDatabaseService databaseService, IMapper mapper, IExcel excel)
        {
            _mapper = mapper;
            _viewReportRiliability = viewReportRiliability;
            _supervisor = supervisor;
            _databaseService = databaseService;
            _excel = excel;
            _supervisor.UpdateData += UpdateDataBase;
            _viewReportRiliability.Insert += Insertdata;
            _viewReportRiliability.FormLoad += LoadDatabase;
        }
        private void UpdateDataBase(object sender, int[] temp)
        {
            Update(true);
        }
        public void LoadDatabase(object sender, EventArgs e)
        {
            LoadData(true);
        }
        private async Task LoadData(bool a)
        {
            if (FlagOpen == false)
            {
                FlagOpen = true;
                var dataprevious = await _databaseService.LoadReliability();
                foreach(var previous in dataprevious)
                {
                    var data = _mapper.Map<TestSheet, ReportViewModel>(previous);
                    _viewReportRiliability.Report.Add(data);
                };
            }
        }
        private async Task Update(bool a)
        {
            if (_supervisor.TimeCurrent != 0)
            {
                if (_supervisor.TimeCurrent % 5000 == 0)
                {
                    var test = new ReportViewModel();
                    test.NumberTesting = Convert.ToString(_supervisor.TimeCurrent);
                    _viewReportRiliability.Report.Add(test);
                    foreach (var report in _viewReportRiliability.Report)
                    {
                        var dataCurrent = _mapper.Map<ReportViewModel, TestSheet>(report);
                        await _databaseService.InsertReliability(dataCurrent);

                    }
                }
            }    
            

            /*
            // Update đóng êm lên API
            var data = new TestingConfigurations
            {
                TestName = "TEST ĐÓNG ÊM NBC",
                TimeHoldingCloseSP = (Int16)_supervisor.TimeCloseSP,
                TimeHoldingOpenSP = (Int16)_supervisor.TimeOpenSP,
                NumberClosingSetting = _supervisor.NumberCloseSP,
                NumberClosingCurrent = _supervisor.TimeCurrent
            };
            var serviceRespone = await _databaseService.InsertTestingConfigurations(data);
            */

        }
        private void Insertdata(object sender, EventArgs e)
        {
            InsertTable(true);
        }
        private async Task InsertTable( bool temp)
        {
            _supervisor.UpdateData -= UpdateDataBase;
            var confirm = await _viewReportRiliability.ConfirmExport();
            if (confirm.Error == null)
            {
                var testingMachine = new TestingMachine();
                testingMachine.TestingMachineID = Convert.ToString((EUnit)0);
                testingMachine.Standard = "TC";
                testingMachine.Target = Convert.ToString(_viewReportRiliability.eTargetTest);
                testingMachine.TimeStampStart = _viewReportRiliability.TimeStampStart;
                testingMachine.TimeStampFinish = _viewReportRiliability.TimeStampFinish;
                List<TestSheet> sheets = new List<TestSheet>();
                foreach (var item in _viewReportRiliability.Report)
                {
                    TestSheet testSheet = new TestSheet();
                    testSheet = _mapper.Map<ReportViewModel, TestSheet>(item);
                    sheets.Add(testSheet);
                }
                testingMachine.Testsheet = sheets;
                var success = await _excel.Exportdata("ImportData.xlsx", testingMachine);
                if(success.Error == null)
                {
                    var clear = await _databaseService.ClearReliability();
                    if(clear.Success == true)
                    {
                        _viewReportRiliability.SuccessExcel("Truy xuất thành công ");
                    }
                    else
                    {
                        _viewReportRiliability.SuccessExcel(clear.Error.Message);
                    }    
                }
                else
                {
                    _viewReportRiliability.SuccessExcel(success.Error.Message);
                }
                _supervisor.UpdateData += UpdateDataBase;
            }
        }
    }
}
