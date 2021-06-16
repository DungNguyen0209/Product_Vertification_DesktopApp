using AutoMapper;
using Newtonsoft.Json;
using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.API;
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
        public async Task<ServiceResponse> PostReportRiliability(ApiReportRiliability settingMachine)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(settingMachine);

            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"{serverUrl}/api/reportreliability";
                var response = await _httpClient.PostAsync(url, content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        //EndShiftStatus = true;
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.SettingMachine.Post", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.SettingMachine.Post", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.SettingMachine.Post", "Đã có lỗi xảy ra.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<Employee>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.SettingMachine.Post", $"Đã có lỗi xảy ra. Không thể gửi dữ liệu về server được vì: {ex.Message}");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }

        public async Task<ServiceResponse> PostReportSupervisorRiliability(ApiSupervisorReliability settingMachine)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(settingMachine);

            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"{serverUrl}/api/monitorreliability";
                var response = await _httpClient.PostAsync(url, content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        //EndShiftStatus = true;
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.SettingMachine.Post", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.SettingMachine.Post", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.SettingMachine.Post", "Đã có lỗi xảy ra.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<Employee>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.SettingMachine.Post", $"Đã có lỗi xảy ra. Không thể gửi dữ liệu về server được vì: {ex.Message}");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }

        public async Task<ServiceResourceResponse<QueryResult<ApiReportRiliability>>> GetReportRiliability(DateTime? startTime, DateTime? stopTime)
        {
            ServiceResourceResponse<QueryResult<ApiReportRiliability>> result;
            string queryString = "";
            if (startTime != null)
            {
                string startTimestring = startTime.Value.ToString("yyyy-MM-dd");
                queryString += "&StartTime=" + startTimestring;
            }
            if (stopTime != null && startTime.Value.Date != stopTime.Value.Date)
            {
                string stopTimestring = stopTime.Value.ToString("yyyy-MM-dd");
                queryString += "&StopTime=" + stopTimestring;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/reportreliability/?Page=1&ItemsPerPage=10" + queryString);
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var reportRiliability = JsonConvert.DeserializeObject<QueryResult<ApiReportRiliability>>(responseBody);
                        result = new ServiceResourceResponse<QueryResult<ApiReportRiliability>>(reportRiliability);
                        return result;
                    default:
                        var error = new Error("Api.Product.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<QueryResult<ApiReportRiliability>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<QueryResult<ApiReportRiliability>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Product.Get", $"Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server vì: {ex.Message}");
                result = new ServiceResourceResponse<QueryResult<ApiReportRiliability>>(error);
                return result;
            }
            return result;
        }
    }
}
