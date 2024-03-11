using AutoMapper;
using JWT_P2.DTOs.ParentDetails;
using JWT_P2.DTOs.Parents;
using JWT_P2.Models;

namespace JWT_P2.MappingProfiles
{
    public class ParentsMappingProfile : Profile
    {
        public ParentsMappingProfile() 
        {
            CreateMap<Parents, ParentsGetDTO>();
            CreateMap<ParentsPostDTO, Parents>();
            CreateMap<ParentsPutDTO, Parents>();
        }
    }
}
