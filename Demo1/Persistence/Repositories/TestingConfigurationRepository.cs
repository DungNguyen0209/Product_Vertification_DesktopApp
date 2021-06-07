using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductVertificationDesktopApp.Persistence.Repositories.Interfaces;

namespace ProductVertificationDesktopApp.Persistence
{
    public class TestingConfigurationRepository:ITestingConfigurationRepository
    {
        private readonly ApplicationDbContext _context;

        public TestingConfigurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Update(TestingConfigurations entry)
        {
            var existingEntry = await _context.TestingConfigurations.FindAsync(entry.TestID);
            existingEntry.Clone(entry);
        }
        public void Insert(TestingConfigurations entry)
        {
            _context.TestingConfigurations.Add(entry);
        }
        public async Task Delete(TestingConfigurations entry)
        {
            var data = await (from p in _context.TestingConfigurations where (p.TestID == entry.TestID) select p).FirstOrDefaultAsync();
             _context.TestingConfigurations.Remove(data);
        }
        public void Clear()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TestingConfigurations]");
        }

        public async Task<IEnumerable<TestingConfigurations>> Load()
        {
            return await _context.TestingConfigurations.ToListAsync();
        }
        public async Task<List<TestingConfigurations>> FindTestId(string TestName)
        {
            var data = await _context.TestingConfigurations.ToListAsync();
            data = await (from p in _context.TestingConfigurations
                          where ( p.TestName== TestName)
                          select p
                         )
                        .ToListAsync();
            return data;
        }

    }
}
