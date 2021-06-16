using AutoMapper;
using ProductVertificationDesktopApp.Domain.API;
using ProductVertificationDesktopApp.Domain.Models.Resource;
using ProductVertificationDesktopApp.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Mapping
{
    public class MappingApi : Profile
    {
        public MappingApi()
        {
            CreateMap<TestSheet, ApiTestSheet>()
                .ForMember(des => des.Employee, act => act.MapFrom(src => src.StaffCheck))
                .ForMember(des => des.TotalError, act => act.MapFrom(src => src.TotalMistake));

            CreateMap<ApiTestSheet, TestSheet>()
                .ForMember(des => des.StaffCheck, act => act.MapFrom(src => src.Employee))
                .ForMember(des => des.TotalMistake, act => act.MapFrom(src => src.TotalError));


            CreateMap<TestingMachine, ApiReportRiliability>()
                .ForMember(des => des.ReliabilityTestSheet, act => act.MapFrom(src => src.Testsheet));

            CreateMap<ApiReportRiliability, TestingMachine>()
                .ForMember(des => des.Testsheet, act => act.MapFrom(src => src.ReliabilityTestSheet));


        }
    } 
}
