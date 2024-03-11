namespace JWT_P2.Services.ParentDetailsServ
{
    public interface IParentDetailsService <TGet, TPost, TPut>
    {

        Task<IEnumerable<TGet>> GetParentDetails();
        Task<TGet> GetParentDetailsById(Guid id);
        Task<IEnumerable<TGet>> GetParentDetailsByParentId(Guid id);
        Task<IEnumerable<TGet>> GetParentDetailsByStudentId(Guid id);
        Task<TGet> AddParentDetails(TPost t);
        Task<TGet> UpdateParentDetails(TPut t);
        Task<TGet> DeleteParentDetails(Guid id);

    }
}
