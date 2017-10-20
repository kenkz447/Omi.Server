using Omi.Data.Entity;
using Omi.Modules.FileAndMedia.Base.Entity;
using Omi.Modules.Location.Entities;
using Omi.Modules.ModuleBase.Base.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Omi.Modules.HomeBuilder.Entities
{
    public class Project :
        EntityWithEntityTypeId,
        IEntityWithName,
        IEntityWithFiles<Project, ProjectFile>
    {
        public string Name { get; set; }

        public int? CityId { get; set; }

        public GeographicaLocation City { get; set; }

        public IEnumerable<ProjectDetail> ProjectDetails { get; set; }
        public IEnumerable<ProjectTaxonomy> EntityTaxonomies { get; set; }
        public IEnumerable<ProjectFile> EnitityFiles { get; set; }
    }
}
