using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service.Interfaces
{
    public interface IModelingMachine
    {
        void Send2Bytes(Int16 data,int offset);
        void Send4byte(Int32 data,int offset);
        List<Action<bool>> UpdateData { get; set; }
        Int16 TimeStart { get; set; }
        Int16 TimeStop { get; set; }
        Int32 TimeNumber { get; set; }
    }
}
