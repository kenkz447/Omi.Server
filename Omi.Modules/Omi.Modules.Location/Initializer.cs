using Omi.Modular;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Omi.Modules.Location.DbSeed;
using Omi.Modules.Location.Services;
using System.Threading.Tasks;
using System.Linq;
using Omi.Modules.ModuleBase;

namespace Omi.Modules.Location
{
    public class LocationInitializer : IModuleInitializer
    {
        public async void Init(IServiceCollection services)
        {
            services.AddDbContext<LocationDbContext>();

            services.AddScoped<LocationService>();

            var dbContext = services.BuildServiceProvider().GetService<LocationDbContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (!pendingMigrations.Any())
            {
                var locationSeed = new LocationSeed();
                await locationSeed.SeedAsync(dbContext);
            }
        }
    }
}