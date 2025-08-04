using GimnasioService.Core.Request;
using GimnasioService.Core.Response;

namespace GimnasioService.Core.UseCases.Interfaces
{
    public interface IClientUseCase
    {
        Task<GenericResponse<string>> AddClient(ClientRequest clientRequest);
    }
}
