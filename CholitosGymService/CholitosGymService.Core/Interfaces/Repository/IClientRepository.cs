using CholitosGymService.Core.Request;
using CholitosGymService.Core.Response;

namespace CholitosGymService.Core.Interfaces.Repository
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
