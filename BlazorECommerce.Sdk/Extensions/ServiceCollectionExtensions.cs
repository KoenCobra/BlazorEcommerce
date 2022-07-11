using BlazorECommerce.Sdk.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorECommerce.Sdk.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApi(this IServiceCollection services, string baseUrl)
    {
        services.AddApi(new Uri(baseUrl));
    }

    private static void AddApi(this IServiceCollection services, Uri baseUri)
    {
        services.AddHttpClient("BlazorECommerce", (sp, c) =>
            {
                c.BaseAddress = baseUri;
            });

        services.AddTransient<IProductApi, ProductApi>();
        services.AddTransient<ICategoryApi, CategoryApi>();

    }
}