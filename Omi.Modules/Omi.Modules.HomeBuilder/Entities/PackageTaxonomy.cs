using Omi.Modules.ModuleBase.Entities;
using Omi.Modules.ModuleBase.Base.Entity;

namespace Omi.Modules.HomeBuilder.Entities
{
    public class PackageTaxonomy: IEntityTaxonomy<Package>
    {
        public long PackageId { get; set; }
        public long TaxonomyId { get; set; }

        public virtual Package Entity { get; set; }
        public virtual Taxonomy Taxonomy { get; set; }
    }
}
