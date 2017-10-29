using Omi.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Omi.Modules.ModuleBase.Entities
{
    public class CustomFieldCondition : EntityWithTypeId<long>
    {
        public long EntityGroupId { get; set; }
        public long TaxonomyId { get; set; }
        public int Condition { get; set; }
    }
}
