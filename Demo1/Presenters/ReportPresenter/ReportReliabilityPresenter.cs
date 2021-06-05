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
        public ReportReliabilityPresenter(IViewReportRiliability viewReportRiliability, ISupervisor supervisor, IDatabaseService databaseService, IMapper mapper)
        {
            _mapper = mapper;
            _viewReportRiliability = viewReportRiliability;
            _supervisor = supervisor;
            _databaseService = databaseService;
            _supervisor.UpdateData.Add(UpdateDataBase);
            _viewReportRiliability.Insert += Insertdata;
        }
        private void UpdateDataBase (bool temp)
        {
            var data = new TestingConfigurations
            {
                TestID = "Bài TEST ĐÓNG ÊM NBC",
                TimeHoldingCloseSP = (Int16)_supervisor.TimeCloseSP,
                TimeHoldingOpenSP = (Int16)_supervisor.TimeOpenSP,
                NumberClosingSetting = _supervisor.NumberCloseSP,
                NumberClosingCurrent = _supervisor.TimeCurrent
            };
            _databaseService.InsertTestingConfigurations(data);
            if(_supervisor.TimeCurrent % 5000 == 0)
            {
                var Report = new ReportViewModel();
                Report.NumberTesting= Convert.ToString(_supervisor.TimeCurrent);
                _viewReportRiliability.Report.Add(Report);
            }    
        }
        private void Insertdata(object sender, EventArgs e)
        {
            TestingMachine testingMachine = new TestingMachine();
            testingMachine.TimeStamp = DateTime.Now;
            testingMachine.EUnit = (EUnit)0;
            testingMachine.Target = _viewReportRiliability.eTargetTest;
            foreach (var item in _viewReportRiliability.Report)
            {
                testingMachine = _mapper.Map<ReportViewModel, TestingMachine>(item);
               // _databaseService.InsertTestingMachines(testingMachine);
            }    
        }
    }
}
