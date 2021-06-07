using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.ViewModel
{
    public class ReportViewModel
    {
        [DisplayName("Số lần thử")]
        public string NumberTesting { get; set; }

        [DisplayName("Thời gian nắp đóng êm")]
        public string TimeSmoothClosingLid { get; set; }

        [DisplayName("Chân nắp không rơi ra")]
        public string StatusLidNotFall  { get; set; }
        [DisplayName("Không rò rỉ dầu")]
        public string StatusLidNotLeak { get; set; }

        [DisplayName("Kết quả đánh giá")]
        public string StatusLidResult { get; set; }

        [DisplayName("Thời gian đế đóng êm")]
        public string TimeSmoothClosingPlinth { get; set; }

        [DisplayName("Chân đế không rơi")]
        public string StatusPlinthNotFall { get; set; }
        [DisplayName("Không rò rỉ")]
        public string StatusPlinthNotLeak { get; set; }

        [DisplayName("Kết quả đánh giá")]
        public string StatusPlinthResult { get; set; }

        [DisplayName("Tổng lỗi")]
        public string TotalMistake { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }

        [DisplayName("Nhân viên KT")]
        public string StaffCheck { get; set; }
    }
}
