using Omi.Modules.FileAndMedia.Base.Entity;
using Omi.Modules.FileAndMedia.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.HomeBuilder.Entities
{
    public class ProjectFile : IEntityFile<Project>
    {
        public long EntityId { get; set; }
        public long FileEntityId { get; set; }

        public int UsingType { get; set; }

        public Project Entity { get; set; }
        public FileEntity FileEntity { get; set; }
    }
}
