using AutoMapper;
using JWT_P2.DTOs.Messages;
using JWT_P2.Models;

namespace JWT_P2.MappingProfiles
{
    public class MessagesMappingProfile : Profile
    {
        public MessagesMappingProfile()
        {
            CreateMap<Messages, MessagesGetDTO>();
            CreateMap<MessagesPostDTO, Messages>();
            CreateMap<MessagesPutDTO, Messages>();
        }
    }
}
