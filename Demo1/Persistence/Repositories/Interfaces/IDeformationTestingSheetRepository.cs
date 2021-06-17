using ProductVertificationDesktopApp.Domain.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories.Interfaces
{
    public interface IDeformationTestingSheetRepository
    {//Task Update(TestingMachine entry);
        void InsertDeformation(DeformationTestSheet entryreliability);
        // void InsertDeformation(TestSheet entrydeformation);
        Task<IEnumerable<DeformationTestSheet>> LoadDeformation();
        //  Task<IEnumerable<TestSheet>> LoadDeformation();
        void ClearDeformation();
        //void ClearDeformation();
    }
}
