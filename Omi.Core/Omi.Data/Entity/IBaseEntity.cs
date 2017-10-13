using System;

namespace Omi.Data.Entity
{
    public interface IBaseEntity : IEntityWithTypedId<long>
    {
        string CreateByUserId { get; set; }

        DateTime? CreateDate { get; set; }

        ApplicationUser CreateByUser { get; set; }
    }
}
