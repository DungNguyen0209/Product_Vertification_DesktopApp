using AutoMapper;
using Newtonsoft.Json;
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Communication.WebApi;
using ProductVertificationDesktopApp.Domain.Models.LoginApi;
using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service
{
    public class ApiService: IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private const string serverUrl = "https://phong-kiem-tra-chat-luong-sp.herokuapp.com";
        private string token = "";
        public bool EndShiftStatus { get; set; } = false;
        public event Action<bool> StatusEndShift;


        public ApiService(IMapper mapper)
        {
            _httpClient = new HttpClient();
            _mapper = mapper;
        }
        public async Task<ServiceResourceResponse<Employee>> LogInAsync(string username, string password)
        {
            ServiceResourceResponse<Employee> result;

            var loginCredential = new LoginRequest(username, password);
            var json = JsonConvert.SerializeObject(loginCredential);

            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"{serverUrl}/api/auth";
                var response = await _httpClient.PostAsync(url, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

                        token = loginResponse.Token.AuthToken;
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        result = new ServiceResourceResponse<Employee>(loginResponse.Employee);
                        return result;
                    case HttpStatusCode.BadRequest:
                        var error = new Error("Api.Login", "Tên đăng nhập hoặc mật khẩu không hợp lệ.");
                        result = new ServiceResourceResponse<Employee>(error);
                        return result;
                    default:
                        error = new Error("Api.Login", "Đã có lỗi xảy ra. Không thể thực hiện đăng nhập.");
                        result = new ServiceResourceResponse<Employee>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<Employee>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Login", $"Đã có lỗi xảy ra. Không thể thực hiện đăng nhập vì: {ex.Message}");
                result = new ServiceResourceResponse<Employee>(error);
                return result;
            }
            return result;
        }

        public void LogOut()
        {
            token = "";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }       
    }
}
