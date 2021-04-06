using Microsoft.EntityFrameworkCore;
using InClass.Models;

namespace InClass.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Ordered_Products> Ordered_Products { get; set; }
    }
}
