using Microsoft.EntityFrameworkCore;
using Omi.Data.Entity;
using Omi.Extensions;
using Omi.Modular;
using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omi.Modules.HomeBuilder.DbSeed
{
    public class DesignThemeSeed : IDbSeed
    {
        public static TaxonomyType DesignTheme = new TaxonomyType
        {
            Name = "package-design-theme"
        };

        public static Taxonomy Classic = new Taxonomy
        {
            Name = "design-theme-classic",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Classic",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy Modern = new Taxonomy
        {
            Name = "design-theme-modern",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Modern",
                    Language = "en-US"
                }
            }
        };

        public async Task SeedAsync(DbContext context)
        {
            var entityTypeSet = context.Set<TaxonomyType>();
            DesignTheme = entityTypeSet.SeedEntity(DesignTheme);

            Classic.TaxonomyTypeId = DesignTheme.Id;
            Modern.TaxonomyTypeId = DesignTheme.Id;

            var taxonomySet = context.Set<Taxonomy>();

            Classic = taxonomySet.SeedEntity(Classic);
            Modern = taxonomySet.SeedEntity(Modern);

            await context.SaveChangesAsync();
        }
    }
}