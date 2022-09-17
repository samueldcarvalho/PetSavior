using AdoteUmPet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.Infrastructure
{
    public static class RepositoryFilterableExtensions
    {
        public static IQueryable<TReturn> FindAllByFilter<TSource, TReturn>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> filter, Expression<Func<TSource, TReturn>> select)
        {
            Expression<Func<TSource, bool>> predicate = Expression.Lambda<Func<TSource, bool>>(filter);

            IQueryable<TSource> filteredSource = source.Where(predicate);

            return filteredSource.Select(select);
        }

        public static TReturn FindFirstOrDefaultByFilter<TSource, TReturn>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> filter, Expression<Func<TSource, TReturn>> select)
        {
            Expression<Func<TSource, bool>> predicate = Expression.Lambda<Func<TSource, bool>>(filter);

            IQueryable<TSource> filteredSource = source.Where(predicate);

            return filteredSource.Select(select).FirstOrDefault();
        }
    }
}
