using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.API
{
    public class ApiReportRiliability
    {
        // Ngay bat day
        public DateTime TimeStampStart { get; set; }
        // ngay ket thuc 
        public DateTime TimeStampFinish { get; set; }
        //Muc dich kiem tra
        public string Target { get; set; }
        // Ma san pham
        public string ProductCode { get; set; }
        // Tieu Chuan Thu Nghiem
        public string Standard { get; set; }
        // luu y khi muc dich kiem tra la khac
        public string Note { get; set; }
        public IList<ApiTestSheet> Testsheet { get; set; }
    }

    public class ApiTestSheet
    {
        //So Lan Thu
        public int  NumberTesting { get; set; }
        // Thoi gian dong em de
        public string TimeSmoothClosingLid { get; set; }
        // de khong roi ra
        public string StatusLidNotFall { get; set; }
        //de khong ro ri dau
        public string StatusLidNotLeak { get; set; }
        // ket qua danh gia de
        public string StatusLidResult { get; set; }
        // thoi gian dong em nap
        public string TimeSmoothClosingPlinth { get; set; }
        // chan nap khong roi ra
        public string StatusPlinthNotFall { get; set; }
        // chan nap khong ro ri dau
        public string StatusPlinthNotLeak { get; set; }
        // Ket qua danh gia nap
        public string StatusPlinthResult { get; set; }
        //Tong loi
        public string TotalMistake { get; set; }
        // Ghi chu
        public string Note { get; set; }
        // Nhan vien Kiem tra 
        public string StaffCheck { get; set; }
    }

}
