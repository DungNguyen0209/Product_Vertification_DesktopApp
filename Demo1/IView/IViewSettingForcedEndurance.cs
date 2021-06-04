using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.IView
{
    public interface IViewSettingForcedEndurance
    {
        Int16 TimeStopUp { get; set; }
        Int16 TimeStopDown { get; set; }
        Int32 TimeNumber { get; set; }
        event EventHandler Confirm;
    }
}
