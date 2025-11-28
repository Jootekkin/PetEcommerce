using PetEcommerce.Domain.Models;
using System.Linq.Expressions;

namespace PetEcommerce.Domain.Pagination
{
    public class BasePagedRequest<T> where T : BaseEntity
    {
        public int MaxPageSize { get; set; } = 100;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; } = "ASC";
        public List<Expression<Func<T, bool>>>? FilterBy { get; set; }

    }
}
