using Omi.Modular;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Omi.Modules.ModuleBase.Entities;
using Omi.Extensions;

namespace Omi.Modules.HomeBuilder.DbSeed
{
    public class ProjectStatusSeed : IDbSeed
    {
        public static TaxonomyType ProjectStatus = new TaxonomyType
        {
            Name = "project-status"
        };

        public static Taxonomy UnderConstruction = new Taxonomy
        {
            Name = "project-status-under-construction",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Under construction",
                    Language = "en-US"
                }
            }
        };

        public static Taxonomy Finish = new Taxonomy
        {
            Name = "project-status-finish",
            TaxonomyDetails = new List<TaxonomyDetail>
            {
                new TaxonomyDetail
                {
                    Label = "Finish",
                    Language = "en-US"
                }
            }
        };

        public async Task SeedAsync(DbContext dbConext)
        {
            var entityTypeSet = dbConext.Set<TaxonomyType>();

            ProjectStatus = entityTypeSet.SeedEntity(ProjectStatus);

            UnderConstruction.TaxonomyTypeId = ProjectStatus.Id;
            Finish.TaxonomyTypeId = ProjectStatus.Id;

            var taxonomySet = dbConext.Set<Taxonomy>();

            UnderConstruction = taxonomySet.SeedEntity(UnderConstruction);
            Finish = taxonomySet.SeedEntity(Finish);

            await dbConext.SaveChangesAsync();
        }
    }
}
