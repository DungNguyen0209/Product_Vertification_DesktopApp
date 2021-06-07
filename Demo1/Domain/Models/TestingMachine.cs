using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models
{
    public class TestingMachine
    {
        
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string EUnit { get; set; }
        public string Target { get; set; }
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
        public string StaffCheck {get;set;}


        public void Clone(TestingMachine testingMachine)
        {
            this.TimeStamp = testingMachine.TimeStamp;
            this.EUnit = testingMachine.EUnit;
            this.Target = testingMachine.Target;
            this.NumberTesting = testingMachine.NumberTesting;
            this.TimeSmoothClosingLid = testingMachine.TimeSmoothClosingLid;
            this.StatusLidNotFall = testingMachine.StatusLidNotFall;
            this.StatusLidNotLeak = testingMachine.StatusLidNotLeak;
            this.StatusLidResult = testingMachine.StatusLidResult;
            this.TimeSmoothClosingPlinth = testingMachine.TimeSmoothClosingPlinth;
            this.StatusPlinthNotFall = testingMachine.StatusPlinthNotFall;
            this.StatusPlinthNotLeak = testingMachine.StatusPlinthNotLeak;
            this.StatusPlinthResult = testingMachine.StatusPlinthResult;
            this.TotalMistake = testingMachine.TotalMistake;
            this.Note = testingMachine.Note;
            this.StaffCheck = testingMachine.StaffCheck;
        }

    }
}
