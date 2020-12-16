using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class productRepository : RepositoryBase<Product>, IproductRepository


    {
         public productRepository(DbcontextRepo dbcontext):base(dbcontext)
        {
            
        }

        public void Createproduct(Product prod) => Create(prod);


        public void Deleteproduct(Product prod) => Delete(prod);


        public async Task<Product> FindproductAsyn(int? _id)
        {
           return await FindByCondition(x => x.Id == _id,false).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetproductAsyn(bool trackCheckes) =>await FindAll(false).ToListAsync();


        public async Task<IEnumerable<Product>> productSearchAsync(string prodpName )
        {
            return await FindByCondition(x => x.Name == prodpName ,trackChanges:false).ToListAsync();
        }

        public void Updateproduct(Product prod) => Update(prod);
        
    }
}
