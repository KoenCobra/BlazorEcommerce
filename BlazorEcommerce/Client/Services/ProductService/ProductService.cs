using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public event Action? ProductsChanged;
        public List<Product> Products { get; set; }

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null
                ? await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product")
                : await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>(
                    $"api/Product/category/{categoryUrl}");

            Products = result.Data;

            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{id}");
            return result;
        }
    }
}
