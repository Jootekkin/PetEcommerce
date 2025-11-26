using PetEcommerce.Domain.Models;
using PetEcommerce.Domain.Pagination;

namespace PetEcommerce.Domain.BaseInterface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<PagedResult<T>> GetAllAsync(BasePagedRequest<T> pagedRequest);
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
