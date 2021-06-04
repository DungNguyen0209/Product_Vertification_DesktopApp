
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.IView
{
    public interface IViewSupervisorForcedEndurance
    {
        bool SupervisorStatusRun { set; }

        bool SupervisorStatusWarn { set; }
        int TimeClose { get; set; }
        int TimeStart { get; set; }
        int TimeCount { get; set; }
        int TimeCurrent { get; set; }
        event EventHandler Starting;
        event EventHandler Stopping;
    }
}
