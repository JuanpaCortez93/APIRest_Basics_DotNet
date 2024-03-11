using AutoMapper;
using JWT_P2.DTOs.Schools;
using JWT_P2.Models;

namespace JWT_P2.MappingProfiles
{
    public class SchoolsMappingProfile : Profile
    {
        public SchoolsMappingProfile() 
        {
            CreateMap<Schools, SchoolsGetDTO>();
            CreateMap<SchoolsPostDTO, Schools>();
            CreateMap<SchoolsPutDTO, Schools>();
        }
    }
}
