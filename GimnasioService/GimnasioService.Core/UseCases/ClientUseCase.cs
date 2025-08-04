using GimnasioService.Core.Interfaces;
using GimnasioService.Core.Interfaces.Repository;
using GimnasioService.Core.Request;
using GimnasioService.Core.Response;
using GimnasioService.Core.UseCases.Interfaces;
using System.Net;

namespace GimnasioService.Core.UseCases
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
