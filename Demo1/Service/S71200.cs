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
        private readonly S7Client _s7Client;
        private readonly Timer _timer;
        private readonly Timer _timer1;
        private readonly int _memory;
        private readonly int _DB;
        public int SelectSystem;
        public S71200( int memory, string address,int DB)
        {
            _s7Client = new S7Client();
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
            DataReceivedHandlerBits = new List<Action<bool[]>>();
            DataReceivedHandlerInt = new List<Action<int[]>>();
             _timer.Elapsed += Timer_Tick;
            _timer1.Elapsed += Timer1_Tick;
            Connect();
        }

        public string Address { get; set; }

        public List<Action<bool[]>> DataReceivedHandlerBits { get; set; }
        public List<Action<int[]>> DataReceivedHandlerInt { get; set; }
        public void Connect()
        {
            _s7Client.ConnectTo(Address, 0, 0);
            int result = _s7Client.Connect();

            if (result == 0)
            {
                _timer.Enabled = true;
            }
        }

        public void SetMemoryBit(string s)
        {
            var buffer = new byte[1];
            if ((s == "start")&& (_s7Client.Connect() == 0))
            {
                Sharp7.S7.SetBitAt(buffer, 0,1,true);
                _s7Client.WriteArea(0x84, 52, 0, 1, 0x02, buffer);

            }
            if ((s == "stop")&&(_s7Client.Connect() == 0))
            {
                Sharp7.S7.SetBitAt(buffer, 0, 2, true);
                _s7Client.WriteArea(0x84, 52, 0, 1, 0x02, buffer);
            }
            if ((s == "reset")&&(_s7Client.Connect() == 0))
            {
                Sharp7.S7.SetBitAt(buffer, 0, 3, true);
                _s7Client.WriteArea(0x84, 52, 0, 1, 0x02, buffer);
                _timer1.Enabled = true;
            }

            if ((s == "confirm") && (_s7Client.Connect() == 0))
            {
                Sharp7.S7.SetBitAt(buffer, 0, 6, true);
                _s7Client.WriteArea(0x84, 52, 0, 1, 0x02, buffer);
                _timer1.Enabled = true;
            }
            if ((s == "cancel") && (_s7Client.Connect() == 0))
            {
                Sharp7.S7.SetBitAt(buffer, 0, 6, false);
                _s7Client.WriteArea(0x84, 52, 0, 1, 0x02, buffer);
                _timer1.Enabled = true;
            }
            buffer[0] = 0;
        }

        public void SetMemMoryBitData(int offset, int bit, bool status, int StatusSelect)
        {
            SelectSystem = StatusSelect;
            var buffer = new byte[1];
            Sharp7.S7.SetBitAt(buffer, 0, bit, status);
            _s7Client.WriteArea(0x84, 52, 0, 1, 0x02, buffer);
            _timer1.Enabled = true;

        }
        public void SetMemMoryBitStatus(int offset, int bit, bool status)
        {
            var bufffer = new byte[1];
            Sharp7.S7.SetBitAt(bufffer, 0, bit, status);
            _s7Client.WriteArea(0x84, 52, offset, 1, 0x02, bufffer);
        }
        public void SendDataUint(int offset, Int16 data)
        {
            byte[] _data = new byte[2];
            _data = BitConverter.GetBytes(data);
            var data_send = MyConvert2Byte(_data);
            _s7Client.WriteArea(0x84, _DB, _memory + offset,1, 0x04, data_send);
        }
        public void SendDataReal(int offset, Single data)
        {
            byte[] _data = new byte[4];
            _data = BitConverter.GetBytes(data);
            var data_send = MyConvert4Byte(_data);
            _s7Client.WriteArea(0x84, _DB, _memory + offset, 1, 0x06, data_send);
        }

        public void SendTime(int offset, int data)
        {
            byte[] _data = new byte[4];
            _data = BitConverter.GetBytes(data*1000);
            var data_send = MyConvert4Byte(_data);
            _s7Client.WriteArea(0x84,_DB, _memory + offset, 1, 0x06, data_send);
        }
        // đọc về Word khi cần
        public int ReadInt16(int offset)
        {
            byte[] buffer = new byte[2];
            //_s7Client.DBRead(_DB, offset, 2, buffer);
            _s7Client.ReadArea(0x84,52,offset,1, 0x04,buffer);
            var _buffer = MyConvert2Byte(buffer);
            Int16 data = BitConverter.ToInt16(_buffer, 0);
            int _data = (int)data ;
            return _data;
        }

        public int ReadReal(int offset)
        {
            byte[] buffer = new byte[4];
            _s7Client.ReadArea(0x84, 52, offset, 1, 0x06, buffer);
            byte[] _buffer = new byte[4];
            _buffer = MyConvert4Byte(buffer);
            var data = BitConverter.ToSingle(_buffer, 0);
            return (int)data;
        }
        public int ReadTime(int offset)
        {
            byte[] buffer = new byte[4];
            _s7Client.ReadArea(0x84, 52, offset, 1, 0x06, buffer);
            byte[] _buffer = new byte[4];
            _buffer = MyConvert4Byte(buffer);
            var data = BitConverter.ToUInt32(_buffer, 0);
            return (int)data;
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
            Sharp7.S7.SetBitAt(buffer_send1, 0, 1, false);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 2, false);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 3, false);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 6, false);
            Sharp7.S7.SetBitAt(buffer_send1, 0, 7, false);
            if(SelectSystem==1)
            {
                Sharp7.S7.SetBitAt(buffer_send1, 0, 4, true);
                Sharp7.S7.SetBitAt(buffer_send1, 0, 5, false);
            }
            if (SelectSystem == 2)
            {
                Sharp7.S7.SetBitAt(buffer_send1, 0, 4, false);
                Sharp7.S7.SetBitAt(buffer_send1, 0, 5, true);
            }
            if (SelectSystem == 3)
            {
                Sharp7.S7.SetBitAt(buffer_send1, 0, 4, true);
                Sharp7.S7.SetBitAt(buffer_send1, 0, 5, true);
            }
            if (SelectSystem == 4)
            {
                Sharp7.S7.SetBitAt(buffer_send1, 0, 4,false);
                Sharp7.S7.SetBitAt(buffer_send1, 0, 5, false);
            }
            _s7Client.WriteArea(0x84, 52, 0, 1, 0x02, buffer_send1);
            _timer1.Enabled = false;
        }
        private void Timer_Tick(object sender, EventArgs args)
        {
            byte[] _buffer = new byte[100];
            _s7Client.DBRead(_DB, 22, 42, _buffer);
            byte[] buffer = new byte[1];
            byte[] testing=new byte[15];
            int PV_Force_Cylinder_1 = ReadReal(22);
            int PV_Force_Cylinder_2 = ReadReal(26);
            int PV_Force_Cylinder_3 = ReadReal(30);
            int PV_No_Press_1 = ReadInt16(34);
            int PV_No_Press_2 = ReadInt16(36);
            int PV_No_Press_3 = ReadInt16(38);
            int SP_Force_Cylinder_12 = ReadReal(40);
            int SP_Force_Cylinder_3 = ReadReal(44);
            int SP_No_Press_12 = ReadInt16(48);
            int SP_No_Press_3 = ReadInt16(50);
            int SP_Time_Hold_12 = ReadTime(52)/1000;
            int SP_Time_Hold_3 = ReadTime(56)/1000;
            int Error_Code = ReadReal(62);
            int Display_mode = ReadInt16(64);
            int[] data_supervisor = { 0,PV_Force_Cylinder_1,PV_Force_Cylinder_2,PV_Force_Cylinder_3,PV_No_Press_1,PV_No_Press_2,PV_No_Press_3,SP_Force_Cylinder_12,SP_Force_Cylinder_3,SP_No_Press_12,SP_No_Press_3,SP_Time_Hold_12,SP_Time_Hold_3,Error_Code,Display_mode};
            _s7Client.DBRead(52, 60, 1, buffer);
            bool[] data = new bool[16];
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    data[i * 8 + j] = Sharp7.S7.GetBitAt(buffer, i, j);
                }
            }
            foreach (var handler in DataReceivedHandlerBits)
            {
                handler.Invoke(data);
            }
            foreach (var handler in DataReceivedHandlerInt)
            {
                handler.Invoke(data_supervisor);
            }
        }
    }
}
