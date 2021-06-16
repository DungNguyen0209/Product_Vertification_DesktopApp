using AutoMapper;
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.API;
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
        private readonly IApiService _apiService;
        private readonly IRegularExpression _regularExpression;
        private bool FlagOpen = false;
        private int Countprevious;
        public ReportReliabilityPresenter(IViewReportRiliability viewReportRiliability, ISupervisor supervisor, IDatabaseService databaseService, IMapper mapper, IExcel excel, IApiService apiService,IRegularExpression regularExpression)
        {
            _mapper = mapper;
            _viewReportRiliability = viewReportRiliability;
            _supervisor = supervisor;
            _databaseService = databaseService;
            _excel = excel;
            _apiService = apiService;
            _regularExpression = regularExpression;
            _supervisor.UpdateData += UpdateDataBase;
            _viewReportRiliability.Insert += Insertdata;
            _viewReportRiliability.FormLoad += LoadForm;
            _viewReportRiliability.FormClose += CloseForm;
            _viewReportRiliability.ImportData += Import;
        }
        private void UpdateDataBase(object sender, int[] temp)
        {
            Update(true);
        }
        private void LoadForm(object sender, EventArgs e)
        {
            LoadData(true);
        }
        private void CloseForm(object sender, EventArgs e)
        {
            Close(true);
        }
        private void Import(object sender, EventArgs e)
        {
            Importdata(true);
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
                var configprevious = await _databaseService.LoadAllConfiguration();
                _viewReportRiliability.NameProduct = configprevious[0].ProductCode;
                _viewReportRiliability.Comment = configprevious[0].Note;
                _viewReportRiliability.TimeStampFinish = configprevious[0].TimeStampStart;
                _viewReportRiliability.TimeStampFinish = configprevious[0].TimeStampFinish;
                _viewReportRiliability.eTargetTest = configprevious[0].Target;
            }
        }
        private async Task Close(bool a)
        {
            var result = await _databaseService.ClearReliability();
            foreach (var report in _viewReportRiliability.Report)
            {
                var dataCurrent = _mapper.Map<ReportViewModel, TestSheet>(report);
                await _databaseService.InsertReliability(dataCurrent);

            }
            var testingConfigurations = new TestingConfigurations();
            testingConfigurations.TestingMachineID = Convert.ToString((EUnit)0);
            testingConfigurations.Target = Convert.ToInt32(_viewReportRiliability.eTargetTest);
            testingConfigurations.ProductCode = _viewReportRiliability.NameProduct;
            testingConfigurations.Note = _viewReportRiliability.Comment;
            testingConfigurations.TimeStampStart = _viewReportRiliability.TimeStampStart;
            testingConfigurations.TimeStampFinish = _viewReportRiliability.TimeStampFinish;
            await _databaseService.ClearConfiguration();
            await _databaseService.InsertTestingConfigurations(testingConfigurations);
        }
        private async Task Update(bool a)
        {
            if (_supervisor.TimeCurrent != 0)
            {
                if ((_supervisor.TimeCurrent % 5000 == 0)&&(_supervisor.TimeCurrent != Countprevious))
                {
                    Countprevious = _supervisor.TimeCurrent;
                    var test = new ReportViewModel();
                    test.NumberTesting = Convert.ToString(_supervisor.TimeCurrent);
                    _viewReportRiliability.Report.Add(test);
                }
            }
            var apisupervisor = new ApiSupervisorReliability
            {
                NumberClosingSp = _supervisor.NumberCloseSP,
                NumberClosingPv = _supervisor.TimeCurrent,
                TimeLidClose = _supervisor.TimeCloseSP,
                TimeLidOpen = _supervisor.TimeOpenSP,
                Running = _supervisor.Run,
                Warning =_supervisor.Warn
            };
            await _apiService.PostReportSupervisorRiliability(apisupervisor);
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
                testingMachine.Note = _viewReportRiliability.Comment;
                testingMachine.ProductId = _viewReportRiliability.NameProduct;
                testingMachine.Target = Convert.ToString((ETargetTest)_viewReportRiliability.eTargetTest);
                testingMachine.StartTime = _viewReportRiliability.TimeStampStart;
                testingMachine.StopTime = _viewReportRiliability.TimeStampFinish;
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
                        var ApiReport = _mapper.Map<TestingMachine, ApiReportRiliability>(testingMachine);
                        ApiReport.Target = testingMachine.Target + ":" + testingMachine.Note;
                        var result = await _apiService.PostReportRiliability(ApiReport);
                        if(result.Success == true)
                        {
                            _viewReportRiliability.Report.Clear();
                            await _databaseService.ClearConfiguration();
                            _viewReportRiliability.SuccessExcel("Truy xuất thành công ");
                        }    
                        else
                        {
                            _viewReportRiliability.SuccessExcel(result.Error.Message);
                        }    
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
        private async Task Importdata(bool a)
        {
            var timestart = _viewReportRiliability.TimeStampStart.AddDays(-1);
            var timestop = _viewReportRiliability.TimeStampFinish.AddDays(+1);
            var result = await _apiService.GetReportRiliability(timestart, timestop);
            if (result.Success == true)
            {
                var data = result.Resource.Items.First();
                var import = _mapper.Map<ApiReportRiliability, TestingMachine>(data);    
                    foreach (var items in import.Testsheet)
                {
                    var importdata = _mapper.Map<TestSheet, ReportViewModel>(items);
                    _viewReportRiliability.Report.Add(importdata);
                }
                var targetandnote = _regularExpression.RegularExpression1(data.Target);
                _viewReportRiliability.Comment = targetandnote[0];
                _viewReportRiliability.eTargetTest = Target(targetandnote[1]);
                _viewReportRiliability.NameProduct = data.ProductId;
                _viewReportRiliability.TimeStampStart = data.StartTime;
                _viewReportRiliability.TimeStampFinish = data.StopTime;
                _viewReportRiliability.SuccessExcel("Truy xuất thành công ");
            }
        }

        private int Target(string s)
        {
            if(s == Convert.ToString((ETargetTest)0))
            {
                return  0;
            }
            if (s == Convert.ToString((ETargetTest)1))
            {
                return 1;
            }
            if (s == Convert.ToString((ETargetTest)2))
            {
                return 2;
            }
            else
            {
                return 3;
            }

        }
    }
}
