using Equifinance.Mock.API.Data;
using Equifinance.Mock.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Equifinance.Mock.Infrastructure.Repository
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await _context.Set<Tentity>().ToListAsync();
        }

        public async Task<Tentity?> GetByIdAsync(int id)
        {
            return await _context.Set<Tentity>().FindAsync(id);
        }

        public async Task InsertAsync(Tentity entity)
        {
            await _context.Set<Tentity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tentity entity)
        {
            _context.Set<Tentity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<Tentity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
