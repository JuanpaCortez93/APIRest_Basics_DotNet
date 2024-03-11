using JWT_P2.DTOs.Students;

namespace JWT_P2.Repositories
{
    public interface IParentsRepository <TEntity>
    {

        Task<IEnumerable<TEntity>> GetElementsFromRepository();
        Task<TEntity> GetElementFromRepositoryById(Guid id);
        Task AddElementFromRepository(TEntity t);
        void UdpateElementFromRepository(TEntity t);
        void DeleteElementFromRepository(TEntity t);
        Task Save();

    }
}
