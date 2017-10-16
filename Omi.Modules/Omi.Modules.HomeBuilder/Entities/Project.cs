using Omi.Data.Entity;
using Omi.Modules.FileAndMedia.Base.Entity;
using Omi.Modules.Location.Entities;
using Omi.Modules.ModuleBase.Base.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.HomeBuilder.Entities
{
    public class Project :
        EntityWithEntityTypeId,
        IEntityWithName,
        IEntityWithFiles<Project, ProjectFile>
    {
        public string Name { get; set; }

        public long CityId { get; set; }

        public virtual GeographicaLocation City { get; set; }

        public virtual IEnumerable<ProjectDetail> ProjectDetails { get; set; }
        public virtual IEnumerable<ProjectTaxonomy> EntityTaxonomies { get; set; }
        public virtual IEnumerable<ProjectFile> EnitityFiles { get; set; }
    }
}
