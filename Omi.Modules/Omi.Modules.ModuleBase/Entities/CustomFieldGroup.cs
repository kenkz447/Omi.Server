using Omi.Data.Entity;
using System;
using System.Collections.Generic;

namespace Omi.Modules.ModuleBase.Entities
{
    public class CustomFieldGroup : BaseEntity
    {
        public CustomFieldGroup()
        {
            ModuleBase = new HashSet<CustomField>();
        }

        public string Name { get; set; }

        public virtual ICollection<CustomField> ModuleBase { get; set; }
    }
}
