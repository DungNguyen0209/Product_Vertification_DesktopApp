using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.IView
{
    public interface IViewConfirmSetting
    {
        event EventHandler CancelAction;

        event EventHandler ConfirmAction;
        List<Action<bool>> Confirm { get; set; }
        int SelectMode { get; set; }
    }
}
