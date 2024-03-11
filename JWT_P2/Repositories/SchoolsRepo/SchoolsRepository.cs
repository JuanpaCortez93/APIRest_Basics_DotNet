using JWT_P2.Models;
using JWT_P2.SchoolDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JWT_P2.Repositories.SchoolsRepo
{
    public class SchoolsRepository : ISchoolsRepository
    {

        private SchoolMessageDatabaseContext _messageDatabaseContext;

        public SchoolsRepository(SchoolMessageDatabaseContext messageDatabaseContext)
        {
            _messageDatabaseContext = messageDatabaseContext;
        }

        public async Task<IEnumerable<Schools>> GetElementsFromRepository() => await _messageDatabaseContext.Schools.ToListAsync();

        public async Task<Schools> GetElementByIdFromRepository(Guid id) => await _messageDatabaseContext.Schools.FindAsync(id);

        public IEnumerable<Schools> GetElementByNameFromRepository(string name) => _messageDatabaseContext.Schools.Where(school => school.Name.ToUpper().Contains(name.ToUpper()));

        public async Task AddSchool(Schools school) => await _messageDatabaseContext.AddAsync(school);

        public void UpdateSchool(Schools school)
        {
            _messageDatabaseContext.Schools.Attach(school);
            _messageDatabaseContext.Schools.Entry(school).State = EntityState.Modified;
        }

        public void DeleteSchool(Schools school)
        {
            _messageDatabaseContext.Schools.Remove(school);
        }

        public async Task SaveAsync() => await _messageDatabaseContext.SaveChangesAsync();

    }
}
