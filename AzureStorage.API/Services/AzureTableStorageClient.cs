using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using AzureStorage.API.Interfaces;
using AzureStorage.API.Models;
using AzureStorage.API.ViewModel;

namespace AzureStorage.API.Services
{
    public class AzureTableStorageClient : IAzureTableStorage
    {
        private readonly IAzureStorageClient _azureStorageClient;
        private TableServiceClient _tableServiceClient;
        public AzureTableStorageClient(IAzureStorageClient azureStorageClient)
        {
            _azureStorageClient = azureStorageClient;
            if (_tableServiceClient == null)
            {
                _tableServiceClient = _azureStorageClient.GetTableServiceClient();
            }
        }

        public async Task<Azure.Response<TableItem>> CreateTable(string tableName)
        {
            var client = _tableServiceClient.GetTableClient(tableName);
            return await client.CreateIfNotExistsAsync();
        }

        public async Task<Azure.Response> AdicionarCliente(Cliente cliente)
        {
            await CreateTable("Cliente");

            var client = _tableServiceClient.GetTableClient("Cliente");
            cliente.RowKey = Guid.NewGuid().ToString();


            return await client.AddEntityAsync<Cliente>(cliente);
        }

    }
}
