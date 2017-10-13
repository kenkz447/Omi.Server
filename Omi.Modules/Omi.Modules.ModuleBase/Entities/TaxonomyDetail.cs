using Omi.Data.Entity;

namespace Omi.Modules.ModuleBase.Entities
{
    public class TaxonomyDetail : BaseEntityDetail 
    {
        public string Label { get; set; }
        public string Icon { get; set; }
        public string Language { get; set; }

        public long TaxonomyId { get; set; }

        public virtual Taxonomy Taxonomy { get; set; }
    }
}