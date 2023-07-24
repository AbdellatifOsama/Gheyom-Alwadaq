using GheyomAlwadaqTask.BLL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(T entity);
        public Task<T> GetById(string id);
        public Task<List<T>> GetAll();
        //public Task<T> GetByIdWithSpecAsync(Specification<T> spec);
        public Task<List<T>> GetAllWithSpecAsync(Specification<T> spec);

    }
}
