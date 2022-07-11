using BlazorEcommerce.Shared;

namespace BlazorECommerce.Sdk.Abstractions
{
    public interface IProductApi
    {
        Task<ServiceResponse<List<Product>>> GetProducts();
        Task<ServiceResponse<Product>> GetProduct(int id);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
    }
}
