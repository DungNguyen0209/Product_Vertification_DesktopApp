using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models.Resource
{
    public class TestSheet
    {
        public int TestSheetID { get; set; }
        public string NumberTesting { get; set; }
        public string TimeSmoothClosingLid { get; set; }
        public string StatusLidNotFall { get; set; }
        public string StatusLidNotLeak { get; set; }
        public string StatusLidResult { get; set; }
        public string TimeSmoothClosingPlinth { get; set; }
        public string StatusPlinthNotFall { get; set; }
        public string StatusPlinthNotLeak { get; set; }
        public string StatusPlinthResult { get; set; }
        public string TotalMistake { get; set; }
        public string Note { get; set; }
        public string StaffCheck { get; set; }
    }
}
