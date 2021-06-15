
using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service.Interfaces
{
    public interface IDatabaseService
    {
        Task<ServiceResponse> InsertTestingConfigurations(TestingConfigurations testingConfigurations);
        Task<ServiceResponse> ClearConfiguration();
        Task<IList<TestingConfigurations>> LoadAllConfiguration();
        Task<ServiceResponse> InsertReliability(TestSheet entry);
       // Task<ServiceResponse> InsertDeformation(TestSheet entry);
        Task<IEnumerable<TestSheet>> LoadReliability();
       // Task<IEnumerable<TestSheet>> LoadDeformation();
        Task<ServiceResponse> ClearReliability();
      //  Task<ServiceResponse> ClearDeformation();
    }
}
