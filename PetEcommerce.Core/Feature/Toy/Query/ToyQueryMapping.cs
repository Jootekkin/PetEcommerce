using PetEcommerce.Core.Feature.Toy.Query.Result;
using PetEcommerce.Domain.Models;

namespace PetEcommerce.Core.Mapping
{
    public partial class Profiling
    {
        private void ToyQueryMapping()
        {
            CreateMap<Toy, GetAllToyQueryResult>();
        }
    }
}
