
using ProductVertificationDesktopApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductVertificationDesktopApp.Persistence.Repositories.Interfaces;
using ProductVertificationDesktopApp.Domain.Models.Resource;

namespace ProductVertificationDesktopApp.Persistence
{
    public class ReliabilityTestingConfigurationRepository:IReliabilityTestingConfigurationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReliabilityTestingConfigurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void Insert(ReliabilityTestingConfigurations entry)
        {
            _context.ReliabilityTestingConfigurations.Add(entry);
        }
        
        public void Clear()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [ReliabilityTestingConfigurations]");
        }

        public async Task<IList<ReliabilityTestingConfigurations>> LoadConfigurations()
        {
            return await _context.ReliabilityTestingConfigurations.ToListAsync();
        }

    }
}
