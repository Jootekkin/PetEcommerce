using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.Models;
using PetEcommerce.Infrastrcure.Data;
using PetEcommerce.Infrastrcure.Implementation;

namespace PetEcommerce.Infrastrcure.Repository
{
    #region Interface
    public interface IBreedRepository : IGenericRepository<Breed>
    {
    }
    #endregion

    #region Implementation
    public class BreedRepository : GenericRepository<Breed>, IBreedRepository
    {
        public BreedRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    #endregion
}
