using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        //Não carregar de modo Lazy para melhorar a performance do DB
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;

        }

        //Para que o Entity busque em todo o assembly as classes onde foram feitos os mappings
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }

    }

}
