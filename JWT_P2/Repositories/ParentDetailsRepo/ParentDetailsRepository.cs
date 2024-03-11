using JWT_P2.Models;
using JWT_P2.SchoolDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JWT_P2.Repositories.ParentDetailsRepo
{
    public class ParentDetailsRepository : IParentDetailsRepository
    {
        //Propierties
        private SchoolMessageDatabaseContext _messageDatabaseContext;


        //Constructor
        public ParentDetailsRepository(SchoolMessageDatabaseContext messageDatabaseContext)
        {
            _messageDatabaseContext = messageDatabaseContext;
        }


        //Methods
        public async Task<IEnumerable<ParentDetails>> GetAllParentDetails() => await _messageDatabaseContext.ParentDetails.ToListAsync();

        public async Task<ParentDetails> GetParentDetailsById(Guid id) => await _messageDatabaseContext.ParentDetails.FindAsync(id);

        public async Task<IEnumerable<ParentDetails>> GetParentDetailsByParentId(Guid id) => await _messageDatabaseContext.ParentDetails.Where(parentDetail => parentDetail.ParentId == id).ToListAsync();

        public async Task<IEnumerable<ParentDetails>> GetParentDetailsByStudentId(Guid id) => await _messageDatabaseContext.ParentDetails.Where(parentDetail => parentDetail.StudentId == id).ToListAsync();

        public async Task AddParentDetails(ParentDetails parentDetails) => await _messageDatabaseContext.ParentDetails.AddAsync(parentDetails);

        public void UpdateParentDetails(ParentDetails parentDetails)
        {
            _messageDatabaseContext.ParentDetails.Attach(parentDetails);
            _messageDatabaseContext.ParentDetails.Entry(parentDetails).State = EntityState.Modified;
        }

        public void DeleteParentDetails(ParentDetails parentDetails) => _messageDatabaseContext.Remove(parentDetails);
        public Task SaveChanges() => _messageDatabaseContext.SaveChangesAsync();
    }
}
