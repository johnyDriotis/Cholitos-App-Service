using GimnasioService.Core.Dtos;
using GimnasioService.Core.Request;
using GimnasioService.Core.Response;

namespace GimnasioService.Core.UseCases.Interfaces
{
    public interface IClientUseCase
    {
        Task<GenericResponse<ClientDto>> AddClient(ClientRequest clientRequest);
    }
}
