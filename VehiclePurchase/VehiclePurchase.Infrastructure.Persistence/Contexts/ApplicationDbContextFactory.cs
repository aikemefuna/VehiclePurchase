using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VehiclePurchase.Infrastructure.Persistence.Contexts;

namespace VehiclePurchase.Persistence.Contexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=ABP-HQ7-LDIGFT5\\SQLEXPRESS;Initial Catalog=VehiclePurchase;Integrated Security=False;UId=sa;Password=@Reetah39");



            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
