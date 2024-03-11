using JWT_P2.Models;

namespace JWT_P2.Repositories.MessageRepo
{
    public interface IMessagesRepository
    {
        Task<IEnumerable<Messages>> GetAllElementsFromRepository();
        Task<Messages> GetElementByIdFromRepository(Guid id);
        IEnumerable<Messages> GetElementByTitleFromRepository(string title);
        IEnumerable<Messages> GetElementByBodyFromRepository(string body);
        Task AddElementToRepository(Messages message);
        void UpdateElementFromRepository(Messages message);
        void DeleteElementFromRepository(Messages messages);
        Task SaveAsync();

    }
}
