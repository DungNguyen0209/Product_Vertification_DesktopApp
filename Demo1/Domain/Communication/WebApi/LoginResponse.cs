using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using ProductVertificationDesktopApp.Domain.Models.LoginApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Communication.WebApi
{
    public class LoginResponse
    {
        public Token Token { get; set; }
        public Employee Employee { get; set; }
    }
}
