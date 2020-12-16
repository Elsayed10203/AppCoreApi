using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<bool> IsUnique(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> ExecuteStoredAsync(string query);
        Task<IQueryable<T>> ExecuteStoredWithParaAsync(string query, params object[] parameters);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
