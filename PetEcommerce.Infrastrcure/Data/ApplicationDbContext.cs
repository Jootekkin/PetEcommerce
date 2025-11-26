using Microsoft.EntityFrameworkCore;
using PetEcommerce.Domain.Models;

namespace PetEcommerce.Infrastrcure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Define your DbSets here
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Species> Species { get; set; }
    }

}
