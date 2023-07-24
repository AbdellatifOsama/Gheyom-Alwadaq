using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> Order { get; set; }
        public Expression<Func<T, object>> OrderDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }
        public Specification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }
        public Specification()
        {

        }
        public void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
        public void OrderBy(Expression<Func<T, object>> order)
        {
            Order = order;
        }
        public void OrderByDesc(Expression<Func<T, object>> orderDesc)
        {
            OrderDesc = orderDesc;
        }
        public void ApplyPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
