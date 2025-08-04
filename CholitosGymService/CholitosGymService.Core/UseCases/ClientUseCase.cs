using CholitosGymService.Core.Interfaces;
using CholitosGymService.Core.Interfaces.Repository;
using CholitosGymService.Core.Request;
using CholitosGymService.Core.Response;
using CholitosGymService.Core.UseCases.Interfaces;
using System.Net;

namespace CholitosGymService.Core.UseCases
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IClientRepository _clientRepository;

        public ClientUseCase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<GenericResponse<string>> AddClient(ClientRequest clientRequest)
        {
            GenericResponseBd<string> genericResponseBd = new GenericResponseBd<string>();
            GenericResponse<string> genericResponse = new GenericResponse<string>();

            genericResponseBd = await _clientRepository.AddClient(clientRequest);

            if (genericResponseBd.IsError) {
                return genericResponse = new GenericResponse<string>()
                {
                    HttpResponseStatus = new ResponseStatus { 
                        StatusCode = HttpStatusCode.InternalServerError,
                        Descripcion = "Ocurrio un error al agregar el cliente"
                    },
                    Item = ""
                };
            }

            return genericResponse = new GenericResponse<string>()
            {
                HttpResponseStatus = new ResponseStatus
                {
                    StatusCode = HttpStatusCode.OK,
                    Descripcion = genericResponseBd.SuccessMessage
                },
                Item = genericResponseBd.SuccessMessage
            };
        }
    }
}
