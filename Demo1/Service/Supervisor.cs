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
        private int _TimeCloseSP;
        private int _TimeOpenSP;
        private int _NumberCloseSP;
        public event EventHandler<int[]> UpdateData;
        public Supervisor(Logo logo)
        {
            _logo = logo;
            _logo.DataReceivedHandler.Add(DataRecivedHandler);
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

        public int TimeCloseSP
        {
            get
            {
                return _TimeCloseSP;
            }

            set
            { _TimeCloseSP = value; }
        }

        public int TimeOpenSP
        {
            get
            {
                return _TimeOpenSP;
            }

            set
            { _TimeOpenSP = value; }
        }

        public int NumberCloseSP
        {
            get
            {
                return _NumberCloseSP;
            }

            set
            { _NumberCloseSP = value; }
        }

        public void SendStatus(string s)
        {
            _logo.SetMemoryBit(s.ToLower());
        }

        private void DataRecivedHandler(int[] data1, bool[] data)
        {
            _TimeStop = data1[0];
            _TimeStart = data1[1];
            _TimeCount = data1[2];
            _TimeCurrent = data1[3];
            _TimeCloseSP = data1[4];
            _TimeOpenSP = data1[5];
            _NumberCloseSP = data1[6];
            _Run = data[7];
            _Warn = data[3];
            UpdateData?.Invoke(this, data1);
        }



    }
}
