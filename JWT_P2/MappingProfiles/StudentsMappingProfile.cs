using AutoMapper;
using JWT_P2.DTOs.Students;
using JWT_P2.Models;

namespace JWT_P2.MappingProfiles
{
    public class StudentsMappingProfile : Profile
    {
        public StudentsMappingProfile() 
        {
            CreateMap<Students, StudentsGetDTO>();
            CreateMap<StudentsPostDTO, Students>();
            CreateMap<StudentsPutDTO, Students>();
        }
    }
}
