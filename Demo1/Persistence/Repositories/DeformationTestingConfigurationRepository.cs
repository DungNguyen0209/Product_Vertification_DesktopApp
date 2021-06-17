using ProductVertificationDesktopApp.Domain.Models.Resource;
using ProductVertificationDesktopApp.Persistence.Contexts;
using ProductVertificationDesktopApp.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories
{
    public class DeformationTestingConfigurationRepository: IDeformationTestingConfigurationRepository
    {
        private readonly ApplicationDbContext _context;
        public DeformationTestingConfigurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Insert(DeformationTestingConfigurations entry)
        {
            _context.DeformationTestingConfigurations.Add(entry);
        }

        public void Clear()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DeformationTestingConfigurations]");
        }

        public async Task<IList<DeformationTestingConfigurations>> LoadConfigurations()
        {
            return await _context.DeformationTestingConfigurations.ToListAsync();
        }
    }
}
