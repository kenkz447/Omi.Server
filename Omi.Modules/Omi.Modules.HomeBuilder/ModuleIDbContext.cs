using Microsoft.EntityFrameworkCore;
using Omi.Modules.HomeBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Modules.HomeBuilder
{
    public interface IHomeBuilderDbContext
    {
        DbSet<Package> Package { get; set; }
    }
}