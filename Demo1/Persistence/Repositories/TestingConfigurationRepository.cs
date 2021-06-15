
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
    public class TestingConfigurationRepository:ITestingConfigurationRepository
    {
        private readonly ApplicationDbContext _context;

        public TestingConfigurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void Insert(TestingConfigurations entry)
        {
            _context.TestingConfigurations.Add(entry);
        }
        
        public void Clear()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TestingConfigurations]");
        }

        public async Task<IList<TestingConfigurations>> LoadConfigurations()
        {
            return await _context.TestingConfigurations.ToListAsync();
        }

    }
}
