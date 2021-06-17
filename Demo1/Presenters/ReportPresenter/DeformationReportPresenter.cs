using AutoMapper;
using ProductVertificationDesktopApp.Domain.API;
using ProductVertificationDesktopApp.Domain.Models.Resource;
using ProductVertificationDesktopApp.Domain.ViewModel;
using ProductVertificationDesktopApp.Interface.Report;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.ReportPresenter
{
    class DeformationReportPresenter
    {
        private readonly IViewReportDeformation _viewReportDeformation;
        private readonly ISupervisor _supervisor;
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly IExcel _excel;
        private readonly IApiService _apiService;
        private readonly IRegularExpression _regularExpression;
        private bool FlagOpen = false;
        private int Countprevious;

        public DeformationReportPresenter(IViewReportDeformation viewReportDeformation, ISupervisor supervisor, IDatabaseService databaseService, IMapper mapper, IExcel excel, IApiService apiService, IRegularExpression regularExpression)
        {
            _viewReportDeformation = viewReportDeformation;
            _supervisor = supervisor;
            _databaseService = databaseService;
            _mapper = mapper;
            _excel = excel;
            _apiService = apiService;
            _regularExpression = regularExpression;
            _supervisor.UpdateData += UpdateDataBase;
            _viewReportDeformation.Insert += Insertdata;
            _viewReportDeformation.FormLoad += LoadForm;
            _viewReportDeformation.FormClose += CloseForm;
            _viewReportDeformation.ImportData += Import;
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
                var dataprevious = await _databaseService.LoadDeformation();
                foreach (var previous in dataprevious)
                {
                    var data = _mapper.Map<DeformationTestSheet, ReportViewModel>(previous);
                    _viewReportDeformation.Report.Add(data);
                };
                var configprevious = await _databaseService.LoadAllDeformationConfiguration();
                _viewReportDeformation.NameProduct = configprevious[0].ProductCode;
                _viewReportDeformation.Comment = configprevious[0].Note;
                _viewReportDeformation.TimeStampFinish = configprevious[0].TimeStampStart;
                _viewReportDeformation.TimeStampFinish = configprevious[0].TimeStampFinish;
                _viewReportDeformation.eTargetTest = configprevious[0].Target;
            }
        }
        private async Task Close(bool a)
        {
            var result = await _databaseService.ClearDeformation();
            foreach (var report in _viewReportDeformation.Report)
            {
                var dataCurrent = _mapper.Map<ReportViewModel, DeformationTestSheet>(report);
                await _databaseService.InsertDeformation(dataCurrent);

            }
            var testingConfigurations = new DeformationTestingConfigurations();
            testingConfigurations.TestingMachineID = Convert.ToString((EUnit)0);
            testingConfigurations.Target = Convert.ToInt32(_viewReportDeformation.eTargetTest);
            testingConfigurations.ProductCode = _viewReportDeformation.NameProduct;
            testingConfigurations.Note = _viewReportDeformation.Comment;
            testingConfigurations.TimeStampStart = _viewReportDeformation.TimeStampStart;
            testingConfigurations.TimeStampFinish = _viewReportDeformation.TimeStampFinish;
            await _databaseService.ClearDeformationConfiguration();
            await _databaseService.InsertDeformationTestingConfigurations(testingConfigurations);
        }
        private async Task Update(bool a)
        {
            if (_supervisor.TimeCurrent != 0)
            {
                if ((_supervisor.TimeCurrent % 5000 == 0) && (_supervisor.TimeCurrent != Countprevious))
                {
                    Countprevious = _supervisor.TimeCurrent;
                    var test = new ReportViewModel();
                    test.NumberTesting = Convert.ToString(_supervisor.TimeCurrent);
                    _viewReportDeformation.Report.Add(test);
                }
            }
            var apisupervisor = new ApiSupervisor
            {
                NumberClosingSp = _supervisor.NumberCloseSP,
                NumberClosingPv = _supervisor.TimeCurrent,
                TimeLidClose = _supervisor.TimeCloseSP,
                TimeLidOpen = _supervisor.TimeOpenSP,
                Running = _supervisor.Run,
                Warning = _supervisor.Warn
            };
            var g = await _apiService.PostReportSupervisor(apisupervisor, "deformation");
        }
        private void Insertdata(object sender, EventArgs e)
        {
            InsertAPI(true);
        }
        private async Task InsertAPI(bool temp)
        {
            _supervisor.UpdateData -= UpdateDataBase;
            var confirm = await _viewReportDeformation.ConfirmExport();
            if (confirm.Error == null)
            {
                var testingMachine = new TestingMachine();
                testingMachine.TestingMachineID = Convert.ToString((EUnit)0);
                testingMachine.Standard = "TC";
                testingMachine.Note = _viewReportDeformation.Comment;
                testingMachine.ProductId = _viewReportDeformation.NameProduct.ToLower();
                testingMachine.Target = Convert.ToString((ETargetTest)_viewReportDeformation.eTargetTest);
                testingMachine.StartTime = _viewReportDeformation.TimeStampStart;
                testingMachine.StopTime = _viewReportDeformation.TimeStampFinish;
                List<TestSheet> sheets = new List<TestSheet>();
                foreach (var item in _viewReportDeformation.Report)
                {
                    TestSheet testSheet = new TestSheet();
                    testSheet = _mapper.Map<ReportViewModel, TestSheet>(item);
                    sheets.Add(testSheet);
                }
                testingMachine.Testsheet = sheets;
                var success = await _excel.Exportdata("DeformationTest.xlsx", testingMachine);
                if (success.Error == null)
                {
                    var clear = await _databaseService.ClearDeformation();
                    if (clear.Success == true)
                    {
                        var ApiReport = _mapper.Map<TestingMachine, DeformationApiReport>(testingMachine);
                        ApiReport.Target = testingMachine.Target + ":" + testingMachine.Note;
                        var result = await _apiService.PostDeformationReport(ApiReport);
                        if (result.Success == true)
                        {
                            _viewReportDeformation.Report.Clear();
                            await _databaseService.ClearReliabilityConfiguration();
                            _viewReportDeformation.SuccessExcel("Truy xuất thành công ");
                        }
                        else
                        {
                            _viewReportDeformation.SuccessExcel(result.Error.Message);
                        }
                    }
                    else
                    {
                        _viewReportDeformation.SuccessExcel(clear.Error.Message);
                    }
                }
                else
                {
                    _viewReportDeformation.SuccessExcel(success.Error.Message);
                }
                _supervisor.UpdateData += UpdateDataBase;
            }
        }
        private async Task Importdata(bool a)
        {
            var timestart = _viewReportDeformation.TimeStampStart.AddDays(-1);
            var timestop = _viewReportDeformation.TimeStampFinish.AddDays(+1);
            var result = await _apiService.GetDeformationReport(timestart, timestop);
            if (result.Success == true)
            {
                try
                {
                    var data = result.Resource.Items.Last();
                    var import = _mapper.Map<DeformationApiReport, TestingMachine>(data);
                    foreach (var items in import.Testsheet)
                    {
                        var importdata = _mapper.Map<TestSheet, ReportViewModel>(items);
                        _viewReportDeformation.Report.Add(importdata);
                    }
                    var targetandnote = _regularExpression.RegularExpression1(data.Target);
                    _viewReportDeformation.Comment = targetandnote[1];
                    _viewReportDeformation.eTargetTest = Target(targetandnote[0]);
                    _viewReportDeformation.NameProduct = data.ProductId;
                    _viewReportDeformation.TimeStampStart = data.StartTime;
                    _viewReportDeformation.TimeStampFinish = data.StopTime;
                    _viewReportDeformation.SuccessExcel("Truy xuất thành công ");
                }    
                catch
                {
                    _viewReportDeformation.SuccessExcel("Không có dữ liệu trong thời gian này");
                }
            }
        }

        private int Target(string s)
        {
            if (s == Convert.ToString((ETargetTest)0))
            {
                return 0;
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
