using CholitosGymService.Core.Request;
using CholitosGymService.Core.Response;

namespace CholitosGymService.Core.UseCases.Interfaces
{
    public interface IClientUseCase
    {
        Task<GenericResponse<string>> AddClient(ClientRequest clientRequest);
    }
}
