using Microsoft.Extensions.Logging;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;
        private readonly IProductRepository productRepository;
        public ProductService(ILogger<ProductService> _logger, IProductRepository _productRepository)
        {
            this.logger = logger;
            this.productRepository = _productRepository;
        }

        public async Task<List<Product>> GetProduct()
        {
            return await productRepository.GetProduct();
        }

        public async Task<List<Product>> GetProduct(int id)
        {
            return await productRepository.GetProduct(id);
        }

        public bool ProductExists(int id)
        {
            return productRepository.ProductExists(id);
        }

        public async Task<Product> PostProduct(Product product)
        {
            return await productRepository.PostProduct(product);
        }

        public async Task PutProduct(int id, Product product)
        {
            await productRepository.PutProduct(id, product);
        }

        public async Task DeleteProduct(int id)
        {
            await productRepository.DeleteProduct(id);
        }
    }
}
