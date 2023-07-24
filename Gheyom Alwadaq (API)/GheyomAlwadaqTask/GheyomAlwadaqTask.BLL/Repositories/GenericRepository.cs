using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.BLL.Specification;
using GheyomAlwadaqTask.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly GheyomAlwadaqContext context;

        public GenericRepository(GheyomAlwadaqContext context)
        {
            this.context = context;
        }
        public async Task Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<T> GetById(string id)
        {
            var item = context.Set<T>().Find(id);
            return item;
        }
        public async Task<List<T>> GetAll()
        {
            var items = await context.Set<T>().ToListAsync();
            return items;
        }
        //public async Task<T> GetByIdWithSpecAsync(Specification<T> spec)
        //{
        //    return await (await ApplySpecification(spec)).FirstOrDefaultAsync();
        //}
        public async Task<List<T>> GetAllWithSpecAsync(Specification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        private IQueryable<T> ApplySpecification(Specification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec);
        }
    }
}
