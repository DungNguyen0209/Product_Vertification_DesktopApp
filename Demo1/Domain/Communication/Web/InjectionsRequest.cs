using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEp.Domain.Communication.Web
{
    public class InjectionsRequest
    {
        public DateTime ShiftDate { get; set; }
        public string MachineId { get; set; }
        public string InjectionMoldId { get; set; }
        public IEnumerable<EmployeePerformance> EmployeePerformance { get; set; }
    }
    public class EmployeePerformance
    {
        public double InjectCycleMilliseconds { get; set; }
        public double DoorOpeningTimeMilliseconds { get; set; }
        public DateTime Timeline { get; set; }
    }
}
