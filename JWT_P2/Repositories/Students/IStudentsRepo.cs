namespace JWT_P2.Repositories.Students
{
    public interface IStudentsRepo <TEntity>
    {
        Task<IEnumerable<TEntity>> GetElementsFromRepository();
        Task<TEntity> GetElementFromRepositoryById(Guid id);
        IEnumerable<TEntity> GetElementByName(string name);
        Task AddElementFromRepository(TEntity t);
        void UdpateElementFromRepository(TEntity t);
        void DeleteElementFromRepository(TEntity t);
        Task Save();

    }
}
