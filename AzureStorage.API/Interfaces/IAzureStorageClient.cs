using Azure.Data.Tables;
using Azure.Storage.Blobs;

namespace AzureStorage.API.Interfaces
{
    public interface IAzureStorageClient
    {
        /// <summary>
        /// Buscar um container pelo nome
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        BlobContainerClient GetBlobContainerClient(string containerName);

        /// <summary>
        /// Serviço gerenciador das tabelas do azure storage
        /// </summary>
        /// <returns></returns>
        TableServiceClient GetTableServiceClient();
    }
}
