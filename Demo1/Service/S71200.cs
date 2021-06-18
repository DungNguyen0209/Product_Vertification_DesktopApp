using ProductVertificationDesktopApp.Domain.Models.PlcS71200;
using S7.Net;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ProductVertificationDesktopApp.Service
{
    class S71200
    {
        private readonly Plc _s7Client;
        private readonly Timer _timer;
        private readonly Timer _timer1;
        private readonly int _memory;
        private readonly int _DB;
        public int SelectSystem;
        public S71200( int memory, string address,int DB)
        {
            _s7Client = new  Plc(CpuType.S71200, address, 0, 1);
            _memory = memory;
            Address = address;
            _DB = DB;
            _timer = new Timer
            {
                Interval = 600,
                Enabled = false
            };
            _timer1 = new Timer
            {
                Interval = 80,
                Enabled = false
            };
            DataReceived = new List<Action<TestingStruct>>();
             _timer.Elapsed += Timer_Tick;
            _timer1.Elapsed += Timer1_Tick;
            Connect();
        }
        public string Address { get; set; }
        public List<Action<TestingStruct>> DataReceived { get; set; }
        public void Connect()
        {
            try
            {
                _s7Client.Open();
                bool result = _s7Client.IsConnected;
                if (result == true)
                {
                    _timer.Enabled = true;
                }
            }
            catch
            {
                Console.WriteLine("PLC s7-1200 is not connected !");
            }
        }
        public void SetMemoryBit(string s)
        {
            var buffer = new byte[1];
            if ((s == "start")&& (_s7Client.IsConnected == true))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0,1,true);
                _s7Client.WriteBytes(DataType.DataBlock,_DB,0,buffer);
                _timer1.Enabled = true;

            }
            if ((s == "stop")&&(_s7Client.IsConnected == true))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0, 2, true);
                _s7Client.WriteBytes(DataType.DataBlock, _DB, 0, buffer);
                _timer1.Enabled = true;
            }
            if ((s == "reset")&&(_s7Client.IsConnected == true))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0, 3, true);
                _s7Client.WriteBytes(DataType.DataBlock, _DB, 0, buffer);
                _timer1.Enabled = true;
            }

            if ((s == "confirm") && (_s7Client.IsConnected == true))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0, 6, true);
                _s7Client.WriteBytes(DataType.DataBlock, _DB, 0, buffer);
                _timer1.Enabled = true;
            }
            if ((s == "cancel") && (_s7Client.IsConnected == true))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0, 6, false);
                _s7Client.WriteBytes(DataType.DataBlock, _DB, 0, buffer);
                _timer1.Enabled = true;
                _timer.Enabled = true;
            }
            buffer[0] = 0;
        }

        public void SetMemMoryBitData(int offset, int bit, bool status, int StatusSelect)
        {
            var buffer = new byte[1];
            Sharp7.S7.SetBitAt(buffer, 0, bit, status);
            if (StatusSelect == 1)
            {
                Sharp7.S7.SetBitAt(buffer, 0, 4, true);
                Sharp7.S7.SetBitAt(buffer, 0, 5, false);
            }
            if (StatusSelect == 2)
            {
                Sharp7.S7.SetBitAt(buffer, 0, 4, false);
                Sharp7.S7.SetBitAt(buffer, 0, 5, true);
            }
            if (StatusSelect == 3)
            {
                Sharp7.S7.SetBitAt(buffer, 0, 4, true);
                Sharp7.S7.SetBitAt(buffer, 0, 5, true);
            }
            if (StatusSelect == 4)
            {
                Sharp7.S7.SetBitAt(buffer, 0, 4, false);
                Sharp7.S7.SetBitAt(buffer, 0, 5, false);
            }
            Sharp7.S7.SetBitAt(buffer, 0, bit, status);
            _s7Client.WriteBytes(DataType.DataBlock, _DB, 0, buffer);
            _timer1.Enabled = true;

        }
        public void SetMemMoryBitStatus(int offset, int bit, bool status)
        {
            var buffer = new byte[1];
            Sharp7.S7.SetBitAt(buffer, 0, bit, status);
            _s7Client.WriteBytes(DataType.DataBlock, _DB, 0, buffer);
        }
        public void SendDataUint(int offset, Int16 data)
        {
            byte[] _data = new byte[2];
            _data = BitConverter.GetBytes(data);
            var data_send = MyConvert2Byte(_data);
            _s7Client.WriteBytes(DataType.DataBlock, _DB, _memory + offset, data_send);
        }
        public void SendDataReal(int offset, Single data)
        {
            byte[] _data = new byte[4];
            _data = BitConverter.GetBytes(data);
            var data_send = MyConvert4Byte(_data);
            _s7Client.WriteBytes(DataType.DataBlock, _DB, _memory + offset, data_send);
        }

        public void SendTime(int offset, int data)
        {
            byte[] _data = new byte[4];
            _data = BitConverter.GetBytes(data*1000);
            var data_send = MyConvert4Byte(_data);
            _s7Client.WriteBytes(DataType.DataBlock, _DB, _memory + offset, data_send);
        }
        public byte[] MyConvert4Byte(byte[] buffer_data)
        {
            byte[] buffer = new byte[4];
            buffer[0] = buffer_data[3];
            buffer[1] = buffer_data[2];
            buffer[2] = buffer_data[1];
            buffer[3] = buffer_data[0];
            return buffer;
        }
        public byte[] MyConvert2Byte(byte[] buffer_data)
        {
            byte temp = buffer_data[0];
            buffer_data[0] = buffer_data[1];
            buffer_data[1] = temp;
            return buffer_data;
        }


        private void Timer1_Tick(object sender, EventArgs args)
        {
            var buffer_send1 = new byte[1];
            buffer_send1 = _s7Client.ReadBytes(DataType.DataBlock, _DB, 0, 1);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 1, false);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 2, false);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 3, false);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 6, false);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 7, false);
            _s7Client.WriteBytes(DataType.DataBlock, _DB, 0, buffer_send1);
            _timer.Enabled = true;
            _timer1.Enabled = false;
        }
        private void Timer_Tick(object sender, EventArgs args)
        {
            var data = (TestingStruct)_s7Client.ReadStruct(typeof(TestingStruct), _DB, 22);
            foreach (var handler in DataReceived)
            {
                handler.Invoke(data);
            }
        }
    }
}
