using AzureStorage.API.Interfaces;
using AzureStorage.API.Services;

namespace AzureStorage.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAzureStorageClient, AzureStorageClient>();
            services.AddScoped<IAzureBlobStorageClient, AzureBlobStorageClient>();
            services.AddScoped<IAzureTableStorage, AzureTableStorageClient>();
            services.AddScoped<IClienteService, ClienteService>();
        }
    }
}
