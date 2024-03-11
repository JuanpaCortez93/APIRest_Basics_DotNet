using JWT_P2.DTOs.Students;
using JWT_P2.MappingProfiles;
using JWT_P2.Models;
using JWT_P2.SchoolDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JWT_P2.Repositories.Students
{
    public class StudentsRepository : IStudentsRepo<JWT_P2.Models.Students>
    {
        private SchoolMessageDatabaseContext _schoolDabaseContext;

        public StudentsRepository(SchoolMessageDatabaseContext schoolDabaseContext) 
        {   
            _schoolDabaseContext = schoolDabaseContext;
        }

        public async Task<IEnumerable<Models.Students>> GetElementsFromRepository() => await _schoolDabaseContext.Students.ToListAsync();

        public async Task<Models.Students> GetElementFromRepositoryById(Guid id) => await _schoolDabaseContext.Students.FindAsync(id);

        public IEnumerable<Models.Students> GetElementByName(string name) => _schoolDabaseContext.Students.Where(student => student.FirstName.ToUpper().Contains(name.ToUpper()));

        public async Task AddElementFromRepository(Models.Students t) => await _schoolDabaseContext.Students.AddAsync(t);

        public void UdpateElementFromRepository(Models.Students t)
        {
            _schoolDabaseContext.Students.Attach(t);
            _schoolDabaseContext.Students.Entry(t).State = EntityState.Modified;
        }

        public void DeleteElementFromRepository(Models.Students t) => _schoolDabaseContext.Students.Remove(t);

        public async Task Save() => await _schoolDabaseContext.SaveChangesAsync();

    }
}
