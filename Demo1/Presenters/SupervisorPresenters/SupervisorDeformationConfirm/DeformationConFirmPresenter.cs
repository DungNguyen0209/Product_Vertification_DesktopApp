using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SupervisorPresenters.SupervisorDeformationConfirm
{
    class DeformationConFirmPresenter
    {
        IViewConfirmRunning _viewConfirmRunning;
        Is71200ModellingMachine _is71200ModellingMachine;

        public DeformationConFirmPresenter(IViewConfirmRunning viewConfirmRunning, Is71200ModellingMachine is71200ModellingMachine)
        {
            _viewConfirmRunning = viewConfirmRunning;
            _is71200ModellingMachine = is71200ModellingMachine;
            _viewConfirmRunning.ConfirmAction += Confirm;
            _viewConfirmRunning.CancelAction += Cancel;
        }

        private void Confirm(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SendStatus("confirm");
        }

        private void Cancel(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SendStatus("cancel");
        }
    }
}
