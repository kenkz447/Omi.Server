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
                .HasKey(o => new { o.EntityId, o.FileEntityId });

            builder.Entity<Project>()
                .HasMany(o => o.ProjectDetails);

            builder.Entity<ProjectDetail>();

            builder.Entity<ProjectTaxonomy>()
                .HasKey(o => new { o.ProjectId, o.TaxonomyId });

            builder.Entity<ProjectFile>()
                .HasKey(o => new { o.EntityId, o.FileEntityId });


        }
    }
}
