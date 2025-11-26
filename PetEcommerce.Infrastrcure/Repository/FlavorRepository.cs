using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.Models;
using PetEcommerce.Infrastrcure.Data;
using PetEcommerce.Infrastrcure.Implementation;

namespace PetEcommerce.Infrastrcure.Repository
{
    #region Interface
    public interface IFlavorRepository : IGenericRepository<Flavor>
    {
    }
    #endregion

    #region Implementation
    public class FlavorRepository : GenericRepository<Flavor>, IFlavorRepository
    {
        public FlavorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    #endregion
}
