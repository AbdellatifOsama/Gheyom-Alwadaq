using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GheyomAlwadaqTask.BLL.Specification
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> QueryInit, ISpecification<T> specification)
        {
            var Query = QueryInit;
            if (specification.Criteria is not null)
            {
                Query = Query.Where(specification.Criteria);
            }
            if (specification.Order is not null)
            {
                Query = Query.OrderBy(specification.Order);
            }
            if (specification.OrderDesc is not null)
            {
                Query = Query.OrderByDescending(specification.OrderDesc);
            }
            if (specification.IsPaginationEnabled)
            {
                Query = Query.Skip(specification.Skip).Take(specification.Take);
            }
            //Query = specification.Includes.Aggregate(Query, (currentQuery, include) => currentQuery.Include(include));
            return Query;
        }
    }
}
