
using ProductVertificationDesktopApp.Domain.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories.Interfaces
{
    public interface IReliabilityTestingConfigurationRepository
    {
        void Insert(ReliabilityTestingConfigurations entry);
        void Clear();
        Task<IList<ReliabilityTestingConfigurations>> LoadConfigurations();
    }
}
