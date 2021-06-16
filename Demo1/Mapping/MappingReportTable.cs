using AutoMapper;
using ProductVertificationDesktopApp.Domain.Models.Resource;
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
            CreateMap<ReportViewModel, TestSheet>()
                .ReverseMap()
                .ForMember(dest => dest.NumberTesting, expression => expression.MapFrom(src => Convert.ToInt32(src.NumberTesting)))
                .ForMember(dest => dest.TimeSmoothClosingLid, expression => expression.MapFrom(src => Convert.ToDouble(src.TimeSmoothClosingLid)))
                .ForMember(dest => dest.TimeSmoothClosingPlinth, expression => expression.MapFrom(src => Convert.ToDouble(src.TimeSmoothClosingPlinth)));


        }
    }
}
