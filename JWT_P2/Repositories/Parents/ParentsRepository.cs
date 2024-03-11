
using JWT_P2.Models;
using JWT_P2.SchoolDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JWT_P2.Repositories.Parents
{
    public class ParentsRepository : JWT_P2.Repositories.Parents.IParentsRepo
    {

        private SchoolMessageDatabaseContext _schoolMessageDbContext;

        public ParentsRepository(SchoolMessageDatabaseContext schoolMessageDbContext) 
        {
            _schoolMessageDbContext = schoolMessageDbContext;
        }

        public async Task<IEnumerable<Models.Parents>> GetElementsFromRepository() => await _schoolMessageDbContext.Parents.ToListAsync();

        public async Task<Models.Parents> GetElementFromRepositoryById(Guid id) => await _schoolMessageDbContext.Parents.FindAsync(id);

        public async Task AddElementFromRepository(Models.Parents t) => await _schoolMessageDbContext.Parents.AddAsync(t);

        public void UdpateElementFromRepository(Models.Parents t)
        {
            _schoolMessageDbContext.Parents.Attach(t);
            _schoolMessageDbContext.Parents.Entry(t).State = EntityState.Modified;
        }

        public void DeleteElementFromRepository(Models.Parents t) => _schoolMessageDbContext.Parents.Remove(t);

        public async Task Save() => await _schoolMessageDbContext.SaveChangesAsync();
    }
}
