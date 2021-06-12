using ProductVertificationDesktopApp.Domain.Communication.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Views.Interface.Login
{
    public interface IViewLogin
    {
        string Username { get; set; }
        string Password { get; set; }
        event EventHandler LoginClick;
        void Alert(string message);
        void Success(string message);
    }
}
