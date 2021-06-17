
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
    public class ReliabilityTestingSheetRepository: IReliabilityTestingSheetRepository
    {
        private readonly ApplicationDbContext _context;

        public ReliabilityTestingSheetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void InsertReliability(TestSheet entryreliability)
        {
            _context.ReliabilitytestSheet.Add(entryreliability);
        }

        public async Task<IEnumerable<TestSheet>> LoadReliability()
        {
            return await _context.ReliabilitytestSheet.ToListAsync();
        }

        public void ClearReliability()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [ReliabilityTestSheets]");
        }

    }
}
