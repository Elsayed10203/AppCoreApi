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
    public class RepositoryManager : IRepositoryManger
    {
        private IproductRepository _ProductRepsitory;

 
        public readonly DbcontextRepo _RepositoryContext;
        public RepositoryManager(DbcontextRepo RepositoryContext) =>
            _RepositoryContext = RepositoryContext;



        public IproductRepository products
        {
            get
            {
                if (_ProductRepsitory == null)
                {
                    _ProductRepsitory = new productRepository(_RepositoryContext);
                }
                return _ProductRepsitory;
            }
        }

 
        public async Task SaveChangesAsyn() => await _RepositoryContext.SaveChangesAsync();


    }
}
