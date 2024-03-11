using JWT_P2.DTOs.Schools;
using JWT_P2.Models;

namespace JWT_P2.Repositories.SchoolsRepo
{
    public interface ISchoolsRepository
    {

        Task<IEnumerable<Schools>> GetElementsFromRepository();
        Task<Schools> GetElementByIdFromRepository(Guid id);
        IEnumerable<Schools> GetElementByNameFromRepository(string name);
        Task AddSchool(Schools school);
        void UpdateSchool(Schools school);
        void DeleteSchool(Schools school);
        Task SaveAsync();

    }
}
