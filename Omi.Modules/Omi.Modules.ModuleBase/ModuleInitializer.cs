using Omi.Modular;
using Microsoft.Extensions.DependencyInjection;
using Omi.Modules.ModuleBase.Services;

namespace Omi.Modules.ModuleBase
{
    public class ModuleBaseInitializer : IModuleInitializer
    {
        public void Init(IServiceCollection services)
        {
            services.AddScoped<CustomFieldService>();
            services.AddDbContext<ModuleBaseDbContext>();
        }
    }
}