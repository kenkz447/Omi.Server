using Omi.Data.Entity;
using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Omi.Modules.ModuleBase.Entities
{
    public class Taxonomy : BaseEntity, IEntityWithName
    {
        [Required]
        public string Name { get; set; }

        public long TaxonomyTypeId { get; set; }

        public virtual TaxonomyType TaxonomyType { get; set; }

        public virtual ICollection<TaxonomyDetail> TaxonomyDetails { get; set; }
    }
}
