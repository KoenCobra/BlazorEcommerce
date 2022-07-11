using BlazorEcommerce.Shared;

namespace BlazorECommerce.Sdk.Abstractions
{
    public interface ICategoryApi
    {
        Task<ServiceResponse<List<Category>>> GetAllCategories();
    }
}
