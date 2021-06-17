using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models.Resource
{
    public class DeformationTestSheet
    {
        public int TestSheetID { get; set; }
        public int NumberTesting { get; set; }
        public double TimeSmoothClosingLid { get; set; }
        public string StatusLidNotFall { get; set; }
        public string StatusLidNotLeak { get; set; }
        public string StatusLidResult { get; set; }
        public double TimeSmoothClosingPlinth { get; set; }
        public string StatusPlinthNotFall { get; set; }
        public string StatusPlinthNotLeak { get; set; }
        public string StatusPlinthResult { get; set; }
        public string TotalMistake { get; set; }
        public string Note { get; set; }
        public string StaffCheck { get; set; }
    }
}
