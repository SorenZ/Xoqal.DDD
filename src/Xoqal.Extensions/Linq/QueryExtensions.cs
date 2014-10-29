using System;
using System.Linq;
using System.Linq.Expressions;

namespace Xoqal.Extensions.Linq
{
    /// <summary>
    /// IQueryable Helpers
    /// </summary>
    public static class QueryableExtension
    {
        /// <summary>
        /// 'Select' by condition before query executed in provider.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="condition">the condition</param>
        /// <param name="trueExpression">The expression that will apply if <see cref="condition"/> is true.</param>
        /// <param name="falseExpression">The expression that will apply if <see cref="condition"/> is false.</param>
        /// <returns>
        /// filtered query
        /// </returns>
        public static IQueryable<TResult> SelectIf<TSource, TResult>(
            this IQueryable<TSource> source,
            bool condition,
            Expression<Func<TSource, TResult>> trueExpression,
            Expression<Func<TSource, TResult>> falseExpression)
        {
            return condition ? source.Select(trueExpression) : source.Select(falseExpression);
        }

        /// <summary>
        /// Conditional 'Where', decide about predicate before query executed in provider.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="condition">the condition</param>
        /// <param name="trueExpression">The expression that will apply if <see cref="condition"/> is true.</param>
        /// <param name="falseExpression">The expression that will apply if <see cref="condition"/> is false.</param>
        /// <returns>
        /// filtered query
        /// </returns>
        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> source,
            bool condition,
            Expression<Func<T, bool>> trueExpression,
            Expression<Func<T, bool>> falseExpression)
        {
            return condition ? source.Where(trueExpression) : source.Where(falseExpression);
        }

        /// <summary>
        /// LINQ Between Operator
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        /// <example>var query = db.People.Between(person => person.Age, 18, 21);</example>
        /// <remarks>http://stackoverflow.com/questions/1447635/linq-between-operator</remarks>
        public static IQueryable<TSource> Between<TSource, TKey>
            (this IQueryable<TSource> source,
                Expression<Func<TSource, TKey>> keySelector,
                TKey low, TKey high) where TKey : IComparable<TKey>
        {
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");

            Expression key = Expression.Invoke(keySelector,
                keySelector.Parameters.ToArray());

            Expression lowerBound = Expression.GreaterThanOrEqual
                (key, Expression.Constant(low));

            Expression upperBound = Expression.LessThanOrEqual
                (key, Expression.Constant(high));

            Expression and = Expression.AndAlso(lowerBound, upperBound);

            Expression<Func<TSource, bool>> lambda =
                Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);

            return source.Where(lambda);
        }
    }
}
