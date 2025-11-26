using PetEcommerce.Domain.Models;

namespace PetEcommerce.Domain.BaseInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Brand> BrandsRepository { get; }
        IGenericRepository<Breed> BreedsRepository { get; }
        IGenericRepository<Flavor> FlavorsRepository { get; }
        IGenericRepository<Food> FoodsRepository { get; }
        IGenericRepository<Pet> PetsRepository { get; }
        IGenericRepository<Species> SpeciesRepository { get; }
        IGenericRepository<Toy> ToysRepository { get; }
        Task<int> SaveChangesAsync();

    }
}
