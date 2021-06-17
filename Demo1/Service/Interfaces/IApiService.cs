
using ProductVertificationDesktopApp.Domain.API;
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models.LoginApi;
using ProductVertificationDesktopApp.Domain.Models.Resource;
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
        Task<ServiceResponse> PostReliabilityReport(ReliabilityApiReport settingMachine);
        Task<ServiceResponse> PostDeformationReport(DeformationApiReport settingMachine);
        Task<ServiceResponse> PostReportSupervisor(ApiSupervisor settingMachine, string NameOfReport);
        Task<ServiceResourceResponse<QueryResult<ReliabilityApiReport>>> GetReliabilityReport(DateTime? startTime, DateTime? stopTime);
        Task<ServiceResourceResponse<QueryResult<DeformationApiReport>>> GetDeformationReport(DateTime? startTime, DateTime? stopTime);

    }
}
