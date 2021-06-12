using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models.Resource
{
    public class TestingConfigurations
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public int? NumberClosingSetting { get; set; }
        public int? NumberClosingCurrent { get; set; }
        public Int16? TimeHoldingCloseSP { get; set; }
        public Int16? TimeHoldingOpenSP { get; set; }

        public void Clone(TestingConfigurations configuration)
        {
            this.TestID = configuration.TestID;
            this.NumberClosingSetting = configuration.NumberClosingSetting;
            this.NumberClosingCurrent = configuration.NumberClosingCurrent;
            this.TimeHoldingCloseSP = configuration.TimeHoldingCloseSP;
            this.TimeHoldingOpenSP = configuration.TimeHoldingOpenSP;
        }
    }
}

