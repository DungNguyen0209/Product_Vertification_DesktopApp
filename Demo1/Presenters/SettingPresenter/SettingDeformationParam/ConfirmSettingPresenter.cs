using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SettingPresenter.SettingDeformationParam
{
    class ConfirmSettingPresenter
    {
        IViewConfirmSetting _viewConfirmRunning;
        Is71200ModellingMachine _is71200ModellingMachine;

        public ConfirmSettingPresenter(IViewConfirmSetting viewConfirmRunning, Is71200ModellingMachine is71200ModellingMachine)
        {
            _viewConfirmRunning = viewConfirmRunning;
            _is71200ModellingMachine = is71200ModellingMachine;
            _viewConfirmRunning.ConfirmAction += Confirm;
            _viewConfirmRunning.CancelAction += Cancel;
        }
        private void Confirm(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SetMemmoryBit(0,7,true,_viewConfirmRunning.SelectMode);
        }

        private void Cancel(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SetMemmoryBit(0, 7, false, _viewConfirmRunning.SelectMode);
        }
    }
}
