using ProductVertificationDesktopApp.Service;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service
{
    public class Supervisor:ISupervisor
    {
        private readonly Logo _logo;
        private bool _Run;
        private bool _Warn;
        private int _TimeStart;
        private int _TimeStop;
        private int _TimeCount;
        private int _TimeCurrent;
        public List<Action<bool>> UpdateData { get; set; }
        public Supervisor(Logo logo)
        {
            UpdateData = new List<Action<bool>>();
            _logo = logo;
            _logo.DataReceivedHandlerInt.Add(DataRecivedIntHandler);
            _logo.DataReceivedHandlerBits.Add(DataReciedBitHandler);
        }
        public bool Run
        {
            get
            {
                return _Run;
            }

            set
            { _Run = value; }
        }

        public bool Warn
        {
            get
            {
                return _Warn;
            }

            set
            { _Warn = value; }
        }
        public int TimeStart
        {
            get
            {
                return _TimeStart;
            }

            set
            { _TimeStart = value; }
        }
        public int TimeStop
        {
            get
            {
                return _TimeStop;
            }

            set
            {  _TimeStop=value; }
        }
        public int TimeCount
        {
            get
            {
                return _TimeCount;
            }

            set
            { _TimeCount = value; }
        }
        public int TimeCurrent
        {
            get
            {
                return _TimeCurrent;
            }

            set
            { _TimeCurrent = value; }
        }

        public void SendStatus(string s)
        {
            _logo.SetMemoryBit(s.ToLower());
        }

        private void DataRecivedIntHandler(int[] data )
        {
            _TimeStop = data[0];
            _TimeStart = data[1];
            _TimeCount = data[2];
            _TimeCurrent = data[3];
            foreach (var handler in UpdateData)
            {
                handler.Invoke(true);
            }
        }

        private void DataReciedBitHandler(bool[] data)
        {
            _Run = data[7];
            _Warn = data[3];
        }

    }
}
