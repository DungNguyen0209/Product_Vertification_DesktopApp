
using ProductVertificationDesktopApp.Domain.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories.Interfaces
{
    public interface ITestingConfigurationRepository
    {
        Task Update(TestingConfigurations entry);
        void Insert(TestingConfigurations entry);
        Task Delete(TestingConfigurations entry);
        void Clear();
        Task<IEnumerable<TestingConfigurations>> Load();
        Task<List<TestingConfigurations>> FindTestId(string TestId);

    }
}
