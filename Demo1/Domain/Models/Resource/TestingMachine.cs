using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models.Resource
{
    public class TestingMachine
    {
        
        public string TestingMachineID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        // muc dich test
        public string Target { get; set; }
        public string ProductId { get; set; }
        // tieu chuan
        public string Standard { get; set; }
        // chu y khi target = khac
        public string Note { get; set; }
        public IList<TestSheet> Testsheet { get; set; }




    public void Clone(TestingMachine testingMachine)
        {
            this.Testsheet = testingMachine.Testsheet;
        }
    }
}
