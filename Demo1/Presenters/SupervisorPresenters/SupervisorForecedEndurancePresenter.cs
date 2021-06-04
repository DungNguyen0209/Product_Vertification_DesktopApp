using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SupervisorPresenters
{
    public class SupervisorForecedEndurancePresenter
    {
        private readonly IViewSupervisorForcedEndurance _viewSupervisorForecedEndurance;
        private readonly ISupervisor _supervisor;

        public SupervisorForecedEndurancePresenter(IViewSupervisorForcedEndurance viewSupervisorReliability, ISupervisor supervisor)
        {
            _viewSupervisorForecedEndurance = viewSupervisorReliability;
            _supervisor = supervisor;
            _viewSupervisorForecedEndurance.Starting += SendStatusRun;
            _viewSupervisorForecedEndurance.Stopping += SendStatusStop;
            _supervisor.UpdateData.Add(Update);
        }

        private void SendStatusRun(object sender, EventArgs args)
        {
            _supervisor.SendStatus("start");
        }
        private void SendStatusStop(object sender, EventArgs args)
        {
            _supervisor.SendStatus("stop");
        }

        private void Update(bool data)
        {
            _viewSupervisorForecedEndurance.TimeClose = _supervisor.TimeStop;
            _viewSupervisorForecedEndurance.TimeStart = _supervisor.TimeStart;
            _viewSupervisorForecedEndurance.TimeCount = _supervisor.TimeCount;
            _viewSupervisorForecedEndurance.TimeCurrent = _supervisor.TimeCurrent;
            if (_supervisor.Run == true)
            {
                _viewSupervisorForecedEndurance.SupervisorStatusRun = true;
            }
            if (_supervisor.Run == false)
            {
                _viewSupervisorForecedEndurance.SupervisorStatusRun = false;
            }
            if (_supervisor.Warn == true)
            {
                _viewSupervisorForecedEndurance.SupervisorStatusWarn = true;
            }
            if (_supervisor.Warn == false)
            {
                _viewSupervisorForecedEndurance.SupervisorStatusWarn = false;
            }
        }
    }
}
