using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain
{
    public class Error
    {
        public Error(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public Error()
        {
        }

        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
