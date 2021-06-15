
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
        void Insert(TestingConfigurations entry);
        void Clear();
        Task<IList<TestingConfigurations>> LoadConfigurations();
    }
}
