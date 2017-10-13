using Omi.Data.Entity;
using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.ModuleBase.Base.Entity
{
    public interface IEntityTaxonomy<TEntity>: IEntity
    {
        TEntity Entity { get; set; }
        Taxonomy Taxonomy { get; set; }
    }
}
