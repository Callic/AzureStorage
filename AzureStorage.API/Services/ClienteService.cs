using AzureStorage.API.Interfaces;
using AzureStorage.API.Models;
using AzureStorage.API.Responses;
using AzureStorage.API.ViewModel;

namespace AzureStorage.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IAzureBlobStorageClient _azureBlobStorageClient;
        private readonly IAzureTableStorage _azureTableStorage;
        public ClienteService(IAzureBlobStorageClient azureBlobStorageClient, IAzureTableStorage azureTableStorage)
        {
            _azureBlobStorageClient = azureBlobStorageClient;
            _azureTableStorage = azureTableStorage;
        }


        public async Task<GenericResponse<ClienteViewModel>> AdicionarCliente(ClienteViewModel clienteViewModel)
        {
            var response = new GenericResponse<ClienteViewModel>();

            var result = await _azureBlobStorageClient.UploadFileStreamAsync("devstorage", "", clienteViewModel.Imagem);

            if (!result.Success)
            {
                response.Success = false;
                response.Errors.AddRange(result.Errors);
                return response;
            }

            clienteViewModel.UrlImagem = result.Data!.UrlImage;
            
            //TODO: utilizar AutoMapper para esta tarefa.
            var cliente = new Cliente()
            {
                Nome = clienteViewModel.Nome,
                UrlImagem = clienteViewModel.UrlImagem,
                PartitionKey = "Cliente",
            };

            var client = await _azureTableStorage.AdicionarCliente(cliente);
            if (client.Status is not StatusCodes.Status204NoContent)
            {
                response.Success = false;
                response.Errors.Add("Falha ao salvar registro. Tente novamento ou contate o suporte!");
                await _azureBlobStorageClient.DeleteBlobAsync(result.Data.UrlImage);
                return response;
            }

            //TODO: utilizar AutoMapper para esta tarefa.
            clienteViewModel.RowKey = cliente.RowKey;
            
            response.Data = clienteViewModel;
            return response;

        }

        
    }
}
