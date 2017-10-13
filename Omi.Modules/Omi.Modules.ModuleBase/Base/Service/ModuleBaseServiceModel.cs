using Omi.Base;
using Omi.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.ModuleBase.Base.Entity
{
    public class ModuleBaseServiceModel : BaseFilterServiceModel
    {
        public long? EntityTypeId { get; set; }
        public long TaxonomyTypeId { get; set; }
        public IEnumerable<long> TaxonomyIds { get; set; }
        public ApplicationUser UserInAction { get; set; }
    }
}
