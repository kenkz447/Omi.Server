using Microsoft.EntityFrameworkCore;
using Omi.Modules.FileAndMedia.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.FileAndMedia
{
    public interface IHomeBuilderDbContext
    {
        DbSet<FileEntity> FileEntity { get; set; }
    }
}