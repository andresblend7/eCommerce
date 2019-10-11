using Microsoft.EntityFrameworkCore;
using WebApiCore.Entities;

namespace WebApiCore.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Dic_Users> Dic_Users { get; set; }
        public DbSet<Dic_Categories> Dic_Categories { get; set; }
        public DbSet<Det_Images_Products> Det_Images_Products { get; set; }
        public DbSet<Dic_Products> Dic_Products { get; set; }
        public DbSet<Dic_Rol> Dic_Rol { get; set; }
        public DbSet<Dic_Cities> Dic_Cities { get; set; }
        public DbSet<Dic_Sales> Dic_Sales { get; set; }
        public DbSet<Dic_SubCategories> Dic_SubCategories { get; set; }
        public DbSet<Det_SalesHistory> Det_SalesHistory { get; set; }
        public DbSet<Det_Products_SubCategories> Det_Products_SubCategories { get; set; }
        public DbSet<Det_ShopCar> Det_ShopCar { get; set; }

    }
}
