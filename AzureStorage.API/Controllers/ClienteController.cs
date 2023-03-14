using AzureStorage.API.Interfaces;
using AzureStorage.API.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace AzureStorage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IAzureBlobStorageClient _azureBlobStorageClient;
        private readonly IClienteService _clienteService;
        
        public ClienteController(IAzureBlobStorageClient azureBlobStorageClient, IClienteService clienteService)
        {
            _azureBlobStorageClient = azureBlobStorageClient;
            _clienteService = clienteService;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }

        [HttpGet("teste")]
        public async Task<IActionResult> Teste()
        {
            await _azureBlobStorageClient.DeleteBlobAsync("https://saanpdevgustavo.blob.core.windows.net/devstorage/a9MDNwK_460s (1).jpg");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarCliente(ClienteViewModel clienteViewModel)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _clienteService.AdicionarCliente(clienteViewModel);

            return Ok(result);

        }
        [HttpDelete]
        public async Task<IActionResult> ExcluirCliente(string rowKey)
        {
            var result = await _azureBlobStorageClient.DeleteBlobAsync("devstorage", "a9MDNwK_460s (1).jpg");
            return Ok();
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download()
        {
            var result = _azureBlobStorageClient.DownloadBlob("devstorage", "cnpj gust.pdf");
            return File(result.OpenRead(), result.GetProperties().Value.ContentType, result.Name);
        }
    }

}
