using ProductVertificationDesktopApp.Persistence.Repositories.Interfaces;
using ProductVertificationDesktopApp.Domain.Models.Resource;
using ProductVertificationDesktopApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories
{
    public class DeformationTestingSheetRepository: IDeformationTestingSheetRepository
    {
        private readonly ApplicationDbContext _context;

        public DeformationTestingSheetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void InsertDeformation(DeformationTestSheet entryreliability)
        {
            _context.deformationTestSheet.Add(entryreliability);
        }
        /*   public void InsertDeformation(TestSheet entrydeformation)
           {
               _context.testSheetDeformation.Add(entrydeformation);
           }*/
        public async Task<IEnumerable<DeformationTestSheet>> LoadDeformation()
        {
            return await _context.deformationTestSheet.ToListAsync();
        }
        /* public async Task<IEnumerable<TestSheet>> LoadDeformation()
         {
             return await _context.testSheetDeformation.ToListAsync();
         }*/
        public void ClearDeformation()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DeformationTestSheets]");
        }
        /*  public void ClearDeformation()
          {
              _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [testSheetDeformation]");
          }*/
    }
}
