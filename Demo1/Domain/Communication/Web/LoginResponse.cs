using MayEp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEp.Domain.Communication.Web
{
    public class LoginResponse
    {
        public Token Token { get; set; }
        public Employee Employee { get; set; }
    }
}
