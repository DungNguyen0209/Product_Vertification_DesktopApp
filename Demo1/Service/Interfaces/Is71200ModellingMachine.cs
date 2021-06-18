using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service.Interfaces
{
    public interface Is71200ModellingMachine
    {
        int SP_Force_Cylinder_1 { get; set; }
        int SP_Force_Cylinder_2 { get; set; }
        int SP_Force_Cylinder_3 { get; set; }
        int PV_Force_Cylinder_1 { get; set; }
        int PV_Force_Cylinder_2 { get; set; }
        int PV_Force_Cylinder_3 { get; set; }
        int SP_Time_Hold_12 { get; set; }
        int SP_Time_Hold_3 { get; set; }
        int SP_No_Press_12 { get; set; }
        int SP_No_Press_3 { get; set; }
        int PV_No_Press_1 { get; set; }
        int PV_No_Press_2 { get; set; }
        int PV_No_Press_3 { get; set; }
        int ErrorCode { get; set; }
        bool SelectSystem1 { get; set; }
        bool SelectSystem2 { get; set; }
        bool Start { get; set; }
        int Mode { get; set; }
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
