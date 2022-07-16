﻿using BlazorECommerce.Data;
using BlazorEcommerce.Services.Abstractions;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _dataContext.Products.Include(p => p.ProductVariants).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _dataContext.Products
                .Include(p=>p.ProductVariants)
                .ThenInclude(v=>v.ProductType)
                .FirstOrDefaultAsync(p=>p.Id == productId);

            if (product == null)
            {
                response.Succes = false;
                response.Message = "Sorry, this product does not exist";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _dataContext.Products
                    .Where(x=>x.Category.Url.ToLower() == categoryUrl.ToLower())
                    .Include(p => p.ProductVariants)
                    .ToListAsync()
            };
            return response;
        }
    }
}
