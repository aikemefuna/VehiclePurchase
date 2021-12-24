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
            optionsBuilder.UseSqlServer("Data Source=SQL5098.site4now.net;Initial Catalog=db_a708de_vehicle;Integrated Security=False;UId=db_a708de_vehicle_admin;Password=@Reetah39");



            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
