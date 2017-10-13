using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Omi.Data.Entity
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public long Id { get; set; }

        public int Status { get; set; }

        public string DeleteByUserId { get; set; }
        public string CreateByUserId { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }

        public virtual ApplicationUser CreateByUser { get; set; }
        public virtual ApplicationUser DeleteByUser { get;set;}
    }
}
