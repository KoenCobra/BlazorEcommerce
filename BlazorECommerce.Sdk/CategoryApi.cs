using System.Net.Http.Json;
using BlazorECommerce.Sdk.Abstractions;
using BlazorEcommerce.Shared;

namespace BlazorECommerce.Sdk
{
    public class CategoryApi : ICategoryApi
    {
        private readonly IHttpClientFactory _client;

        public CategoryApi(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<ServiceResponse<List<Category>>> GetAllCategories()
        {
            var client = _client.CreateClient("BlazorECommerce");

            var route = "Api/Category";

            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Category>>>();

            if (result is null)
            {
                return new ServiceResponse<List<Category>>();
            }

            return result;
        }
    }
}
