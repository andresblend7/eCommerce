using Microsoft.EntityFrameworkCore;
using WebApiCore.Entities;

namespace WebApiCore.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Images_Products> Images_Products { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Products_SubCategories> Products_SubCategories { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesHistory_Detail> SalesHistory_Details { get; set; }
        public DbSet<SubCategories> SubCategories { get; set; }
    }
}
