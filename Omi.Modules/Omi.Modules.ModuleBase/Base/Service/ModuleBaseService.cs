using Omi.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Omi.Base;
using System.Linq;
using Omi.Data.Entity;
using Omi.Modules.ModuleBase.Base.Entity;

namespace Omi.Modules.ModuleBase.Base.Entity
{
    public class ModuleBaseService : BaseEntityService
    {
        public IQueryable<T> ModuleBaseEntityFilter<T>(DbSet<T> dbSet, ModuleBaseServiceModel model)
            where T : EntityWithEntityTypeId, IEntityWithTaxonomies<IEntityWithEntityTypeId, IEntityTaxonomy<IEntityWithEntityTypeId>>
        {
            var result = base.BaseEntityFilter(dbSet, model);

            if (model.EntityTypeId != null)
                result = result.Where(o => o.EntityTypeId == model.EntityTypeId);

            if (model.TaxonomyIds != null)
                result = result.Where(o => o.EntityTaxonomies.FirstOrDefault(e => model.TaxonomyIds.Contains(e.Taxonomy.Id)) != null);

            return result;
        }
    }
}