using Azure.Data.Tables.Models;
using AzureStorage.API.Models;

namespace AzureStorage.API.Interfaces
{
    public interface IAzureTableStorage
    {
        Task<Azure.Response<TableItem>> CreateTable(string tableName);
        Task<Azure.Response> AdicionarCliente(Cliente clienteViewModel);
    }
}
