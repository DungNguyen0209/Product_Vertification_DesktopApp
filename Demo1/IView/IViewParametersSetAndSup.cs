using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.IView
{
    public interface IViewParametersSetAndSup
    {
        int CompressionForceSettingsystem1 { get; set; }
        int CompressionForceSettingsystem2 { get; set; }
        int CompressionForceSettingsystem3 { get; set; }
        int TimeOccupying1 { get; set; }
        int TimeOccupying2 { get; set; }
        int TimeOccuping3 { get; set; }
        int NumberClick1 { get; set; }
        int NumberClick2 { get; set; }
        int NumberClick3 { get; set; }
        bool System1 { set; }
        bool System2 { set; }

    }
}
