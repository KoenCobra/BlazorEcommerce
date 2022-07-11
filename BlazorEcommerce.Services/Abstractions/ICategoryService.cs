using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategories();
    }
}
