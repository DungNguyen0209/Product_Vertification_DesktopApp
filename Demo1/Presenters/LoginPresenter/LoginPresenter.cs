
using ProductVertificationDesktopApp.Service.Interfaces;
using ProductVertificationDesktopApp.Views.Interface.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Presenters.LoginPresenter
{
    public class LoginPresenter
    {
        private readonly IViewLogin _iviewLogin;
        private readonly IApiService _apiService;

        public LoginPresenter(IViewLogin iviewLogin, IApiService apiService)
        {
            _iviewLogin = iviewLogin;
            _apiService = apiService;
            _iviewLogin.LoginClick += Login;
        }
        private async void  Login (object sender, EventArgs e)
        {
            var result = await _apiService.LogInAsync (_iviewLogin.Username, _iviewLogin.Password);
            if (result.Success)
            {
                _iviewLogin.Success("Đăng nhập thành công");
            }
            else
            {
                _iviewLogin.Alert(result.Error.Message);
            }
        }
    }
}
