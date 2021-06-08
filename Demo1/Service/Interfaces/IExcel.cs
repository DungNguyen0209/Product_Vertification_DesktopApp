using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service.Interfaces
{
    public interface IExcel
    {
        Task<ServiceResponse> Exportdata(string path, List<TestingMachine> testingMachine);
    }
}
