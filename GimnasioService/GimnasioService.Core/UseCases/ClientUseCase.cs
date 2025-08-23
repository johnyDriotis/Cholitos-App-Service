using GimnasioService.Core.Dtos;
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

        public async Task<GenericResponse<ClientDto>> AddClient(ClientRequest clientRequest)
        {
            GenericResponseBd<string> genericResponseBd = new GenericResponseBd<string>();
            GenericResponse<ClientDto> genericResponse = new GenericResponse<ClientDto>();

            genericResponseBd = await _clientRepository.AddClient(clientRequest);

            if (genericResponseBd.IsError) {
                return genericResponse = new GenericResponse<ClientDto>()
                {
                    HttpResponseStatus = new ResponseStatus { 
                        StatusCode = HttpStatusCode.InternalServerError,
                        Descripcion = "Ocurrio un error al agregar el cliente"
                    },
                    Item = new()
                };
            }

            return genericResponse = new GenericResponse<ClientDto>()
            {
                HttpResponseStatus = new ResponseStatus
                {
                    StatusCode = HttpStatusCode.OK,
                    Descripcion = genericResponseBd.SuccessMessage
                },
                Item = new() { 
                    CodigoCliente = genericResponseBd.Item,
                    PrimerNombre = clientRequest.PrimerNombre,
                    SegundoNombre = clientRequest.SegundoNombre,
                    PrimerApellido = clientRequest.PrimerApellido,
                    SegundoApellido = clientRequest.SegundoApellido,
                    ApellidoCasada = clientRequest.ApellidoCasada,
                }
            };
        }
    }
}
