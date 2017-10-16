using Omi.Modules.FileAndMedia.Base.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.FileAndMedia.Base
{
    public interface IServiceModelWithFiles<TEntity, TEntityFile>
        where TEntityFile : class, IEntityFile<TEntity>, new()
    {
        IEnumerable<TEntityFile> GetEntityFiles();
    }
}
