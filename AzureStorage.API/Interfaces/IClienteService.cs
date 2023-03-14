using AzureStorage.API.Responses;
using AzureStorage.API.ViewModel;

namespace AzureStorage.API.Interfaces
{
    public interface IClienteService
    {
        Task<GenericResponse<ClienteViewModel>> AdicionarCliente(ClienteViewModel clienteViewModel);
    }
}
