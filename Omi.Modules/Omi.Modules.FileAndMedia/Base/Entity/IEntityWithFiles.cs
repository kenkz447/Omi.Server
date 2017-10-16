using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.FileAndMedia.Base.Entity
{
    public interface IEntityWithFiles<TEntity, TEntityFile>
        where TEntityFile : IEntityFile<TEntity>
    {
        IEnumerable<TEntityFile> EnitityFiles { get; set; }
    }
}
