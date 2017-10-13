using Omi.Modular;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Omi.Modules.HomeBuilder.DbSeed;
using Omi.Modules.HomeBuilder.Services;
using System.Threading.Tasks;
using System.Linq;

namespace Omi.Modules.HomeBuilder
{
    public class HomeBuilderInitializer : IModuleInitializer
    {
        public async void Init(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            services.AddDbContext<HomeBuilderDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<PackageService>();

            var dbContext = services.BuildServiceProvider().GetService<HomeBuilderDbContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (!pendingMigrations.Any())
            {
                var designThemeSeed = new DesignThemeSeed();
                var packageIncludedSeed = new PackageIncludedSeed();
                var houseStyleSeed = new HouseStyleSeed();

                await designThemeSeed.SeedAsync(dbContext);
                await packageIncludedSeed.SeedAsync(dbContext);
                await houseStyleSeed.SeedAsync(dbContext);
            }
        }
    }
}