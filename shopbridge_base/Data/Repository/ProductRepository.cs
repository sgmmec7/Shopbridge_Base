using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Shopbridge_Context dbcontext;

        public ProductRepository(Shopbridge_Context _dbcontext)
        {
            this.dbcontext = _dbcontext;
        }

        public async Task<List<Product>> GetProduct()
        {
            return await dbcontext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProduct(int id)
        {
            return await dbcontext.Products.Where(p => p.ProductId == id).ToListAsync();
        }

        public bool ProductExists(int id)
        {
            return dbcontext.Products.Any(p => p.ProductId == id);
        }

        public async Task<Product> PostProduct(Product product)
        {
            dbcontext.Products.Add(product);
            await dbcontext.SaveChangesAsync();
            return product;
        }

        public async Task PutProduct(int id, Product product)
        {
            var productResult = dbcontext.Products.Where(p => p.ProductId == id).FirstOrDefault();
            productResult.ProductName = product.ProductName;
            productResult.ProductDescription = product.ProductDescription;
            productResult.Price = product.Price;
            productResult.TotalQuantity = product.TotalQuantity;
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var productResult = dbcontext.Products.Where(p => p.ProductId == id).FirstOrDefault();
            dbcontext.Products.Remove(productResult);
            await dbcontext.SaveChangesAsync();
        }
    }
}
