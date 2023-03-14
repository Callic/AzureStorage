using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureStorage.API.Responses;

namespace AzureStorage.API.Interfaces
{
    public interface IAzureBlobStorageClient
    {
        Task<GenericResponse<AzureBlobStorageResponse>> UploadFileStreamAsync(string containerName, string fileName, IFormFile file, bool overwrite = true);
        Task<bool> DeleteBlobAsync(string containerName, string fileName);
        Task<bool> DeleteBlobAsync(string url);
        BlobClient DownloadBlob(string containerName, string fileName);
    }
}
