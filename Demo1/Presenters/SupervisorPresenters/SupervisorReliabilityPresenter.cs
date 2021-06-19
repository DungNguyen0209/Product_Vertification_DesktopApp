
using ProductVertificationDesktopApp.IView;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.SupervisorPresenters
{
    public class SupervisorReliabilityPresenter
    {
        private readonly IViewSupervisorReliability _viewSupervisorReliability;
        private readonly ISupervisor _supervisor;
        public SupervisorReliabilityPresenter(IViewSupervisorReliability viewSupervisorReliability, ISupervisor supervisor)
        {
            _viewSupervisorReliability = viewSupervisorReliability;
            _supervisor = supervisor;
            _viewSupervisorReliability.Starting += SendStatusRun;
            _viewSupervisorReliability.Stopping += SendStatusStop;
            _supervisor.UpdateData+=Update;
           

        }
        private void SendStatusRun(object sender, EventArgs args)
        {
            _supervisor.SendStatus("start");
        }
        private void SendStatusStop(object sender, EventArgs args)
        {
            _supervisor.SendStatus("stop");
        }

        private void Update(object sender, bool data)
        {
            _viewSupervisorReliability.TimeClose = _supervisor.TimeStop;
            _viewSupervisorReliability.TimeStart = _supervisor.TimeStart;
            _viewSupervisorReliability.TimeCount = _supervisor.TimeCount;
            _viewSupervisorReliability.TimeCurrent = _supervisor.TimeCurrent;
            if(_supervisor.Run == true )
            {
                _viewSupervisorReliability.SupervisorStatusRun = true;
            }
            if (_supervisor.Run == false)
            {
                _viewSupervisorReliability.SupervisorStatusRun = false;
            }
            if(_supervisor.Warn == true)
            {
                _viewSupervisorReliability.SupervisorStatusWarn = true;
            }
            if(_supervisor.Warn == false)
            {
                _viewSupervisorReliability.SupervisorStatusWarn = false;
            }
        }
    }
}
