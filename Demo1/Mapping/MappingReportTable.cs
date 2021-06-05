using AutoMapper;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Mapping
{
    public class MappingReportTable : Profile
    {
        public MappingReportTable()
        {
            CreateMap<ReportViewModel, TestingMachine>();
        }
    }
}
