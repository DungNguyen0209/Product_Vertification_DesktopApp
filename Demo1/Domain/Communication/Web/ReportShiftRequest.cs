using MayEp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEp.Domain.Communication.Web
{
    public class ReportShiftRequest
    {
        public DateTime Date { get; set; }
        public EShiftNumber ShiftNumber { get; set; }
        public string EmployeeId { get; set; }
        public string MachineId { get; set; }
        public string MoldId { get; set; }
        public string ProductId { get; set; }
        public EUnit Unit { get; set; }
        public double TotalQuantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public TimeSpan WorkTime { get; set; }
        public TimeSpan PauseTime { get; set; }
        public string Note { get; set; }
    }
}
