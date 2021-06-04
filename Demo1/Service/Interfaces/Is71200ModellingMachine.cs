using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service.Interfaces
{
    public interface Is71200ModellingMachine
    {
        int CompressionForceSettingsystem1_SP { get; set; }
        int CompressionForceSettingsystem2_SP { get; set; }
        int CompressionForceSettingsystem3_SP { get; set; }
        int CompressionForceSettingsystem1_PV { get; set; }
        int CompressionForceSettingsystem2_PV { get; set; }
        int CompressionForceSettingsystem3_PV { get; set; }
        int TimeOccupying1 { get; set; }
        int TimeOccupying2 { get; set; }
        int NumberClick1_SP { get; set; }
        int NumberClick2_SP { get; set; }
        int NumberClick3_SP { get; set; }
        int NumberClick1_PV { get; set; }
        int NumberClick2_PV { get; set; }
        int NumberClick3_PV { get; set; }
        int Display_Mode { get; set; }

        int ErrorCode { get; set; }
        bool SelectSystem1 { get; set; }
        bool SelectSystem2 { get; set; }
        bool Start { get; set; }
        bool Mode { get; set; }
        bool Warning { get; set; }
        List<Action<bool>> UpdateData { get; set; }
        void SendStatus(string s);
        void SendataUint(Int16 data, int offset);
        void SendataReal(Single data, int offset);
        void SendTime(Int32 data, Int32 offset);
        void SetMemmoryBit(int offset, int bit, bool status, int StatusSelect);
        void SetMemmoryStatus(int offset, int bit, bool status);
    }
}
