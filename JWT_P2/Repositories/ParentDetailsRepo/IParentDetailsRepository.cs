using JWT_P2.DTOs.ParentDetails;
using JWT_P2.Models;

namespace JWT_P2.Repositories.ParentDetailsRepo
{
    public interface IParentDetailsRepository
    {
        Task<IEnumerable<ParentDetails>> GetAllParentDetails();
        Task<ParentDetails> GetParentDetailsById(Guid id);
        Task<IEnumerable<ParentDetails>> GetParentDetailsByParentId(Guid id);
        Task<IEnumerable<ParentDetails>> GetParentDetailsByStudentId(Guid id);
        Task AddParentDetails(ParentDetails parentDetails);
        void UpdateParentDetails(ParentDetails parentDetails);
        void DeleteParentDetails(ParentDetails parentDetails);
        Task SaveChanges();

    }
}
