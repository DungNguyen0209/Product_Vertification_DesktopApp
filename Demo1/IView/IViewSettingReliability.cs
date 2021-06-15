
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.IView
{
    public interface IViewSettingReliability
    {
        Int16 TimeClose { get; set; }
        Int16 TimeStart { get; set; }
        Int32 TimeNumber { get; set; }
        event EventHandler Confirm;
        Task<bool> UpdateSetting(string Stop, string Start, string Time);
    }
}
