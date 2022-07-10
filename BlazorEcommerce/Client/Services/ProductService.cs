using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public List<Product> Products { get; set; }

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProducts()
        {
            var result =await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
            Products = result.Data;
        }
    }
}
