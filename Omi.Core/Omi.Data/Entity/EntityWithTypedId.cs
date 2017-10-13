using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Data.Entity
{
    public class EntityWithTypedId<T> : IEntityWithTypedId<T>
    {
        public T Id { get; set; }
    }
}
