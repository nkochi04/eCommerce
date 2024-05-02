using DesktopAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DesktopAppAPI
{
    public class desktopAppDbContext : DbContext
    {
        public desktopAppDbContext(DbContextOptions<desktopAppDbContext> options) : base(options) { }

        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<ProductDescriptionModel> ProductDescriptions { get; set; }
        public DbSet<ProductModel> Orders { get; set; }
        public DbSet<ProductModel> OrderXProducts { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<SellerModel> Sellers { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
