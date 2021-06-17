
using ProductVertificationDesktopApp.Domain.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories.Interfaces
{
    public interface IReliabilityTestingSheetRepository
    {
        //Task Update(TestingMachine entry);
        void InsertReliability(TestSheet entryreliability);
       // void InsertDeformation(TestSheet entrydeformation);
        Task<IEnumerable<TestSheet>> LoadReliability();
      //  Task<IEnumerable<TestSheet>> LoadDeformation();
        void ClearReliability();
        //void ClearDeformation();
    }
}
