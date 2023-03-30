namespace Equifinance.Mock.Core.Interfaces
{
    public interface IRepository<Tentity> where Tentity : class
    {
        Task<IEnumerable<Tentity>> GetAllAsync();
        Task<Tentity?> GetByIdAsync(int id);
        Task InsertAsync(Tentity entity);
        Task UpdateAsync(Tentity entity);
        Task DeleteAsync(int id);
    }
}
