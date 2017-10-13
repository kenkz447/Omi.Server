using Omi.Modules.ModuleBase.Entities;
using Omi.Modules.ModuleBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Omi.Modules.ModuleBase.Utilities
{
    public static class ViewModelUtilities
    {
        public static TaxomonyViewModel ToTaxonomyViewModel(Taxonomy taxonomy)
        {
            var taxonomyDetail = taxonomy.TaxonomyDetails.FirstOrDefault();
            return new TaxomonyViewModel()
            {
                Id = taxonomy.Id,
                Label = taxonomyDetail?.Label,
                Icon = taxonomyDetail?.Icon,
                TaxonomyTypeId = taxonomy.TaxonomyTypeId
            };
        }
    }
}
