namespace PetEcommerce.Domain.Pagination
{
    public class PagedResult<T>
    {
        public T? Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

        public PagedResult()
        {
            //Items = default(T);
        }

        public PagedResult(T items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasNextPage = PageNumber < TotalPages;
            HasPreviousPage = PageNumber > 1;
        }
    }
}
