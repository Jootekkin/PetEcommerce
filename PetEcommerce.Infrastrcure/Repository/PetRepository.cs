using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.Models;
using PetEcommerce.Infrastrcure.Data;
using PetEcommerce.Infrastrcure.Implementation;

namespace PetEcommerce.Infrastrcure.Repository
{
    #region Interface
    public interface IPetRepository : IGenericRepository<Pet>
    {
    }
    #endregion

    #region Implementation
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    #endregion
}
