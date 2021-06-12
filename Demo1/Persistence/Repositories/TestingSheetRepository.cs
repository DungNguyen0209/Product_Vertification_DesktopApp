
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
    public class TestingSheetRepository: ITestingSheetRepository
    {
        private readonly ApplicationDbContext _context;

        public TestingSheetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void InsertReliability(TestSheet entryreliability)
        {
            _context.testSheetReliability.Add(entryreliability);
        }
     /*   public void InsertDeformation(TestSheet entrydeformation)
        {
            _context.testSheetDeformation.Add(entrydeformation);
        }*/
        public async Task<IEnumerable<TestSheet>> LoadReliability()
        {
            return await _context.testSheetReliability.ToListAsync();
        }
       /* public async Task<IEnumerable<TestSheet>> LoadDeformation()
        {
            return await _context.testSheetDeformation.ToListAsync();
        }*/
        public void ClearReliability()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TestSheets]");
        }
      /*  public void ClearDeformation()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [testSheetDeformation]");
        }*/

    }
}
