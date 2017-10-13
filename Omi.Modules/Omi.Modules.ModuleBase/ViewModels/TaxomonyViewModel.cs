using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.ModuleBase.ViewModels
{
    public class TaxomonyViewModel
    {
        public long Id { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public long? TaxonomyTypeId { get; set; }
    }
}
