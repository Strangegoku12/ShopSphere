using Microsoft.EntityFrameworkCore;
using ShopSphereBackend.Model.VendorModel;

namespace ShopSphereBackend.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeeSignup> EmployeeSignup { get; set; }
    }
}
