using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models.Resource
{
    public class ReliabilityTestingConfigurations
    {
        public string TestingMachineID { get; set; }
        public DateTime TimeStampStart { get; set; }
        public DateTime TimeStampFinish { get; set; }
        // muc dich test
        public int Target { get; set; }
        public string ProductCode { get; set; }
        // chu y khi target = khac
        public string Note { get; set; }
    }
}

