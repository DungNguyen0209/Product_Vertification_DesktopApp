using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SupervisorPresenters
{
    public class SupervisorDeformationPresenter
    {
        IViewSupervisorDeformation _viewSupervisorDeformation;
        Is71200ModellingMachine _is71200ModellingMachine;

        public SupervisorDeformationPresenter(IViewSupervisorDeformation viewSupervisorDeformation, Is71200ModellingMachine is71200ModellingMachines)
        {
            _viewSupervisorDeformation = viewSupervisorDeformation;
            this._is71200ModellingMachine = is71200ModellingMachines;
            _is71200ModellingMachine.UpdateData.Add(UpdateView);
            _viewSupervisorDeformation.Start += SendStatusRun;
            _viewSupervisorDeformation.Stop += SendStatusStop;
            _viewSupervisorDeformation.Reset += SendStatusReset;
        }
        private void UpdateView(bool data)
        {
            _viewSupervisorDeformation.StartStatus = _is71200ModellingMachine.Start;
            _viewSupervisorDeformation.ModeStatus = _is71200ModellingMachine.Mode;
            _viewSupervisorDeformation.Warning = _is71200ModellingMachine.Warning;
        }
        private void SendStatusRun(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SendStatus("Start");
        }
        private void SendStatusStop(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SendStatus("Stop");
        }
        private void SendStatusReset(object sender, EventArgs args)
        {
            _is71200ModellingMachine.SendStatus("Reset");
        }
    }
}
