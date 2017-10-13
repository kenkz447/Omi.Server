using Microsoft.EntityFrameworkCore;
using Omi.Modular;
using Omi.Modules.HomeBuilder.Entities;

namespace Omi.Modules.HomeBuilder
{
    public class HomeBuilderModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Package>()
                .HasMany(o => o.PackageDetails);
            builder.Entity<PackageDetail>();

            builder.Entity<PackageTaxonomy>()
                .HasKey(o => new { o.PackageId, o.TaxonomyId });

            builder.Entity<PackageFile>()
                .HasKey(o => new { o.PackageId, o.FileEntityId });
        }
    }
}
