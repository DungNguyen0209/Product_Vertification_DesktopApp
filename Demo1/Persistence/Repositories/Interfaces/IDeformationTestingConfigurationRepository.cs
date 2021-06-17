using ProductVertificationDesktopApp.Domain.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories.Interfaces
{
    public interface IDeformationTestingConfigurationRepository
    {
        void Insert(DeformationTestingConfigurations entry);
        void Clear();
        Task<IList<DeformationTestingConfigurations>> LoadConfigurations();
    }
}
