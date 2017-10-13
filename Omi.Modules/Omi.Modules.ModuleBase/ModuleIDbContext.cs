using Microsoft.EntityFrameworkCore;
using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.ModuleBase
{
    public interface IModuleBaseDbContext
    {
        DbSet<EntityType> EntityType { get; set; }
        DbSet<TaxonomyType> TaxonomyType { get; set; }
        DbSet<Taxonomy> Taxonomy { get; set; }
        DbSet<TaxonomyDetail> TaxonomyDetail { get; set; }

        DbSet<CustomField> CustomField { get; set; }
        DbSet<CustomFieldDetail> CustomFieldDetail { get; set; }
        DbSet<CustomFieldGroup> CustomFieldGroup { get; set; }
    }
}