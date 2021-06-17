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
            //Reliability
            CreateMap<TestSheet, ApiTestSheet>()
                .ForMember(des => des.Employee, act => act.MapFrom(src => src.StaffCheck))
                .ForMember(des => des.TotalError, act => act.MapFrom(src => src.TotalMistake));

            CreateMap<ApiTestSheet, TestSheet>()
                .ForMember(des => des.StaffCheck, act => act.MapFrom(src => src.Employee))
                .ForMember(des => des.TotalMistake, act => act.MapFrom(src => src.TotalError));


            CreateMap<TestingMachine, ReliabilityApiReport>()
                .ForMember(des => des.ReliabilityTestSheet, act => act.MapFrom(src => src.Testsheet));

            CreateMap<ReliabilityApiReport, TestingMachine>()
                .ForMember(des => des.Testsheet, act => act.MapFrom(src => src.ReliabilityTestSheet));



            //Deformation
            CreateMap<TestSheet, DeformationApiTestSheet>()
                .ForMember(des => des.StatusPlinthNotBreak, act => act.MapFrom(src => src.StatusPlinthNotFall))
                .ForMember(des => des.StatusLidNotBreak, act => act.MapFrom(src => src.StatusLidNotFall))
                .ForMember(des => des.Employee, act => act.MapFrom(src => src.StaffCheck))
                .ForMember(des => des.TotalError, act => act.MapFrom(src => src.TotalMistake));


            CreateMap<DeformationApiTestSheet, TestSheet>()
                .ForMember(des => des.StatusLidNotFall, act => act.MapFrom(src => src.StatusLidNotBreak))
                .ForMember(des => des.StatusPlinthNotFall, act => act.MapFrom(src => src.StatusPlinthNotBreak))
                .ForMember(des => des.StaffCheck, act => act.MapFrom(src => src.Employee))
                .ForMember(des => des.TotalMistake, act => act.MapFrom(src => src.TotalError));

            CreateMap<TestingMachine, DeformationApiReport>()
                .ForMember(des => des.DeformationTestSheet, act => act.MapFrom(src => src.Testsheet));

            CreateMap<DeformationApiReport, TestingMachine>()
                .ForMember(des => des.Testsheet, act => act.MapFrom(src => src.DeformationTestSheet));
        }
    } 
}
