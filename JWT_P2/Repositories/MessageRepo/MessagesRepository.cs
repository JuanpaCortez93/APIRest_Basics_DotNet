using JWT_P2.Models;
using JWT_P2.SchoolDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JWT_P2.Repositories.MessageRepo
{
    public class MessagesRepository : IMessagesRepository
    {
        private SchoolMessageDatabaseContext _schoolMessageDatabaseContext;

        public MessagesRepository
            (SchoolMessageDatabaseContext schoolMessageDatabaseContext)
        {
            _schoolMessageDatabaseContext = schoolMessageDatabaseContext;
        }

        public async Task<IEnumerable<Messages>> GetAllElementsFromRepository() => await _schoolMessageDatabaseContext.Messages.ToListAsync();

        public async Task<Messages> GetElementByIdFromRepository(Guid id) => await _schoolMessageDatabaseContext.Messages.FindAsync(id);

        public IEnumerable<Messages> GetElementByTitleFromRepository(string title) => _schoolMessageDatabaseContext.Messages.Where(message => message.Title.ToUpper().Contains(title.ToUpper())).ToList();

        public IEnumerable<Messages> GetElementByBodyFromRepository(string body) => _schoolMessageDatabaseContext.Messages.Where(message => message.Body.ToUpper().Contains(body.ToUpper())).ToList();

        public async Task AddElementToRepository(Messages message) => await _schoolMessageDatabaseContext.Messages.AddAsync(message);

        public void UpdateElementFromRepository(Messages message)
        {
            _schoolMessageDatabaseContext.Messages.Attach(message);
            _schoolMessageDatabaseContext.Messages.Entry(message).State = EntityState.Modified;
        }

        public void DeleteElementFromRepository(Messages messages) => _schoolMessageDatabaseContext.Messages.Remove(messages);

        public async Task SaveAsync() => await _schoolMessageDatabaseContext.SaveChangesAsync();

    }
}
