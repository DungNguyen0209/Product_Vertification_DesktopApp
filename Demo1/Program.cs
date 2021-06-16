
using ProductVertificationDesktopApp.Service;
using ProductVertificationDesktopApp.Service.Interfaces;
using ProductVertificationDesktopApp.Presenters.SettingPresenter;
using ProductVertificationDesktopApp.Views;
using ProductVertificationDesktopApp.Views.BaoCaoView.BaoCaoMKTDoBienDangView;
using ProductVertificationDesktopApp.Views.BaoCaoViews;
using ProductVertificationDesktopApp.Views.Implements.BaoCaoView;
using ProductVertificationDesktopApp.Views.Implements.CaiDatView;
using ProductVertificationDesktopApp.Views.Implements.CanhBaoView;
using ProductVertificationDesktopApp.Views.Implements.DangNhapView;
using ProductVertificationDesktopApp.Views.Implements.GiamSatView;
using ProductVertificationDesktopApp.Views.Implements.LichSuView;
using ProductVertificationDesktopApp.Views.Implements.TroGiupView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductVertificationDesktopApp.Presenters.SupervisorPresenters;
using ProductVertificationDesktopApp.Presenters.SupervisorPresenters.SupervisorParamPresenter;
using ProductVertificationDesktopApp.Presenters.SettingPresenter.SettingDeformationParam;
using ProductVertificationDesktopApp.Views.Implements.CaidatView.Dobiendang;
using ProductVertificationDesktopApp.Presenters.SupervisorPresenters.SupervisorDeformationConfirm;
using ProductVertificationDesktopApp.Persistence.Contexts;
using ProductVertificationDesktopApp.Persistence;
using ProductVertificationDesktopApp.Persistence.Repositories;
using AutoMapper;
using ProductVertificationDesktopApp.Mapping;
using ProductVertificationDesktopApp.Presenters.ReportPresenter;
using OfficeOpenXml;
using ProductVertificationDesktopApp.Presenters.LoginPresenter;

namespace ProductVertificationDesktopApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //View Confirm Setting in Deformation
            ViewConfirmSetting viewConfirmSetting1 = new ViewConfirmSetting();
            ViewConfirmSetting viewConfirmSetting2 = new ViewConfirmSetting();
            ViewConfirmSetting viewConfirmSetting3 = new ViewConfirmSetting();
            ViewConfirmSetting viewConfirmSetting4 = new ViewConfirmSetting();
            ViewConfirmSetting viewConfirmSetting5 = new ViewConfirmSetting();

            Caidatthongso caidattaptrung = new Caidatthongso(viewConfirmSetting1);
            Caidatthongso caidatthongso1 = new Caidatthongso(viewConfirmSetting2);
            Caidatthongso caidatthongso2 = new Caidatthongso(viewConfirmSetting3);
            Caidatthongso caidatthongso3 = new Caidatthongso(viewConfirmSetting4);
            Caidatthongso khac = new Caidatthongso(viewConfirmSetting5);
            Form_Caidat_Doben form_Caidat_Doben = new Form_Caidat_Doben();
            Form_Caidat_Dobencuongbuc form_Caidat_Dobencuongbuc = new Form_Caidat_Dobencuongbuc();
            Form_Caidat_Dobiendang form_Caidat_Dobiendang = new Form_Caidat_Dobiendang(caidattaptrung, caidatthongso1, caidatthongso2, caidatthongso3, khac);

            Form_ConFirmRunning form_ConFirmRunning = new Form_ConFirmRunning();
            Form_ConFirmRunning form_ConFirmStopping = new Form_ConFirmRunning();

            GiamSatthongso panelDeformationParameters1 = new GiamSatthongso();
            GiamSatthongso panelDeformationParameters2 = new GiamSatthongso();

            Form_Giamsat_Doben form_Giamsat_Doben = new Form_Giamsat_Doben();
            Form_Giamsat_Dobencuongbuc form_Giamsat_Dobencuongbuc = new Form_Giamsat_Dobencuongbuc();
            Form_Giamsat_Dobiendang form_Giamsat_Dobiendang = new Form_Giamsat_Dobiendang(panelDeformationParameters1,panelDeformationParameters2, form_ConFirmRunning, form_ConFirmStopping);

            Form_Lichsu_Doben form_Lichsu_Doben = new Form_Lichsu_Doben();
            Form_Lichsu_Dobencuongbuc form_Lichsu_Dobencuongbuc = new Form_Lichsu_Dobencuongbuc();
            Form_Lichsu_Dobiendang form_Lichsu_Dobiendang = new Form_Lichsu_Dobiendang();

            Form_Canhbao_Doben form_Canhbao_Doben = new Form_Canhbao_Doben();
            Form_Canhbao_Dobencuongbuc form_Canhbao_Dobencuongbuc = new Form_Canhbao_Dobencuongbuc();
            Form_Canhbao_Dobiendang form_Canhbao_Dobiendang = new Form_Canhbao_Dobiendang();

            Form_Baocao_Chiulucuon form_Baocao_Chiulucuon = new Form_Baocao_Chiulucuon();
            Form_Baocao_Chiuvadap form_Baocao_Chiuvadap = new Form_Baocao_Chiuvadap();
            Form_Baocao_Rocktest form_Baocao_Rocktest = new Form_Baocao_Rocktest();
            Form_Baocao_Doben form_Baocao_Doben = new Form_Baocao_Doben();
            Form_Baocao_Dobencuongbuc form_Baocao_Dobencuongbuc = new Form_Baocao_Dobencuongbuc();
            Form_Baocao_Dobiendang form_Baocao_Dobiendang = new Form_Baocao_Dobiendang(form_Baocao_Chiulucuon, form_Baocao_Chiuvadap, form_Baocao_Rocktest);

            CaiDatView formCaidat = new CaiDatView(form_Caidat_Doben,form_Caidat_Dobencuongbuc,form_Caidat_Dobiendang,caidattaptrung,caidatthongso1,caidatthongso2,caidatthongso3,khac);
            DangNhapView formDangnhap = new DangNhapView();
            CanhBaoView formCanhbao = new CanhBaoView(form_Canhbao_Doben,form_Canhbao_Dobencuongbuc,form_Canhbao_Dobiendang);
            BaoCaoView formBaocao = new BaoCaoView(form_Baocao_Doben,form_Baocao_Dobencuongbuc,form_Baocao_Dobiendang,form_Baocao_Chiulucuon,form_Baocao_Chiuvadap,form_Baocao_Rocktest);
            TroGiupView formTrogiup = new TroGiupView();
            LichSuView formLichsu = new LichSuView(form_Lichsu_Doben,form_Lichsu_Dobencuongbuc,form_Lichsu_Dobiendang);
            GiamSatView formGiamsat = new GiamSatView(form_Giamsat_Doben,form_Giamsat_Dobencuongbuc,form_Giamsat_Dobiendang);

            // Bulid service excel
            var ExcelService = new Excel();

            //Build Service for database
            var context = new ApplicationDbContext();
            var testingConfigurationRepository = new TestingConfigurationRepository(context);
            var testingMachineRepository = new TestingSheetRepository(context);
            var unitOfWorkRepository = new UnitOfWork(context);
            var databaseService = new DatabaseService(unitOfWorkRepository, testingConfigurationRepository, testingMachineRepository);

            //Setting Mapper
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Program));
            });
            var mapper = mappingConfig.CreateMapper();

            //Api Service
            IApiService apiService = new ApiService(mapper);

            //Regular Expression Service 
            IRegularExpression regularExpression = new RegularExpression();

            // Logo Setting For Service
            Logo logo1 = new Logo("10.84.60.17",0);
            Logo logo2 = new Logo("10.84.60.19", 0);

            //S7-1200 setting Service
            S71200 device1 = new S71200(0, "10.84.60.15", 52);
            //Setting logo service
            IModelingMachine modelingMachine2 = new ModelingMachine(logo2);
            IModelingMachine modelingMachine1 = new ModelingMachine(logo1);
            Is71200ModellingMachine is71200ModellingMachine = new S71200ModellingMachines(device1);
            //Warning Setup
            ISupervisor supervisor1 = new Supervisor(logo1);
            ISupervisor supervisor2 = new Supervisor(logo2);

            //Presenter Login 
            LoginPresenter loginPresenter = new LoginPresenter(formDangnhap,apiService);

            //Presenter Setup
            SettingReliabilityPresenter settingReliabilityPresenter = new SettingReliabilityPresenter(form_Caidat_Doben, modelingMachine1);
            SettingForecedEnduracePresenter settingForecedEnduracePresenter = new SettingForecedEnduracePresenter(form_Caidat_Dobencuongbuc, modelingMachine2);

            //Presenter Setup Param in Deformation
            SettingDeformationParamPresenter settingDeformationParamPresenter1 = new SettingDeformationParamPresenter(caidattaptrung, is71200ModellingMachine);
            SettingDeformationParamPresenter settingDeformationParamPresenter2 = new SettingDeformationParamPresenter(caidatthongso1, is71200ModellingMachine);
            SettingDeformationParamPresenter settingDeformationParamPresenter3= new SettingDeformationParamPresenter(caidatthongso2, is71200ModellingMachine);
            SettingDeformationParamPresenter settingDeformationParamPresenter4 = new SettingDeformationParamPresenter(caidatthongso3, is71200ModellingMachine);

            //  supervisorReliabilityPresenter
            SupervisorReliabilityPresenter supervisorReliabilityPresenter1 = new SupervisorReliabilityPresenter(form_Giamsat_Doben,supervisor1);
            SupervisorForecedEndurancePresenter supervisorReliabilityPresenter2 = new SupervisorForecedEndurancePresenter(form_Giamsat_Dobencuongbuc, supervisor2);
            //supervisorDeformationPresenter
            SupervisorDeformationPresenter supervisorDeformationPresenter = new SupervisorDeformationPresenter(form_Giamsat_Dobiendang, is71200ModellingMachine);
            SupervisorDeformationParamPresenter supervisorDeformationParamPresenter = new SupervisorDeformationParamPresenter(panelDeformationParameters1, is71200ModellingMachine);
            SupervisorDeformationParamPVPresenter supervisorDeformationParamPVPresenter = new SupervisorDeformationParamPVPresenter(panelDeformationParameters2,is71200ModellingMachine);

            // Cofirm Setting Deformation Presenter
            ConfirmSettingPresenter deformationConfirmPresenter1 = new ConfirmSettingPresenter(viewConfirmSetting1, is71200ModellingMachine);
            ConfirmSettingPresenter deformationConfirmPresenter2 = new ConfirmSettingPresenter(viewConfirmSetting2, is71200ModellingMachine);
            ConfirmSettingPresenter deformationConfirmPresenter3 = new ConfirmSettingPresenter(viewConfirmSetting3, is71200ModellingMachine);
            ConfirmSettingPresenter deformationConfirmPresenter4 = new ConfirmSettingPresenter(viewConfirmSetting4, is71200ModellingMachine);
            ConfirmSettingPresenter deformationConfirmPresenter5 = new ConfirmSettingPresenter(viewConfirmSetting5, is71200ModellingMachine);

            //DeFormation Supervisor Presner
            DeformationConFirmPresenter deformationConFirmPresenterStart = new DeformationConFirmPresenter(form_ConFirmRunning, is71200ModellingMachine);
            DeformationConFirmPresenter deformationConFirmPresenterStop = new DeformationConFirmPresenter(form_ConFirmStopping, is71200ModellingMachine);

            //Report Preseenter 
            ReportReliabilityPresenter reportReliabilityPresenter = new ReportReliabilityPresenter(form_Baocao_Doben, supervisor1,databaseService,mapper, ExcelService,apiService,regularExpression);
            Application.Run(new MainView(formCaidat, formDangnhap, formCanhbao, formBaocao, formTrogiup, formLichsu, formGiamsat));
        }
    }
}
