using ProductVertificationDesktopApp.Domain.Models.PlcS71200;
using ProductVertificationDesktopApp.Service;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using System.Collections;

namespace ProductVertificationDesktopApp.Service
{
    class S71200ModellingMachines:Is71200ModellingMachine
    {
        private int _SP_Force_Cylinder_1;
        private int _SP_Force_Cylinder_2;
        private int _SP_Force_Cylinder_3;
        private int _PV_Force_Cylinder_1;
        private int _PV_Force_Cylinder_2;
        private int _PV_Force_Cylinder_3;
        private int _SP_Time_Hold_12;
        private int _SP_Time_Hold_3;
        private int _SP_No_Press_12;
        private int _SP_No_Press_3;
        private int _PV_No_Press_1;
        private int _PV_No_Press_2;
        private int _PV_No_Press_3;
        private int _ErrorCode;
        private bool _SelectSystem1;
        private bool _SelectSystem2;
        private bool _Start;
        private int _Mode;
        private bool _Warning;
        private S71200 _s71200;

        public S71200ModellingMachines(S71200 s71200)
        {
            _s71200 = s71200;
            UpdateData = new List<Action<bool>>();
            _s71200.DataReceived.Add(DataReceivedHandler);
        }

        public List<Action<bool>> UpdateData { get; set; }
        public int SP_Force_Cylinder_1
        {
            get
            {
                return _SP_Force_Cylinder_1;
            }

            set
            { _SP_Force_Cylinder_1 = value; }
        }
        public int SP_Force_Cylinder_2 {
            get
            {
                return _SP_Force_Cylinder_2;
            }

            set
            { _SP_Force_Cylinder_2 = value; }
        }
        public int SP_Force_Cylinder_3 {
            get
            {
                return _SP_Force_Cylinder_3;
            }

            set
            { _SP_Force_Cylinder_3 = value; }
        }
        public int PV_Force_Cylinder_1
        {
            get
            {
                return _PV_Force_Cylinder_1;
            }

            set
            { _PV_Force_Cylinder_1 = value; }
        }
        public int PV_Force_Cylinder_2
        {
            get
            {
                return _PV_Force_Cylinder_2;
            }

            set
            { _PV_Force_Cylinder_2 = value; }
        }
        public int PV_Force_Cylinder_3
        {
            get
            {
                return _PV_Force_Cylinder_3;
            }

            set
            { _PV_Force_Cylinder_3 = value; }
        }
        public int SP_Time_Hold_12
        {
            get
            {
                return _SP_Time_Hold_12;
            }

            set
            { _SP_Time_Hold_12 = value; }
        }
        public int SP_Time_Hold_3 {
            get
            {
                return _SP_Time_Hold_3;
            }

            set
            { _SP_Time_Hold_3 = value; }
        }
        
        public int SP_No_Press_12 {
            get
            {
                return _SP_No_Press_12;
            }

            set
            { _SP_No_Press_12 = value; }
        }
        public int SP_No_Press_3 {
            get
            {
                return _SP_No_Press_3;
            }

            set
            { _SP_No_Press_3 = value; }
        }

        public int PV_No_Press_1
        {
            get
            {
                return _PV_No_Press_1;
            }

            set
            { _PV_No_Press_1 = value; }
        }
        public int PV_No_Press_2
        {
            get
            {
                return _PV_No_Press_2;
            }

            set
            { _PV_No_Press_2 = value; }
        }
        public int PV_No_Press_3
        {
            get
            {
                return _PV_No_Press_3;
            }

            set
            { _PV_No_Press_3 = value; }
        }
        public bool Start
        {
            get
            {
                return _Start;
            }

            set
            { _Start = value; }
        }
        public int Mode
        {
            get
            {
                return _Mode;
            }

            set
            { _Mode= value; }
        }
        public bool Warning
        {
            get
            {
                return _Warning;
            }

            set
            { _Warning = value; }
        }

        public bool SelectSystem1
        {
            get
            {
                return _SelectSystem1;
            }

            set
            { _SelectSystem1 = value; }
        }
        public bool SelectSystem2
        {
            get
            {
                return _SelectSystem2;
            }

            set
            { _SelectSystem2 = value; }
        }

        public int ErrorCode {
            get
            {
                return _ErrorCode;
            }

            set
            { _ErrorCode = value; }
        }

        

        private void DataReceivedHandler(TestingStruct testingStruct)
        {
            _PV_Force_Cylinder_1 = (int)testingStruct.PV_Force_Cylinder_1;
            _PV_Force_Cylinder_2 = (int )testingStruct.PV_Force_Cylinder_2;
            _PV_Force_Cylinder_3 = (int)testingStruct.PV_Force_Cylinder_3;
            _PV_No_Press_1 = (int)testingStruct.PV_No_Press_1;
            _PV_No_Press_2 = (int)testingStruct.PV_No_Press_2;
            _PV_No_Press_3 =(int)testingStruct.PV_No_Press_3;
            _SP_Force_Cylinder_1 = (int)testingStruct.SP_Force_Cylinder_12;
            _SP_Force_Cylinder_2 = (int)testingStruct.SP_Force_Cylinder_3;
            _SP_No_Press_12 = (int)testingStruct.SP_No_Press_12;
            _SP_No_Press_3 = (int)testingStruct.SP_No_Press_3;
            _SP_Time_Hold_12 = (int)testingStruct.SP_Time_Hold_12/1000;
            _SP_Time_Hold_3 = (int)testingStruct.SP_Time_Hold_3/1000;
            _ErrorCode = (int)testingStruct.Error_Code;
            _Start = testingStruct.Green_App;
            _Warning = testingStruct.Red_App;
            _SelectSystem1 = testingStruct.Seclec_1_App;
            _SelectSystem2 = testingStruct.Seclec_2_App;
            Mode = testingStruct.Mode;
            foreach (var handler in UpdateData)
            {
                handler.Invoke(true);
            }
        }


        public void SendStatus(string s)
        {
            _s71200.SetMemoryBit(s.ToLower());
        }

        public void SendataUint(Int16 data, int offset)
        {
            _s71200.SendDataUint(offset,data);
        }
        public void SendataReal(Single data, int offset)
        {
            _s71200.SendDataReal(offset, data);
        }
        public void SendTime (int data, int offset)
        {
            _s71200.SendTime(offset, data);
        }

        public void SetMemmoryBit(int offset, int bit, bool status, int StatusSelect)
        {
            _s71200.SetMemMoryBitData(offset, bit, status,StatusSelect);
        }
        public void SetMemmoryStatus(int offset, int bit, bool status)
        {
            _s71200.SetMemMoryBitStatus(offset, bit, status);
        }
    }
}
