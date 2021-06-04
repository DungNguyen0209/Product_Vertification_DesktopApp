using ProductVertificationDesktopApp.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Interface.Report
{
    public interface IViewReportDeformation
    {
        IList<ReportViewModel> Report { get; set; }
    }
}
