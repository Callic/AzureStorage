using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using AzureStorage.API.Interfaces;
using AzureStorage.API.Responses;

namespace AzureStorage.API.Services
{
    public class AzureBlobStorageClient : IAzureBlobStorageClient
    {
        private readonly IAzureStorageClient _client;
        public AzureBlobStorageClient(IAzureStorageClient client)
        {
            _client = client;
        }
        public async Task<GenericResponse<AzureBlobStorageResponse>> UploadFileStreamAsync(string containerName, string fileName, IFormFile file, bool overwrite = true)
        {
            var result = new GenericResponse<AzureBlobStorageResponse>();
            try
            {
                var containerClient = _client.GetBlobContainerClient(containerName);

                if (string.IsNullOrEmpty(fileName)) fileName = file.FileName;

                BlobClient blobClient = containerClient.GetBlobClient($"{fileName}");

                result.Success = true;
                result.Data = new AzureBlobStorageResponse();
                result.Data.BlobContentInfo = blobClient.UploadAsync(file.OpenReadStream(), overwrite).Result.Value;
                result.Data.UrlImage = blobClient.Uri.AbsoluteUri;
                file.OpenReadStream().Close();
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Errors.Add(ex.Message);
                return result;
            }
        }


        public async Task<bool> DeleteBlobAsync(string containerName, string fileName)
        {
            var containerClient = _client.GetBlobContainerClient(containerName);

            return await containerClient.DeleteBlobIfExistsAsync(fileName);
        }

        public BlobClient DownloadBlob(string containerName, string fileName)
        {
            var containerClient = _client.GetBlobContainerClient(containerName);
            return containerClient.GetBlobClient(fileName);

        }

        public async Task<bool> DeleteBlobAsync(string url)
        {
            var blobClient = new BlobClient(new Uri(url),
                new DefaultAzureCredential());
            await blobClient.DeleteIfExistsAsync();
            
            return true;
        }
    }
}
