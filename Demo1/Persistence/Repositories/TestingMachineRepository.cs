








using ProductVertificationDesktopApp.Domain.Models;
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
    public class TestingMachineRepository: ITestingMachineRepository
    {
        private readonly ApplicationDbContext _context;

        public TestingMachineRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Update(TestingMachine entry)
        {
            var existingEntry = await _context.testingMachines.FindAsync(entry.TimeStamp);
            existingEntry.Clone(entry);
        }
        public void Insert(TestingMachine entry)
        {
            _context.testingMachines.Add(entry);
        }
        public async Task<List<TestingMachine>> FindTest(DateTime dateTime)
        {
            var data = await _context.testingMachines.ToListAsync();
            data = await (from p in _context.testingMachines
                          where (p.TimeStamp == dateTime)
                          select p
                         )
                        .ToListAsync();
            return data;
        }

    }
}
