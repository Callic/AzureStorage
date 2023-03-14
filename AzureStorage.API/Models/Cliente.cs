using Azure;
using Azure.Data.Tables;

namespace AzureStorage.API.Models
{
    public class Cliente : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
    }
}
