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
    public class PackageIncludedSeed : IDbSeed
    {
        public static TaxonomyType PackageIncludedItem = new TaxonomyType
        {
            Name = "package-include-item"
        };

        public static Taxonomy Carpentry = new Taxonomy
        {
            Name = "package-carpentry",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Carpentry",
                    Icon = "/images/package-carpentry.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy FeatureWall = new Taxonomy
        {
            Name = "package-feature-wall",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Feature Wall",
                    Icon = "/images/package-feature-wall.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy Plumbing = new Taxonomy
        {
            Name = "package-plumbing",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Plumbing",
                    Icon = "/images/package-plumbing.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy ElectricalWiring = new Taxonomy
        {
            Name = "package-electrical-wiring",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Electrical Wiring",
                    Icon = "/images/package-electric-wiring.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy Flooring = new Taxonomy
        {
            Name = "package-flooring",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Flooring",
                    Icon = "/images/package-flooring.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy FalseCeiling = new Taxonomy
        {
            Name = "package-false-ceiling",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "False Ceiling",
                    Icon = "/images/package-false-ceiling.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy Furniture = new Taxonomy
        {
            Name = "package-furniture",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Furniture",
                    Icon = "/images/package-furniture.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy Decoration = new Taxonomy
        {
            Name = "package-decoration",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Decoration",
                    Icon = "/images/package-decoration.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy Design = new Taxonomy
        {
            Name = "package-design",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Design",
                    Icon = "/images/package-design.png",
                    Language = "en-US"
                }
            }
        };
        public static Taxonomy Painting = new Taxonomy
        {
            Name = "package-painting",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Painting",
                    Icon = "/images/package-painting.png",
                    Language = "en-US"
                }
            }
        };

        public async Task SeedAsync(DbContext context)
        {
            var entityTypeSet = context.Set<TaxonomyType>();

            var packageIncludedItem = await entityTypeSet.FirstOrDefaultAsync(o => o.Name == PackageIncludedItem.Name);
            if (packageIncludedItem == null)
                PackageIncludedItem = entityTypeSet.Add(PackageIncludedItem).Entity;
            else
                PackageIncludedItem = packageIncludedItem;

            Carpentry.TaxonomyTypeId = PackageIncludedItem.Id;
            FeatureWall.TaxonomyTypeId = PackageIncludedItem.Id;
            Plumbing.TaxonomyTypeId = PackageIncludedItem.Id;
            ElectricalWiring.TaxonomyTypeId = PackageIncludedItem.Id;
            Flooring.TaxonomyTypeId = PackageIncludedItem.Id;
            FalseCeiling.TaxonomyTypeId = PackageIncludedItem.Id;
            Furniture.TaxonomyTypeId = PackageIncludedItem.Id;
            Decoration.TaxonomyTypeId = PackageIncludedItem.Id;
            Design.TaxonomyTypeId = PackageIncludedItem.Id;
            Painting.TaxonomyTypeId = PackageIncludedItem.Id;

            var taxonomySet = context.Set<Taxonomy>();

            Carpentry = await SeedEntityAsync(taxonomySet, Carpentry);
            FeatureWall = await SeedEntityAsync(taxonomySet, FeatureWall);
            Plumbing = await SeedEntityAsync(taxonomySet, Plumbing);
            ElectricalWiring = await SeedEntityAsync(taxonomySet, ElectricalWiring);
            Flooring = await SeedEntityAsync(taxonomySet, Flooring);
            FalseCeiling = await SeedEntityAsync(taxonomySet, FalseCeiling);
            Furniture = await SeedEntityAsync(taxonomySet, Furniture);
            Decoration = await SeedEntityAsync(taxonomySet, Decoration);
            Design = await SeedEntityAsync(taxonomySet, Design);
            Painting = await SeedEntityAsync(taxonomySet, Painting);

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