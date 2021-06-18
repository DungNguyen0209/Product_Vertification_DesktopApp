using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models.PlcS71200
{
    public struct TestingStruct
    {
        public Single PV_Force_Cylinder_1;
        public Single PV_Force_Cylinder_2;
        public Single PV_Force_Cylinder_3;
        public Int16 PV_No_Press_1;
        public Int16 PV_No_Press_2;
        public Int16 PV_No_Press_3;
        public Single SP_Force_Cylinder_12;
        public Single SP_Force_Cylinder_3;
        public Int16 SP_No_Press_12;
        public Int16 SP_No_Press_3;
        public Int32 SP_Time_Hold_12;
        public Int32 SP_Time_Hold_3;
        public Byte Mode;
        public Byte Empty;
        public Int16 Error_Code;
    }
}
