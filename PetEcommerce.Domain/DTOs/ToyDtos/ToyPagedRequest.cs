using PetEcommerce.Domain.Models;
using PetEcommerce.Domain.Pagination;

namespace PetEcommerce.Domain.DTOs.ToyDtos
{
    public class ToyPagedRequest : BasePagedRequest<Toy>
    {
        public string? ToyName { get; set; }
        public string? Material { get; set; }
        public bool IsDurable { get; set; }
        public string? size { get; set; }

        public void ApplyFilters()
        {
            if (!string.IsNullOrEmpty(ToyName))
            {
                AddFilter(t => t.Name != null && t.Name.ToLower().Contains(ToyName.ToLower()));
            }
            if (!string.IsNullOrEmpty(Material))
            {
                AddFilter(t => t.Material != null && t.Material.ToLower() == Material.ToLower());
            }
            if (IsDurable)
            {
                AddFilter(t => t.IsDurable == IsDurable);
            }
            if (!string.IsNullOrEmpty(size))
            {
                AddFilter(t => t.Size != null && t.Size.ToLower() == size.ToLower());
            }
        }
    }
}
