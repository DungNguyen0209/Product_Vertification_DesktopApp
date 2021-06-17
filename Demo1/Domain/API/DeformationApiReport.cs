using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.API
{
    public class DeformationApiReport
    {
        public DateTime StartTime { get; set; }
        // ngay ket thuc 
        public DateTime StopTime { get; set; }
        //Muc dich kiem tra
        public string Target { get; set; }
        // Ma san pham
        public string ProductId { get; set; }
        // Tieu Chuan Thu Nghiem
        public string Standard { get; set; }
        // luu y khi muc dich kiem tra la khac
        //public string Note { get; set; }
        public IList<DeformationApiTestSheet> DeformationTestSheet { get; set; }
    }

    public class DeformationApiTestSheet
    {
        public int NumberTesting { get; set; }
        public double TimeSmoothClosingLid { get; set; }
        public string StatusLidNotBreak { get; set; }
        public string StatusLidNotLeak { get; set; }
        public string StatusLidResult { get; set; }
        public double TimeSmoothClosingPlinth { get; set; }
        public string StatusPlinthNotBreak { get; set; }
        public string StatusPlinthNotLeak { get; set; }
        public string StatusPlinthResult { get; set; }
        public string TotalError { get; set; }
        public string Note { get; set; }
        public string Employee { get; set; }
    }
}

