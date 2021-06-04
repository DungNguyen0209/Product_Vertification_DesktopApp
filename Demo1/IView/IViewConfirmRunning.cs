using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.IView
{
    public interface IViewConfirmRunning
    {
        event EventHandler CancelAction;

        event EventHandler ConfirmAction;
        List<Action<bool>> Confirm { get; set; }
        // 1 :1,2:2,3:12,4:00
        int SelectMode { get; set; }
    }
}
