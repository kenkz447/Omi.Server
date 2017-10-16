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
            services.AddDbContext<HomeBuilderDbContext>();

            services.AddScoped<PackageService>();
            services.AddScoped<ProjectService>();

            var dbContext = services.BuildServiceProvider().GetService<HomeBuilderDbContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (!pendingMigrations.Any())
            {
                var designThemeSeed = new DesignThemeSeed();
                var packageIncludedSeed = new PackageIncludedSeed();
                var houseStyleSeed = new HouseStyleSeed();
                var projectTypeSeed = new ProjectTypeSeed();

                await designThemeSeed.SeedAsync(dbContext);
                await packageIncludedSeed.SeedAsync(dbContext);
                await houseStyleSeed.SeedAsync(dbContext);
                await projectTypeSeed.SeedAsync(dbContext);
            }
        }
    }
}