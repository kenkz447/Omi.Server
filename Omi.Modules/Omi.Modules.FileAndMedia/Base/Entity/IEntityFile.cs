using Omi.Data.Entity;
using Omi.Modules.FileAndMedia.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.FileAndMedia.Base.Entity
{
    public interface IEntityFile<T> : IEntity
    {
        long FileEntityId { get; set; }

        T Entity { get; set; }
        FileEntity FileEntity { get; set; }
    }
}
