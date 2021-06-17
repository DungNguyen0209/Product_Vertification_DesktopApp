
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
        Task<ServiceResponse> InsertReliabilityTestingConfigurations(ReliabilityTestingConfigurations testingConfigurations);
        Task<ServiceResponse> ClearReliabilityConfiguration();
        Task<IList<ReliabilityTestingConfigurations>> LoadAllReliabilityConfiguration();
        Task<ServiceResponse> InsertReliability(TestSheet entry);
       // Task<ServiceResponse> InsertDeformation(TestSheet entry);
        Task<IEnumerable<TestSheet>> LoadReliability();
       // Task<IEnumerable<TestSheet>> LoadDeformation();
        Task<ServiceResponse> ClearReliability();
        //  Task<ServiceResponse> ClearDeformation();
        Task<ServiceResponse> ClearDeformationConfiguration();
        Task<ServiceResponse> InsertDeformationTestingConfigurations(DeformationTestingConfigurations deformatiotestingConfigurations);
        Task<IList<DeformationTestingConfigurations>> LoadAllDeformationConfiguration();
        Task<ServiceResponse> InsertDeformation(DeformationTestSheet entry);
        Task<IEnumerable<DeformationTestSheet>> LoadDeformation();
        Task<ServiceResponse> ClearDeformation();

        }
}
