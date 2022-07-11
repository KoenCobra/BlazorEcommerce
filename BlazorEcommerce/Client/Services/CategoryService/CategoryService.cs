using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public List<Category> Categories { get; set; } = new List<Category>();

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if (response != null && response.Data != null)
            {
                Categories = response.Data;
            }
        }
    }
}
