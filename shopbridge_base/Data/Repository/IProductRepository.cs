using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProduct();
        Task<List<Product>> GetProduct(int id);
        bool ProductExists(int id);
        Task<Product> PostProduct(Product product);
        Task PutProduct(int id, Product product);
        Task DeleteProduct(int id);
    }
}
