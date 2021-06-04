using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SettingPresenter.SettingDeformationParam
{
    class SettingDeformationParamPresenter
    {
        IViewSettingDeformationParam _viewSettingDeformationParam;
        Is71200ModellingMachine _is71200ModellingMachine;

        public SettingDeformationParamPresenter(IViewSettingDeformationParam viewSettingDeformationParam, Is71200ModellingMachine is71200ModellingMachine)
        {
            _viewSettingDeformationParam = viewSettingDeformationParam;
            _is71200ModellingMachine = is71200ModellingMachine;
            _viewSettingDeformationParam.ConfirmSettingSystem1 += ConfirmSettingSystem1;
            _viewSettingDeformationParam.ConfirmSettingSystem2 += ConfirmSettingSystem2;

        }
        private void ConfirmSettingSystem1(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SendataReal(_viewSettingDeformationParam.CompressionForceSettingsystem12, 2);
            _is71200ModellingMachine.SendTime(_viewSettingDeformationParam.TimeOccupying12, 14);
            _is71200ModellingMachine.SendataUint(_viewSettingDeformationParam.NumberClick12, 10);
            
        }

        private void ConfirmSettingSystem2(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SendataReal(_viewSettingDeformationParam.CompressionForceSettingsystem3, 6);
            _is71200ModellingMachine.SendTime(_viewSettingDeformationParam.TimeOccuping3, 18);
            _is71200ModellingMachine.SendataUint(_viewSettingDeformationParam.NumberClick3, 12);
            
        }

    }
}
