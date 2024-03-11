using AutoMapper;
using JWT_P2.DTOs.Messages;
using JWT_P2.Models;
using JWT_P2.Repositories.MessageRepo;

namespace JWT_P2.Services.MessageServ
{
    public class MessagesService : IMessageService<MessagesGetDTO, MessagesPostDTO, MessagesPutDTO>
    {

        private IMessagesRepository _messageRepository;
        private IMapper _messageMappingProfile;

        public MessagesService([FromKeyedServices("messageRepository")]IMessagesRepository messageRepository, IMapper messageMappingProfile) 
        {
            _messageRepository = messageRepository;
            _messageMappingProfile = messageMappingProfile;
        }

        public async Task<IEnumerable<MessagesGetDTO>> GetMessages()
        {
            var messages = await _messageRepository.GetAllElementsFromRepository();
            var messagesDTO = messages.Select(message => _messageMappingProfile.Map<MessagesGetDTO>(message));
            return messagesDTO;
        }

        public async Task<MessagesGetDTO> GetMessagesById(Guid id)
        {
            var message = await _messageRepository.GetElementByIdFromRepository(id);
            if (message == null) return null;

            var messageDTO = _messageMappingProfile.Map<MessagesGetDTO>(message);
            return messageDTO;
        }

        public IEnumerable<MessagesGetDTO> GetMessagesByTitle(string title)
        {
            var messages = _messageRepository.GetElementByTitleFromRepository(title);
            if (messages == null) return null;

            var messageDTO = messages.Select(mess => _messageMappingProfile.Map<MessagesGetDTO>(mess));
            return messageDTO;
        }

        public IEnumerable<MessagesGetDTO> GetMessagesByBody(string body)
        {
            var messages = _messageRepository.GetElementByBodyFromRepository(body);
            if (messages == null) return null;

            var messagesDTO = messages.Select(mess => _messageMappingProfile.Map<MessagesGetDTO>(mess));
            return messagesDTO;
        }

        public async Task<MessagesGetDTO> AddMessages(MessagesPostDTO postDTO)
        {
            var message = _messageMappingProfile.Map<Messages>(postDTO);
            await _messageRepository.AddElementToRepository(message);
            await _messageRepository.SaveAsync();
            var messageDTO = _messageMappingProfile.Map<MessagesGetDTO>(message);
            return messageDTO;
        }

        public async Task<MessagesGetDTO> UpdateMessages(MessagesPutDTO putDTO)
        {
            var message = await _messageRepository.GetElementByIdFromRepository(putDTO.Id);
            if (message == null) return null;

            message = _messageMappingProfile.Map<MessagesPutDTO, Messages>(putDTO, message);

            _messageRepository.UpdateElementFromRepository(message);
            await _messageRepository.SaveAsync();

            var messageDTO = _messageMappingProfile.Map<MessagesGetDTO>(message);
            return messageDTO;
        }

        public async Task<MessagesGetDTO> DeleteMessage(Guid id)
        {
            var message = await _messageRepository.GetElementByIdFromRepository(id);
            if (message == null) return null;

            _messageRepository.DeleteElementFromRepository(message);
            await _messageRepository.SaveAsync();

            var messageDTO = _messageMappingProfile.Map<MessagesGetDTO>(message);
            return messageDTO;
        }
    }
}
