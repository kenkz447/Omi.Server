using Omi.Data.Entity;
using Omi.Modules.ModuleBase.Base.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.HomeBuilder.Entities
{
    public class Package : 
        EntityWithEntityTypeId, 
        IEntityWithName,
        IEntityWithTaxonomies<Package, PackageTaxonomy>
    {
        public string Name { get; set; }

        public virtual ICollection<PackageDetail> PackageDetails { get; set; }
        public virtual IEnumerable<PackageTaxonomy> EntityTaxonomies { get; set; }
        public virtual IEnumerable<PackageFile> PackageFiles { get; set; }
    }
}