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
    public class HouseStyleSeed : IDbSeed
    {
        public static TaxonomyType HouseStyle = new TaxonomyType
        {
            Name = "package-house-style"
        };

        public static Taxonomy Apartment = new Taxonomy
        {
            Name = "house-style-apartment",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Apartment",
                    Language = "en-US"
                }
            }
        };

        public static Taxonomy LandedHouse = new Taxonomy
        {
            Name = "house-style-landed-house",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Landed House",
                    Language = "en-US"
                }
            }
        };

        public async Task SeedAsync(DbContext context)
        {
            var entityTypeSet = context.Set<TaxonomyType>();

            var desingTheme = await entityTypeSet.FirstOrDefaultAsync(o => o.Name == HouseStyle.Name);
            if (desingTheme == null)
                HouseStyle = entityTypeSet.Add(HouseStyle).Entity;
            else
                HouseStyle = desingTheme;

            Apartment.TaxonomyTypeId = HouseStyle.Id;
            LandedHouse.TaxonomyTypeId = HouseStyle.Id;

            var taxonomySet = context.Set<Taxonomy>();

            Apartment = await SeedEntityAsync(taxonomySet, Apartment);
            LandedHouse = await SeedEntityAsync(taxonomySet, LandedHouse);

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