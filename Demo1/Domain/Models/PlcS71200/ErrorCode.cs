using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models.PlcS71200
{
    public enum ErrorCode
    {
        NoError = 0,
        WrongCPU_Type = 1,
        ConnectionError = 2,
        IPAddressNotAvailable,
        WrongVarFormat = 10,
        WrongNumberReceivedBytes = 11,
        SendData = 20,
        ReadData = 30,
        WriteData = 50
    }
}
