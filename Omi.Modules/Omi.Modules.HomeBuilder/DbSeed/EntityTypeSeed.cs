using Omi.Modular;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Omi.Modules.ModuleBase.Entities;
using Omi.Extensions;

namespace Omi.Modules.HomeBuilder.DbSeed
{
    public class EntityTypeSeed : IDbSeed
    {
        public static EntityType Tower = new EntityType
        {
            Name = "project-tower"
        };

        public static EntityType Floor = new EntityType
        {
            Name = "project-floor"
        };

        public static EntityType Room = new EntityType
        {
            Name = "project-room"
        };

        public async Task SeedAsync(DbContext dbConext)
        {
            var entityTypeSet = dbConext.Set<EntityType>();

            Tower = entityTypeSet.SeedEntity(Tower);
            Floor = entityTypeSet.SeedEntity(Floor);
            Room = entityTypeSet.SeedEntity(Room);

            await dbConext.SaveChangesAsync();
        }
    }
}
