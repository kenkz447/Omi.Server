﻿using Omi.Modules.FileAndMedia.Base.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Omi.Modules.FileAndMedia.Entities;

namespace Omi.Modules.HomeBuilder.Entities
{
    public class PackageFile :  IEntityFile<Package>
    {
        public int UsingType { get; set; }

        public long EntityId { get; set; }
        public long FileEntityId { get; set; }

        public Package Entity { get; set; }
        public FileEntity FileEntity { get; set; }
    }
}
