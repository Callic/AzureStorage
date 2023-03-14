using Azure.Data.Tables;
using Azure.Identity;
using Azure.Storage.Blobs;
using AzureStorage.API.Extensions;
using AzureStorage.API.Interfaces;
using Microsoft.Extensions.Options;
using System;

namespace AzureStorage.API.Services
{
    public class AzureStorageClient : IAzureStorageClient
    {
        private readonly AppSettings _settings;
        public AzureStorageClient(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }
        public BlobContainerClient GetBlobContainerClient(string containerName)
        {
            return new BlobContainerClient(
                new Uri($"{_settings.Azure.Storage.BlobUrl}/{containerName}"),
                new DefaultAzureCredential());
        }

        public TableServiceClient GetTableServiceClient()
        {
            return new TableServiceClient(_settings.Azure.Storage.ConnectionStringTable);
        }
    }
}
