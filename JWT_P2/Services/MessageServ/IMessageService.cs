namespace JWT_P2.Services.MessageServ
{
    public interface IMessageService <TGetDTO, TPostDTO, TPutDTO>
    {
        Task<IEnumerable<TGetDTO>> GetMessages();
        Task<TGetDTO> GetMessagesById(Guid id);
        IEnumerable<TGetDTO> GetMessagesByTitle(string title);
        IEnumerable<TGetDTO> GetMessagesByBody(string body);
        Task<TGetDTO> AddMessages(TPostDTO postDTO);
        Task<TGetDTO> UpdateMessages(TPutDTO putDTO);
        Task<TGetDTO> DeleteMessage(Guid id);
    }
}
