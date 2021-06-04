using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.IView
{
    public interface IViewSettingDeformationParam
    {
        Single CompressionForceSettingsystem12 { get; set; }
        Single CompressionForceSettingsystem3 { get; set; }
        int TimeOccupying12 { get; set; }
        int TimeOccuping3 { get; set; }
        Int16 NumberClick12 { get; set; }
        Int16 NumberClick3 { get; set; }
        event EventHandler ConfirmSettingSystem1;
        event EventHandler ConfirmSettingSystem2;


    }
}
