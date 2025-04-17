using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entities;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            return entity != null && !entity.IsDeleted ? entity : null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _entities.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            await UpdateAsync(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _entities.AnyAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
} 