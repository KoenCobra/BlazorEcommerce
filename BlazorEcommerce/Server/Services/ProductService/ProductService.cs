using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _dataContext.Products.ToListAsync()
            };

            return response;
        }

        public Task<Product> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
