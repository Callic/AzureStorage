namespace AzureStorage.API.Responses
{
    public class GenericResponse<T> where T : class
    {
        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
