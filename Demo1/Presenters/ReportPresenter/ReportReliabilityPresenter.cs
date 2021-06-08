using AutoMapper;
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Models;
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
        public ReportReliabilityPresenter(IViewReportRiliability viewReportRiliability, ISupervisor supervisor, IDatabaseService databaseService, IMapper mapper, IExcel excel)
        {
            _mapper = mapper;
            _viewReportRiliability = viewReportRiliability;
            _supervisor = supervisor;
            _databaseService = databaseService;
            _excel = excel;
            _supervisor.UpdateData += UpdateDataBase;
            _viewReportRiliability.Insert += Insertdata;
        }
        private void UpdateDataBase(object sender, int[] temp)
        {
            Update(true);
        }
        private async Task Update(bool a)
        {
            var clear = await _databaseService.ClearConfiguration();

            var data = new TestingConfigurations
            {
                TestName = "TEST ĐÓNG ÊM NBC",
                TimeHoldingCloseSP = (Int16)_supervisor.TimeCloseSP,
                TimeHoldingOpenSP = (Int16)_supervisor.TimeOpenSP,
                NumberClosingSetting = _supervisor.NumberCloseSP,
                NumberClosingCurrent = _supervisor.TimeCurrent
            };
            var serviceRespone = await _databaseService.InsertTestingConfigurations(data);
        }
        private void Insertdata(object sender, EventArgs e)
        {
            InsertTable(true);
        }
        private async Task InsertTable( bool temp)
        {
            var ListtestingMachine = new List<TestingMachine>();
            foreach (var item in _viewReportRiliability.Report)
            {
                TestingMachine testingMachine = new TestingMachine();
                testingMachine = _mapper.Map<ReportViewModel, TestingMachine>(item);
                testingMachine.Target = Convert.ToString(_viewReportRiliability.eTargetTest);
                var a = (EUnit)0;
                testingMachine.EUnit = Convert.ToString(a);
                testingMachine.TimeStamp = DateTime.Now;
               // var error= await _databaseService.InsertTestingMachines(testingMachine);
                ListtestingMachine.Add(testingMachine);
            }
            var success = await _excel.Exportdata("ImportData.xlsx", ListtestingMachine);
            if(success.Success==true)
            {
                _viewReportRiliability.SuccessExcel("Tải thành công");
            }    
            else
            {
                _viewReportRiliability.SuccessExcel("Lỗi");
            }    
        }
    }
}
