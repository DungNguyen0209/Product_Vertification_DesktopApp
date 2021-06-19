using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using System.Timers;
using ProductVertificationDesktopApp.Domain.Models.LOGO_;
using S7.Net;

namespace ProductVertificationDesktopApp.Service
{
   public class Logo
    {
        private readonly Plc _s7Client;
        private readonly Timer _timer;
        public string Address { get; set; }
        private readonly Timer _timer1;
        private readonly int _memory;
        private int _bufferTimeClose;
        private int _bufferTimeStart;
        private int _buffTimeNumber;
        public Logo(string address,int memory)
        {
            Address = address;
            _memory = memory;
            _s7Client = new Plc(CpuType.Logo0BA8, address, 0, 1); ;
            _timer = new Timer
            {
                Interval = 650,
                Enabled = false
            };

            _timer1 = new Timer
            {
                Interval = 200,
                Enabled = false
            };
            DataReceivedHandler = new List<Action<ComponentResult,int,bool,bool>>();
            DataReceivedHandlerUpdateSetting = new List<Action<int[]>>();
            _timer.Elapsed += Timer_Tick;
            _timer1.Elapsed += Timer1_Tick;

            Connect();
        }
       

        public List<Action<ComponentResult,int, bool, bool>> DataReceivedHandler { get; set; }
        public List<Action<int[]>> DataReceivedHandlerUpdateSetting { get; set; }

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
                Console.WriteLine("PLC LOGO! is not connected !");
            }
        }
        // Send1Byte
        public void SetMemoryBit(string s)
        {
            var buffer = new byte[1];
            if ((s == "start")&&(_s7Client.IsConnected == true))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0, 6, true);
                _s7Client.WriteBytes(DataType.DataBlock, 1, 1105, buffer);
                _timer1.Enabled = true;
            }
            if ((s == "stop")&& (_s7Client.IsConnected == true))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0, 6, false);
                Sharp7.S7.SetBitAt(buffer, 0, 7, true);
                _s7Client.WriteBytes(DataType.DataBlock, 1, 1105, buffer);
                _timer1.Enabled = true;
            }

        }
        // Send data with2 Bytes
        public void SendData2Byte(int offset, Int16 data)
        {
            _timer.Enabled = false;
            byte[] _data = new byte[2];
             _data = BitConverter.GetBytes(data*100);
            var data_send = MyConvert2Byte(_data);
            _s7Client.WriteBytes(DataType.DataBlock, 1, _memory + offset, data_send);
            _timer.Enabled = true;
        }
        public void SendData4Byte(int offset, Int32 data)
        {
            _timer.Enabled = false;
            byte[] _data = new byte[4];
             _data = BitConverter.GetBytes(data);
            var data_send = MyConvert4Byte(_data);
            _s7Client.WriteBytes(DataType.DataBlock, 1, _memory + offset, data_send);
            _timer.Enabled = true;
        }
        // đọc về Word khi cần
        public int ReadInt16(int offset)
        {
            byte[] buffer = new byte[2];
           // _s7Client.DBRead(1, offset, 2, buffer);
            var _buffer = MyConvert2Byte(buffer);
            Int16 data = BitConverter.ToInt16(_buffer,0);
            int _data = (int)data/100;
            return _data ;
        }

        public int ReadInt32(int offset)
        {
              byte[] buffer = new byte[4];
           // _s7Client.DBRead(1, offset, 4, buffer);
            byte[] _buffer = new byte[4];
            _buffer = MyConvert4Byte(buffer);
            int data = BitConverter.ToInt32(_buffer, 0);
            return data;
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
        // nhận sự kiện đọc LOGO đọc 16 BIT auto
        private void Timer_Tick(object sender, EventArgs args)
        {
            var data = (ComponentResult)_s7Client.ReadStruct(typeof(ComponentResult), 1, 0);
            int CurrentNumberClosing = (int)_s7Client.Read(DataType.DataBlock, 1, 100, VarType.Int, 1);
            var bufferQ = _s7Client.ReadBytes(DataType.DataBlock,1,1064,1);// read Q
            var bufferM = _s7Client.ReadBytes(DataType.DataBlock,1,1104,2);// read M
            bool Start = Sharp7.S7.GetBitAt(bufferQ, 0, 3);
            bool Warning = Sharp7.S7.GetBitAt(bufferQ, 0, 7);            

            if ((data.TimeCloseSP != _bufferTimeClose) || (data.TimeOpenSP != _bufferTimeStart) || (data.NumberClosingSP!= _buffTimeNumber))
            {
                int[] bufferSetting = { data.TimeCloseSP, data.TimeOpenSP, data.NumberClosingSP };
                foreach (var handler in DataReceivedHandlerUpdateSetting)
                {
                    handler.Invoke(bufferSetting);

                }
                _buffTimeNumber = data.NumberClosingSP;
                _bufferTimeClose = data.TimeCloseSP;
                _bufferTimeStart = data.TimeOpenSP;
            }
            foreach (var handler in DataReceivedHandler)
            {
                handler.Invoke(data, CurrentNumberClosing,Start,Warning);

            }
        }

        private void Timer1_Tick(object sender, EventArgs args)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 0;
           _s7Client.WriteBytes(DataType.DataBlock,1, 1105, buffer);
            _timer.Enabled = true;
            _timer1.Enabled = false;
        }


    }
}

