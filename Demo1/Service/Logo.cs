using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using System.Timers;
namespace ProductVertificationDesktopApp.Service
{
   public class Logo
    {
        private readonly S7Client _s7Client;
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
            _s7Client = new S7Client();
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
            DataReceivedHandler = new List<Action<int[],bool[]>>();
            DataReceivedHandlerUpdateSetting = new List<Action<int[]>>();
            _timer.Elapsed += Timer_Tick;
            _timer1.Elapsed += Timer1_Tick;

            Connect();
        }
       

        public List<Action<int[],bool[]>> DataReceivedHandler { get; set; }
        public List<Action<int[]>> DataReceivedHandlerUpdateSetting { get; set; }

        public void Connect()
        {
            _s7Client.SetConnectionParams(Address, 0200, 0300);
            int result = _s7Client.Connect();

            if (result == 0)
            {
                _timer.Enabled = true;
            }
        }
        // Send1Byte
        public void SetMemoryBit(string s)
        {
            var buffer = new byte[1];
            if ((s == "start")&&(_s7Client.Connect() == 0))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0, 6, true);
                _s7Client.DBWrite(1, 1105, 1, buffer);
                _timer1.Enabled = true;
            }
            if ((s == "stop")&& (_s7Client.Connect() == 0))
            {
                _timer.Enabled = false;
                Sharp7.S7.SetBitAt(buffer, 0, 6, false);
                Sharp7.S7.SetBitAt(buffer, 0, 7, true);
                _s7Client.DBWrite(1, 1105, 1, buffer);
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
            _s7Client.DBWrite(1, _memory + offset, 2, data_send);
            _timer.Enabled = true;
        }
        public void SendData4Byte(int offset, Int32 data)
        {
            _timer.Enabled = false;
            byte[] _data = new byte[4];
             _data = BitConverter.GetBytes(data);
            var data_send = MyConvert4Byte(_data);
            _s7Client.DBWrite(1, _memory + offset, 4, data_send);
            _timer.Enabled = true;
        }
        // đọc về Word khi cần
        public int ReadInt16(int offset)
        {
            byte[] buffer = new byte[2];
            _s7Client.DBRead(1, offset, 2, buffer);
            var _buffer = MyConvert2Byte(buffer);
            Int16 data = BitConverter.ToInt16(_buffer,0);
            int _data = (int)data/100;
            return _data ;
        }

        public int ReadInt32(int offset)
        {
              byte[] buffer = new byte[4];
            _s7Client.DBRead(1, offset, 4, buffer);
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
            // Read TimeStop
            int bufferTimeclose =ReadInt16(2);
            //Read TimeStart
            int bufferTimestart =ReadInt16(6);
            //Read TimeCount
            int bufferTimecheck = ReadInt16(8);
            //Read TimeCurrent
            int bufferCurrent = ReadInt32(100);
            // Read Settinh
            int bufferTimeClose = ReadInt16(0);
            int bufferTimeStart = ReadInt16(4);
            int buffTimeNumber = ReadInt32(14);    
            int[] data_supervisor = { bufferTimestart, bufferTimeclose, bufferTimecheck, bufferCurrent,_bufferTimeClose,_bufferTimeStart,_buffTimeNumber };
            //Read TimeCurrent

            var bufferQ = new byte[2];
            var bufferM = new byte[2];
            _s7Client.DBRead(1, 1064, 2, bufferQ);// read Q
            _s7Client.DBRead(1, 1104, 2, bufferM);// read M
            // READ BIT Q TO ARRAY
            bool[] data = new bool[35];
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    data[i * 8 + j+1] = Sharp7.S7.GetBitAt(bufferQ, i, j);
                }
            }
            // READ BIT M TO ARRAY
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    data[(i+2) * 8 + j+1] = Sharp7.S7.GetBitAt(bufferM, i, j);
                }
            }
            foreach (var handler in DataReceivedHandler)
            {
                handler.Invoke(data_supervisor,data);
            }

            if ((bufferTimeclose != _bufferTimeClose) || (bufferTimestart != _bufferTimeStart) || (buffTimeNumber != _buffTimeNumber))
            {
                int[] bufferSetting = { bufferTimeClose, bufferTimeStart, buffTimeNumber };
                foreach (var handler in DataReceivedHandlerUpdateSetting)
                {
                    handler.Invoke(bufferSetting);

                }
                _buffTimeNumber = buffTimeNumber;
                _bufferTimeClose = bufferTimeClose;
                _bufferTimeStart = bufferTimestart;
            }
        }

        private void Timer1_Tick(object sender, EventArgs args)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 0;
            _s7Client.DBWrite(1, 1105, 1, buffer);
            _timer.Enabled = true;
            _timer1.Enabled = false;
        }


    }
}

