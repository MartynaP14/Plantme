using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plantme.Models;

namespace Plantme.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Product> Products { get;set; }
        
        public DbSet<Plantme.Models.ProductOrder> ProductOrder { get; set; }

        internal object GetByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}