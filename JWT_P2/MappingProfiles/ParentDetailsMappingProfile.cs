using AutoMapper;
using JWT_P2.DTOs.ParentDetails;
using JWT_P2.Models;

namespace JWT_P2.MappingProfiles
{
    public class ParentDetailsMappingProfile : Profile
    {
        public ParentDetailsMappingProfile()
        {
            CreateMap<ParentDetails, ParentDetailsGetDTO>();
            CreateMap<ParentDetailsPostDTO, ParentDetails>();
            CreateMap<ParentDetailsPutDTO, ParentDetails>();
        }
    }
}
