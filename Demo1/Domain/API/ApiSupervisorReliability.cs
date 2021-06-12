using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.API
{
    public class ApiSupervisorReliability
    {
        //SolandongnapCaidat
        public int NumberClosingLidSP { get; set; }
        //SolanDongNapHientai
        public int NumberClosingLidCurrent { get; set; }
        //thoigiangiunapmo
        public int TimeOpeningLid { get; set; }
        // thoigiangiunapdong
        public int TimeClosingPlithTimeOpeningLid { get; set; }
    }
}
