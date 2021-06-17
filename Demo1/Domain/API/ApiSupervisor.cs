using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Domain.API
{
    public class ApiSupervisor


    {
        //SolandongnapCaidat
        public int NumberClosingSp { get; set; }
        //SolanDongNapHientai
        public int NumberClosingPv { get; set; }
        //thoigiangiunapmo
        public int TimeLidClose { get; set; }
        // thoigiangiunapdong
        public int TimeLidOpen { get; set; }
        public bool Running { get; set; }
        public bool Warning { get; set; }
    }
}
