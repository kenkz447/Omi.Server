using Microsoft.EntityFrameworkCore;
using Omi.Data;
using Omi.Modular;
using Omi.Modules.HomeBuilder;
using Omi.Modules.HomeBuilder.Entities;
using Omi.Modules.ModuleBase;
using System.Collections.Generic;

namespace Omi.Modules.HomeBuilder
{
    public class HomeBuilderDbContext : ModuleBaseDbContext, IHomeBuilderDbContext
    {
        public HomeBuilderDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Package> Package { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RegisterCustomMappings<HomeBuilderModelBuilder>();
            base.OnModelCreating(builder);
        }
    }
}
