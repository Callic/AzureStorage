using Azure.Storage.Blobs.Models;

namespace AzureStorage.API.Responses
{
    public class AzureBlobStorageResponse
    {
        public BlobContentInfo BlobContentInfo { get; set; }
        public string UrlImage { get; set; }
    }
}
