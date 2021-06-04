using ProductVertificationDesktopApp.Service;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service
{
    public class ModelingMachine:IModelingMachine
    {
        private readonly Logo _logo;
        private Int16 _TimeStop;
        private Int16 _TimeStart;
        private int _TimeNumber;
        public List<Action<bool>> UpdateData { get; set; }
        public ModelingMachine(Logo logo )
        {
            _logo = logo;
            UpdateData = new List<Action<bool>>();
            _logo.DataReceivedHandlerUpdateSetting.Add(DataRecivedIntHandler);
        }
        public short TimeStart
        {
            get
            {
                return _TimeStart;
            }

            set
            { _TimeStart = value; }
        }
        public short TimeStop
        {
            get
            {
                return _TimeStop;
            }

            set
            { _TimeStop = value; }
        }
        public int TimeNumber
        {
            get
            {
                return _TimeNumber;
            }

            set
            { _TimeNumber = value; }
        }
        public void Send2Bytes(short data,int offset)
        {
            _logo.SendData2Byte(offset, data);
        }

        public void Send4byte(int data, int offset)
        {
            _logo.SendData4Byte(offset, data);
        }
        private void DataRecivedIntHandler(int[] data)
        {
            _TimeStop = Convert.ToInt16(data[0]);
            _TimeStart = Convert.ToInt16(data[1]);
            _TimeNumber = data[2];
            foreach (var handler in UpdateData)
            {
                handler.Invoke(true);
            }
        }
    }
}
