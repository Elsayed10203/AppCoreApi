using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IproductRepository
    {
        Task<IEnumerable<Product>> GetproductAsyn(bool trackCheckes);

        Task<Product> FindproductAsyn(int? id);
   
        void Createproduct(Product prod);
        void Deleteproduct(Product prod);
        void Updateproduct(Product prod);
    }
}
