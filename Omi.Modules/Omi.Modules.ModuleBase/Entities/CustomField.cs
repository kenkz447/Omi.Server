using Omi.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Omi.Modules.ModuleBase.Entities
{
    public class CustomField : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public bool AllowHtml { get; set; }
        public bool? Required { get; set; }
        public int? Order { get; set; }

        public long CustomFieldDetailId { get; set; }
        public long CustomFieldGroupId { get; set; }

        public virtual ICollection<CustomFieldDetail> CustomFieldDetail { get; set; }

        public virtual CustomFieldGroup CustomFieldGroup { get; set; }
    }
}
