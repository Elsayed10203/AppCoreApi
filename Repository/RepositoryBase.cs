using Contracts;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> :IDisposable , IRepositoryBase<T> where T : class, new()
    {
        public readonly DbcontextRepo RepositoryContext;

        public RepositoryBase(DbcontextRepo _RepositoryContext)
        {
            RepositoryContext = _RepositoryContext;
         }
        public void Create(T entity) => RepositoryContext.Add(entity);


        public void Delete(T entity) => RepositoryContext.Remove(entity);

        public void Dispose()
        {
            RepositoryContext.SaveChangesAsync();
        }

        public Task<IQueryable<T>> ExecuteStoredAsync(string query) =>
            RepositoryContext.ExecuteStoredByNameAsync<T>(query);



        public Task<IQueryable<T>> ExecuteStoredWithParaAsync(string query, params object[] parameters) =>
            RepositoryContext.ExecuteStoredByNameAsync<T>(query, parameters);



        public IQueryable<T> FindAll(bool trackChanges) =>
                    trackChanges ? RepositoryContext.Set<T>() : RepositoryContext.Set<T>().AsNoTracking();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)=>
            trackChanges ? RepositoryContext.Set<T>().Where(expression) : RepositoryContext.Set<T>().Where(expression).AsNoTracking();



        public async Task<bool> IsUnique(Expression<Func<T, bool>> expression)=>
                   await RepositoryContext.Set<T>().AnyAsync(expression) ? false : true;

        public void Update(T entity) => RepositoryContext.Update(entity);

      

       

        void IRepositoryBase<T>.SaveChanges()
        {
            RepositoryContext.SaveChangesAsync();
        }
    }
}
