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
        IList<ReportViewModel> Report { get; set; }
    }
}
