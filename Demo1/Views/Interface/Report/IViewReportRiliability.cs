using ProductVertificationDesktopApp.Domain.Communication;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Views.Interface.Report
{
    public interface IViewReportRiliability
    {
        event EventHandler Insert;
        event EventHandler LoadFromDatabase;
        void SuccessExcel(string s);
        ETargetTest eTargetTest { get; set; }
        IList<ReportViewModel> Report { get; set; }
    }
}
