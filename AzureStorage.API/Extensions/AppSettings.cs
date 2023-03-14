namespace AzureStorage.API.Extensions
{
    public class AppSettings
    {
        public Azure Azure { get; set; }
    }
    public class Azure
    {
        public Storage Storage { get; set; }
    }
    public class Storage
    {
        public string BlobUrl { get; set; }
        public string ConnectionStringTable { get; set; }
    }
}
