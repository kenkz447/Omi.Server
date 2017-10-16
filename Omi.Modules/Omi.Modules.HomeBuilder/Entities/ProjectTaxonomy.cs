using Omi.Modules.ModuleBase.Base.Entity;
using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.HomeBuilder.Entities
{
    public class ProjectTaxonomy: IEntityTaxonomy<Project>
    {
        public long ProjectId { get; set; }
        public long TaxonomyId { get; set; }

        public virtual Project Entity { get; set; }
        public virtual Taxonomy Taxonomy { get; set; }
    }
}
