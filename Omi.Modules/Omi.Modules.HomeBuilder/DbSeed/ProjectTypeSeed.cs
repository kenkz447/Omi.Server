using Microsoft.EntityFrameworkCore;
using Omi.Extensions;
using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omi.Modules.HomeBuilder.DbSeed
{
    class ProjectTypeSeed
    {
        public static TaxonomyType ProjectType = new TaxonomyType
        {
            Name = "project-type"
        };

        public static Taxonomy Apartment = new Taxonomy
        {
            Name = "project-type-apartment",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Apartment",
                    Language = "en-US"
                }
            }
        };

        public async Task SeedAsync(DbContext context)
        {
            var entityTypeSet = context.Set<TaxonomyType>();

            ProjectType = entityTypeSet.SeedEntity(ProjectType);

            Apartment.TaxonomyTypeId = ProjectType.Id;

            var taxonomySet = context.Set<Taxonomy>();

            Apartment = taxonomySet.SeedEntity(Apartment);

            await context.SaveChangesAsync();
        }
    }
}
