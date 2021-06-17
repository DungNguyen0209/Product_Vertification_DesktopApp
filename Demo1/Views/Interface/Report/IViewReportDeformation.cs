using ProductVertificationDesktopApp.Domain.Communication;
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

        event EventHandler Insert;
        event EventHandler ImportData;
        event EventHandler FormLoad;
        event EventHandler FormClose;
        void SuccessExcel(string s);
        DateTime TimeStampStart { get; set; }
        DateTime TimeStampFinish { get; set; }
        int eTargetTest { get; set; }
        String NameProduct { get; set; }
        String Comment { get; set; }
        IList<ReportViewModel> Report { get; set; }
        Task<ServiceResponse> ConfirmExport();
    }
}
