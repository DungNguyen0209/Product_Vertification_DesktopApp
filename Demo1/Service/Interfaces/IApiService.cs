
using ProductVertificationDesktopApp.Domain.API;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models.LoginApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service.Interfaces
{
    public interface IApiService
    {
        Task<ServiceResourceResponse<Employee>> LogInAsync(string username, string password);
        void LogOut();
        Task<ServiceResponse> PostReportRiliability(ApiReportRiliability settingMachine);
        Task<ServiceResponse> PostReportSupervisorRiliability(ApiSupervisorReliability settingMachine);
        Task<ServiceResourceResponse<QueryResult<ApiReportRiliability>>> GetReportRiliability(DateTime? startTime, DateTime? stopTime);
    }
}
