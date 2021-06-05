using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service.Interfaces
{
    public interface IDatabaseService
    {
        Task<ServiceResponse> UpdateConfigurationEntry(TestingConfigurations entry);
        Task<ServiceResponse> InsertTestingConfigurations(TestingConfigurations testingConfigurations);
        Task<ServiceResponse> DeleteReportShift(TestingConfigurations testingConfigurations);
        Task<ServiceResponse> ClearConfiguration();
        Task<IEnumerable<TestingConfigurations>> LoadAllConfiguration();
        Task<ServiceResourceResponse<TestingConfigurations>> FindTestId(string machineId);

    }
}
