using AutoMapper;
using Student_Management.Dto;
using Student_Management.Models;

namespace Student_Management.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TbUser, DtoUser>();
            CreateMap<TbCourse, DtoCourse>();
            CreateMap<TbStudent, DtoStudent>();
            CreateMap<TbDetail, DtoDetail>();
        }
    }
}
