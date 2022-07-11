using System.ComponentModel.DataAnnotations;
using BlazorECommerce.Sdk.Abstractions;
using System.Net.Http;
using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace BlazorECommerce.Sdk
{
    public class ProductApi : IProductApi
    {
        private readonly IHttpClientFactory _client;

        public ProductApi(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var client = _client.CreateClient("BlazorECommerce");

            var route = "Api/Product";

            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Product>>>();

            if (result is null)
            {
                return new ServiceResponse<List<Product>>();
            }

            return result;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            var client = _client.CreateClient("BlazorECommerce");

            var route = $"Api/Product/{id}";

            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Product>>();

            if (result is null)
            {
                return new ServiceResponse<Product>();
            }

            return result;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var client = _client.CreateClient("BlazorECommerce");

            var route = $"Api/Product/category/{categoryUrl}";

            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Product>>>();

            if (result is null)
            {
                return new ServiceResponse<List<Product>>();
            }

            return result;
        }
    }
}
