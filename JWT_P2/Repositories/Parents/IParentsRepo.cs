namespace JWT_P2.Repositories.Parents
{
    public interface IParentsRepo
    {
        Task<IEnumerable<JWT_P2.Models.Parents>> GetElementsFromRepository();
        Task<JWT_P2.Models.Parents> GetElementFromRepositoryById(Guid id);
        Task AddElementFromRepository(JWT_P2.Models.Parents t);
        void UdpateElementFromRepository(JWT_P2.Models.Parents t);
        void DeleteElementFromRepository(JWT_P2.Models.Parents t);
        Task Save();
    }
}
