using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Library.Infrastructure.Storage
{
    internal static class MongoExtensions
    {
        internal static IQueryable<TResult> Select<T, TResult>(this IQueryable<T> queryable, Expression<Func<T, TResult>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Select(mongoQueryable, filter);
            }

            return Queryable.Select(queryable, filter);
        }

        internal static IQueryable<TResult> SelectMany<T, TResult>(this IQueryable<T> queryable, Expression<Func<T, IEnumerable<TResult>>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.SelectMany(mongoQueryable, filter);
            }

            return Queryable.SelectMany(queryable, filter);
        }

        internal static IQueryable<T> Where<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Where(mongoQueryable, filter);
            }

            return Queryable.Where(queryable, filter);
        }

        internal static IQueryable<T> Distinct<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Distinct(mongoQueryable);
            }

            return Queryable.Distinct(queryable);
        }

        internal static IQueryable<T> OrderBy<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.OrderBy(mongoQueryable, filter);
            }

            return Queryable.OrderBy(queryable, filter);
        }

        internal static IOrderedQueryable<T> OrderByDescending<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.OrderByDescending(mongoQueryable, filter);
            }

            return Queryable.OrderByDescending(queryable, filter);
        }

        internal static IQueryable<T> ThenBy<T, TKey>(this IOrderedQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IOrderedMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.ThenBy(mongoQueryable, filter);
            }

            return Queryable.ThenBy(queryable, filter);
        }

        internal static IQueryable<T> ThenByDescending<T, TKey>(this IOrderedQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IOrderedMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.ThenByDescending(mongoQueryable, filter);
            }

            return Queryable.ThenByDescending(queryable, filter);
        }

        internal static IQueryable<TResult> OfType<TResult>(this IQueryable queryable)
        {
            if (queryable is IMongoQueryable mongoQueryable)
            {
                return MongoQueryable.OfType<TResult>(mongoQueryable);
            }

            return Queryable.OfType<TResult>(queryable);
        }

        internal static IQueryable<IGrouping<TKey, T>> GroupBy<T, TKey>(this IQueryable<T> queryable, Expression<Func<T, TKey>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.GroupBy(mongoQueryable, filter);
            }

            return Queryable.GroupBy(queryable, filter);
        }

        internal static IQueryable<T> Skip<T>(this IQueryable<T> queryable, int count)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Skip(mongoQueryable, count);
            }

            return Queryable.Skip(queryable, count);
        }

        internal static IQueryable<T> Take<T>(this IQueryable<T> queryable, int count)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.Take(mongoQueryable, count);
            }

            return Queryable.Take(queryable, count);
        }

        internal static Task<bool> AnyAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.AnyAsync(mongoQueryable, filter);
            }

            return Task.FromResult(Queryable.Any(queryable, filter));
        }

        internal static Task<TResult> MinAsync<T, TResult>(this IQueryable<T> queryable, Expression<Func<T, TResult>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.MinAsync(mongoQueryable, filter);
            }

            return Task.FromResult(Queryable.Min(queryable, filter));
        }

        internal static Task<TResult> MaxAsync<T, TResult>(this IQueryable<T> queryable, Expression<Func<T, TResult>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.MaxAsync(mongoQueryable, filter);
            }

            return Task.FromResult(Queryable.Max(queryable, filter));
        }

        internal static Task<T> FirstAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.FirstAsync(mongoQueryable);
            }

            return Task.FromResult(Queryable.First(queryable));
        }

        internal static Task<T> FirstAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.FirstAsync(mongoQueryable, filter);
            }

            return Task.FromResult(Queryable.First(queryable, filter));
        }

        internal static Task<T?> FirstOrDefaultAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.FirstOrDefaultAsync(mongoQueryable);
            }

            return Task.FromResult(Queryable.FirstOrDefault(queryable));
        }

        internal static Task<T?> FirstOrDefaultAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.FirstOrDefaultAsync(mongoQueryable, filter);
            }

            return Task.FromResult(Queryable.FirstOrDefault(queryable, filter));
        }

        internal static Task<T> SingleAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.SingleAsync(mongoQueryable);
            }

            return Task.FromResult(Queryable.Single(queryable));
        }

        internal static Task<T> SingleAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.SingleAsync(mongoQueryable, filter);
            }

            return Task.FromResult(Queryable.Single(queryable, filter));
        }

        internal static Task<T?> SingleOrDefaultAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.SingleOrDefaultAsync(mongoQueryable);
            }

            return Task.FromResult(Queryable.SingleOrDefault(queryable));
        }

        internal static Task<T?> SingleOrDefaultAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.SingleOrDefaultAsync(mongoQueryable, filter);
            }

            return Task.FromResult(Queryable.SingleOrDefault(queryable, filter));
        }

        internal static Task<int> CountAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.CountAsync(mongoQueryable);
            }

            return Task.FromResult(Queryable.Count(queryable));
        }

        internal static Task<int> CountAsync<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter)
        {
            if (queryable is IMongoQueryable<T> mongoQueryable)
            {
                return MongoQueryable.CountAsync(mongoQueryable, filter);
            }

            return Task.FromResult(Queryable.Count(queryable, filter));
        }

        internal static Task<List<T>> ToListAsync<T>(this IQueryable<T> queryable)
        {
            if (queryable is IAsyncCursorSource<T> cursorSource)
            {
                return cursorSource.ToListAsync();
            }

            return Task.FromResult(queryable.ToList());
        }
    }
}
