using Azure;
using Azure.Data.Tables;
using AzureStorage.API.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AzureStorage.API.ViewModel
{
    [ModelBinder(BinderType = typeof(ClienteModelBinder))]
    public class ClienteViewModel
    {
        public string? RowKey { get; set; }
        public string Nome { get; set; } = default!;
        public IFormFile Imagem { get; set; }
        
        public string? UrlImagem { get; set; }
    }
}
