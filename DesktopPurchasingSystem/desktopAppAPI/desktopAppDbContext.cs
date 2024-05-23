using DesktopAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DesktopAppAPI
{
    public class desktopAppDbContext : DbContext
    {
        public desktopAppDbContext(DbContextOptions<desktopAppDbContext> options) : base(options) { }

        public DbSet<AddressDb> Addresses { get; set; }
        public DbSet<DepartmentDb> Departments { get; set; }
        public DbSet<ProductDb> Products { get; set; }
        public DbSet<OrderDb> Orders { get; set; }
        public DbSet<PieceDb> Pieces { get; set; }
        public DbSet<SupplierDb> Suppliers { get; set; }
        public DbSet<SellerDb> Sellers { get; set; }
        public DbSet<UserDb> Users { get; set; }
    }
}
