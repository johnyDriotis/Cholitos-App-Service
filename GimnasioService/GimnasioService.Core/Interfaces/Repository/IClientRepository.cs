using GimnasioService.Core.Request;
using GimnasioService.Core.Response;

namespace GimnasioService.Core.Interfaces.Repository
{
    public interface IClientRepository
    {
        //Task<GenericResponse<List<ClientDto>>> GetAllClients();
        Task<GenericResponseBd<string>> AddClient(ClientRequest clientRequest);

        //Task<GenericResponse<ClientDto>> ModifyClient(ClientRequest clientRequest);
        //Task<GenericResponse<ClientDto>> DeleteClient(ClientRequest clientRequest);
        //Task<GenericResponse<ClientDto>> ChangeStateClient(ClientRequest clientRequest);
        //Task<GenericResponse<ClientDto>> GetClientById(int idCliente);
    }
}
