using ProductVertificationDesktopApp.Service;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service
{
    class S71200ModellingMachines:Is71200ModellingMachine
    {
        private int _CompressionForceSettingsystem1_SP;
        private int _CompressionForceSettingsystem2_SP;
        private int _CompressionForceSettingsystem3_SP;
        private int _CompressionForceSettingsystem1_PV;
        private int _CompressionForceSettingsystem2_PV;
        private int _CompressionForceSettingsystem3_PV;
        private int _TimeOccupying1;
        private int _TimeOccupying2;
        private int _NumberClick1_SP;
        private int _NumberClick2_SP;
        private int _NumberClick3_SP;
        private int _NumberClick1_PV;
        private int _NumberClick2_PV;
        private int _NumberClick3_PV;
        private int _Display_Mode;
        private int _ErrorCode;
        private bool _SelectSystem1;
        private bool _SelectSystem2;
        private bool _Start;
        private bool _Mode;
        private bool _Warning;
        private S71200 _s71200;

        public S71200ModellingMachines(S71200 s71200)
        {
            _s71200 = s71200;
            UpdateData = new List<Action<bool>>();
            _s71200.DataReceivedHandlerBits.Add(DataReceivedBitHandler);
            _s71200.DataReceivedHandlerInt.Add(DataReceivedIntHandler);
        }

        public List<Action<bool>> UpdateData { get; set; }
        public int CompressionForceSettingsystem1_SP
        {
            get
            {
                return _CompressionForceSettingsystem1_SP;
            }

            set
            { _CompressionForceSettingsystem1_SP = value; }
        }
        public int CompressionForceSettingsystem2_SP {
            get
            {
                return _CompressionForceSettingsystem2_SP;
            }

            set
            { _CompressionForceSettingsystem2_SP = value; }
        }
        public int CompressionForceSettingsystem3_SP {
            get
            {
                return _CompressionForceSettingsystem3_SP;
            }

            set
            { _CompressionForceSettingsystem3_SP = value; }
        }
        public int CompressionForceSettingsystem1_PV
        {
            get
            {
                return _CompressionForceSettingsystem1_PV;
            }

            set
            { _CompressionForceSettingsystem1_PV = value; }
        }
        public int CompressionForceSettingsystem2_PV
        {
            get
            {
                return _CompressionForceSettingsystem2_PV;
            }

            set
            { _CompressionForceSettingsystem2_PV = value; }
        }
        public int CompressionForceSettingsystem3_PV
        {
            get
            {
                return _CompressionForceSettingsystem3_PV;
            }

            set
            { _CompressionForceSettingsystem3_PV = value; }
        }
        public int TimeOccupying1
        {
            get
            {
                return _TimeOccupying1;
            }

            set
            { _TimeOccupying1 = value; }
        }
        public int TimeOccupying2 {
            get
            {
                return _TimeOccupying2;
            }

            set
            { _TimeOccupying2 = value; }
        }
        
        public int NumberClick1_SP {
            get
            {
                return _NumberClick1_SP;
            }

            set
            { _NumberClick1_SP = value; }
        }
        public int NumberClick2_SP {
            get
            {
                return _NumberClick2_SP;
            }

            set
            { _NumberClick2_SP = value; }
        }
        public int NumberClick3_SP {
            get
            {
                return _NumberClick3_SP;
            }

            set
            { _NumberClick3_SP = value; }
        }

        public int NumberClick1_PV
        {
            get
            {
                return _NumberClick1_PV;
            }

            set
            { _NumberClick1_PV = value; }
        }
        public int NumberClick2_PV
        {
            get
            {
                return _NumberClick2_PV;
            }

            set
            { _NumberClick2_PV = value; }
        }
        public int NumberClick3_PV
        {
            get
            {
                return _NumberClick3_PV;
            }

            set
            { _NumberClick3_PV = value; }
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
        public bool Mode
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

        public int Display_Mode {
            get
            {
                return _Display_Mode;
            }

            set
            { _Display_Mode = value; }
        }

        private void DataReceivedIntHandler(int[] data)
        {
            _CompressionForceSettingsystem1_PV = data[1];
            _CompressionForceSettingsystem2_PV = data[2];
            _CompressionForceSettingsystem3_PV = data[3];
            _NumberClick1_PV = data[4];
            _NumberClick2_PV = data[5];
            _NumberClick3_PV = data[6];
            _CompressionForceSettingsystem1_SP = data[7];
            _CompressionForceSettingsystem2_SP = data[8];
            _NumberClick1_SP = data[9];
            _NumberClick2_SP = data[10];
            _TimeOccupying1 = data[11];
            _TimeOccupying2 = data[12];
            _ErrorCode = data[13];
            _Display_Mode = data[14];

            foreach (var handler in UpdateData)
            {
                handler.Invoke(true);
            }
        }

        private void DataReceivedBitHandler(bool[] data)
        {
            _SelectSystem1 = data[1];
            _SelectSystem2 = data[2];
            _Start = data[3];
            _Mode = data[0];
            _Warning = data[4];

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
