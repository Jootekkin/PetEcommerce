using AutoMapper;
using PetEcommerce.Domain.Pagination;

namespace PetEcommerce.Core.Mapping
{
    public partial class Profiling : Profile
    {
        public Profiling()
        {
            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));
            PetConfigurationMapping();
            ToyConfigurationMapping();
        }

    }
}
