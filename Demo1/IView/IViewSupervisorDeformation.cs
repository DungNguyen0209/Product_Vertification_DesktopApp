using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.IView
{
    public interface IViewSupervisorDeformation
    {
        event EventHandler Start;
        event EventHandler Stop;
        event EventHandler Reset;

        bool StartStatus { set; }
        bool ModeStatus { set; }
        bool Warning { set; }
    }
}
