using PetEcommerce.Domain.BaseInterface;
using PetEcommerce.Domain.Models;
using PetEcommerce.Infrastrcure.Data;

namespace PetEcommerce.Infrastrcure.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public IGenericRepository<Toy> ToysRepository => new GenericRepository<Toy>(_context);
        public IGenericRepository<Brand> BrandsRepository => new GenericRepository<Brand>(_context);

        public IGenericRepository<Breed> BreedsRepository => new GenericRepository<Breed>(_context);

        public IGenericRepository<Flavor> FlavorsRepository => new GenericRepository<Flavor>(_context);

        public IGenericRepository<Food> FoodsRepository => new GenericRepository<Food>(_context);

        public IGenericRepository<Pet> PetsRepository => new GenericRepository<Pet>(_context);

        public IGenericRepository<Species> SpeciesRepository => new GenericRepository<Species>(_context);
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
