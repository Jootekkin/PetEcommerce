using Microsoft.EntityFrameworkCore;
using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.Models;
using PetEcommerce.Domain.Pagination;
using PetEcommerce.Infrastrcure.Data;

namespace PetEcommerce.Infrastrcure.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        #endregion

        #region Constructor
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        #endregion

        #region Methods
        public async Task<PagedResult<T>> GetAllAsync(BasePagedRequest<T> pagedRequest)
        {
            var query = _dbSet.AsQueryable();

            // Apply filtering
            query = query.ApplyFiltering(pagedRequest.FilterBy);
            //apply sorting
            query = query.ApplySorting(pagedRequest.SortBy, pagedRequest.SortDirection);

            return await query.ToPagedResultAsync(pagedRequest.PageNumber, pagedRequest.PageSize);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        #endregion

    }
}
