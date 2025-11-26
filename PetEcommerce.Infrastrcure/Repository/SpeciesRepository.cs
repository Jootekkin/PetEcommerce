using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.Models;
using PetEcommerce.Infrastrcure.Data;
using PetEcommerce.Infrastrcure.Implementation;

namespace PetEcommerce.Infrastrcure.Repository
{
    #region Interfaces
    public interface ISpeciesRepository : IGenericRepository<Species>
    {
    }
    #endregion

    #region Implementation
    public class SpeciesRepository : GenericRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    #endregion
}
