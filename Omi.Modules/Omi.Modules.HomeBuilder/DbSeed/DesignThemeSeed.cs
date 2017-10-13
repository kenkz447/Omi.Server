using Microsoft.EntityFrameworkCore;
using Omi.Data.Entity;
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

            var desingTheme = await entityTypeSet.FirstOrDefaultAsync(o => o.Name == DesignTheme.Name);
            if (desingTheme == null)
                DesignTheme = entityTypeSet.Add(DesignTheme).Entity;
            else
                DesignTheme = desingTheme;

            Classic.TaxonomyTypeId = DesignTheme.Id;
            Modern.TaxonomyTypeId = DesignTheme.Id;

            var taxonomySet = context.Set<Taxonomy>();

            Classic = await SeedEntityAsync(taxonomySet, Classic);
            Modern = await SeedEntityAsync(taxonomySet, Modern);

            await context.SaveChangesAsync();
        }

        public async Task<T> SeedEntityAsync<T>(DbSet<T> entitySet, T entityToSeed)
            where T : class, IEntityWithName
        {
            var entity = await entitySet.FirstOrDefaultAsync(o => o.Name == entityToSeed.Name);
            if(entity == null)
                return entitySet.Add(entityToSeed).Entity;

            return entity;
        }
    }
}