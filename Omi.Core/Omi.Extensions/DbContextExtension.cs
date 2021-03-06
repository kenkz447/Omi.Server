﻿using Microsoft.EntityFrameworkCore;
using Omi.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Omi.Extensions
{
    public static class DbContextExtension
    {
        public static void TryUpdateOneToMany<TEntity, TKey>(this DbContext db, IEnumerable<TEntity> currentEntities, IEnumerable<TEntity> newEntities, Func<TEntity, TKey> getKey)
            where TEntity : class, IEntityWithTypeId<TKey>
        {
            var addedEntities = newEntities.Except(currentEntities, getKey);
            var deletedEntities = currentEntities.Except(newEntities, getKey);
            var modifiedEntities = newEntities.Except(addedEntities, getKey);

            var dbSet = db.Set<TEntity>();

            dbSet.AddRange(addedEntities);
            dbSet.RemoveRange(deletedEntities);

            foreach (TEntity entity in modifiedEntities)
            {
                var existingItem = dbSet.Find(entity.Id);

                if (existingItem != null)
                {
                    var entityEntry = db.Entry(existingItem);
                    entityEntry.CurrentValues.SetValues(entity);
                }
            }
        }

        public static void TryUpdateManyToMany<T, TKey>(this DbContext db, IEnumerable<T> currentEntities, IEnumerable<T> newEntities, Func<T, TKey> getKey) where T : class
        {
            db.Set<T>().RemoveRange(currentEntities.Except(newEntities, getKey));
            db.Set<T>().AddRange(newEntities.Except(currentEntities, getKey));
        }

        public static IEnumerable<T> Except<T, TKey>(this IEnumerable<T> entities, IEnumerable<T> other, Func<T, TKey> getKey)
        {
            return from entity in entities
                   join otherItem in other on getKey(entity)
                   equals getKey(otherItem) into tempEntities
                   from temp in tempEntities.DefaultIfEmpty()
                   where ReferenceEquals(null, temp) || temp.Equals(default(T))
                   select entity;
        }
    }
}