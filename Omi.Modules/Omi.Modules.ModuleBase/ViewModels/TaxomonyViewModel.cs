using Omi.Modules.ModuleBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Omi.Modules.ModuleBase.ViewModels
{
    public class TaxomonyViewModel
    {
        public long Id { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public long? TaxonomyTypeId { get; set; }

        public static TaxomonyViewModel FromEntity(Taxonomy entity)
        {
            var taxonomyDetail = entity.TaxonomyDetails.FirstOrDefault();

            return new TaxomonyViewModel
            {
                Id = entity.Id,
                Label = taxonomyDetail?.Label,
                Icon = taxonomyDetail?.Icon,
                TaxonomyTypeId = entity.TaxonomyTypeId
            };
        }
    }
}
