using CholitosGymService.Core.Interfaces;
using CholitosGymService.Core.UseCases.Interfaces;

namespace CholitosGymService.Core.UseCases
{
    public class ClientUseCase : IClientUseCase
    {

        public ClientUseCase()
        {

        }


        //private readonly IClientRepository _clientRepository;

        //public ClientUseCase(IClientRepository clientRepository)
        //{
        //    _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        //}

        //public async Task<GenericResponse<List<ClientDto>>> GetAllClients()
        //{
        //    var response = await _clientRepository.GetAllClients();
        //    return response;
        //}

        //public async Task<GenericResponse<ClientDto>> AddClient(ClientRequest clientRequest)
        //{
        //    var response = await _clientRepository.AddClient(clientRequest);
        //    return response;
        //}

        //public async Task<GenericResponse<ClientDto>> ModifyClient(ClientRequest clientRequest)
        //{
        //    var response = await _clientRepository.ModifyClient(clientRequest);
        //    return response;
        //}

        //public async Task<GenericResponse<ClientDto>> DeleteClient(ClientRequest clientRequest)
        //{
        //    var response = await _clientRepository.DeleteClient(clientRequest);
        //    return response;
        //}

        //public async Task<GenericResponse<ClientDto>> ChangeStateClient(ClientRequest clientRequest)
        //{
        //    var response = await _clientRepository.ChangeStateClient(clientRequest);
        //    return response;
        //}

        //public async Task<GenericResponse<ClientDto>> GetClientById(int idCliente)
        //{
        //    var response = await _clientRepository.GetClientById(idCliente);
        //    return response;
        //}
    }
}
