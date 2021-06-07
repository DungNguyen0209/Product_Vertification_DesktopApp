using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service.Interfaces
{
    public interface ISupervisor
    {
        bool Run { get; set; }
        bool Warn { get; set; }
        int TimeStart { get; set; }
        int TimeStop { get; set; }
        int TimeCount { get; set; }
        int TimeCurrent { get; set; }
        int TimeCloseSP { get; set; }
        int TimeOpenSP { get; set; }
        int NumberCloseSP { get; set; }
        void SendStatus(string s);
        event EventHandler<int[]> UpdateData;
    }
}
