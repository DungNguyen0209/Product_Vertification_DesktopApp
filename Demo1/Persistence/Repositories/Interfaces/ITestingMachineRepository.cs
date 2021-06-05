using ProductVertificationDesktopApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories.Interfaces
{
    public interface ITestingMachineRepository
    {
        Task Update(TestingMachine entry);
        void Insert(TestingMachine entry);
        Task<List<TestingMachine>> FindTest(DateTime dateTime);

    }
}
