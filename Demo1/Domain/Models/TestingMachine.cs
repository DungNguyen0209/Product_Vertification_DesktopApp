using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.Models
{
    public class TestingMachine
    {
        

        public DateTime TimeStamp { get; set; }
        public EUnit EUnit { get; set; }
        public ETargetTest? Target { get; set; }
        public string NumberTesting { get; set; }
        public int? TimeSmoothClosingLid { get; set; }
        public bool? StatusLidNotFall { get; set; }
        public bool? StatusLidNotLeak { get; set; }
        public bool? StatusLidResult { get; set; }
        public int? TimeSmoothClosingPlinth { get; set; }
        public bool? StatusPlinthNotFall { get; set; }
        public bool? StatusPlinthNotLeak { get; set; }
        public bool? StatusPlinthResult { get; set; }
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
