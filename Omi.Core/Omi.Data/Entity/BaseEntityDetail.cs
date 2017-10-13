using System;
using System.ComponentModel.DataAnnotations;

namespace Omi.Data.Entity
{
    public abstract class BaseEntityDetail : IBaseEntity
    {
        [Key]
        public long Id { get; set; }

        public string CreateByUserId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ApplicationUser CreateByUser { get; set; }
    }
}