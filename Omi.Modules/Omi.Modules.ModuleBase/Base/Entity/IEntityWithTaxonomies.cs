using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.ModuleBase.Base.Entity
{
    public interface IEntityWithTaxonomies<TEntity, TEntityTaxomony>
        where TEntityTaxomony : IEntityTaxonomy<TEntity>
    {
        IEnumerable<TEntityTaxomony> EntityTaxonomies { get; set; }
    }
}
