using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.Models;
using PetEcommerce.Infrastrcure.Data;
using PetEcommerce.Infrastrcure.Implementation;

namespace PetEcommerce.Infrastrcure.Repository
{
    #region Interface
    public interface IFoodRepository : IGenericRepository<Food>
    {
    }
    #endregion

    #region Implementation
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    #endregion
}
