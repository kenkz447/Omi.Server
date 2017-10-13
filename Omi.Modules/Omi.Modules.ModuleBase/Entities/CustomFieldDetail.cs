using Omi.Data.Entity;
using System;

namespace Omi.Modules.ModuleBase.Entities
{
    public class CustomFieldDetail : BaseEntityDetail
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
        public string PlaceholderText { get;set;}
        public string Prepend { get; set; }
        public string Append { get; set; }
        public int CharacterLimit { get; set; }
        public string Language { get; set; }

        public long CustomFieldId { get; set; }
        public virtual CustomField CustomField { get; set; }
    }
}
