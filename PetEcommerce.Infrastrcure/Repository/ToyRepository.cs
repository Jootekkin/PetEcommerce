using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.Models;
using PetEcommerce.Infrastrcure.Data;
using PetEcommerce.Infrastrcure.Implementation;

namespace PetEcommerce.Infrastrcure.Repository
{
    #region Interface
    public interface IToyRepository : IGenericRepository<Toy>
    {
    }
    #endregion

    #region Implementation
    public class ToyRepository : GenericRepository<Toy>, IToyRepository
    {
        public ToyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    #endregion
}
