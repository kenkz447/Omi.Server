using Omi.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.HomeBuilder.ServiceModel
{
    public class ProjectFilterServiceModel: BaseFilterServiceModel
    {
        public List<long> TaxonomyIds { get; set; }
    }
}
