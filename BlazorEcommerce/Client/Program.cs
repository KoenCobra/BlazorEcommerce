using BlazorEcommerce.Client;
using BlazorEcommerce.Client.Settings;
using BlazorECommerce.Sdk.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(settings);

builder.Services.AddApi(settings.ApiBaseUrl);
builder.Services.AddSingleton<AppSettings>();

await builder.Build().RunAsync();
