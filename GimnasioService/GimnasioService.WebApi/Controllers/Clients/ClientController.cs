using GimnasioService.Core.Request;
using GimnasioService.Core.Response;
using GimnasioService.Core.UseCases.Interfaces;
using libzkfpcsharp;
using Microsoft.AspNetCore.Mvc;

namespace GimnasioService.WebApi.Controllers.Clientes
{

    [ApiController] // Se le indica al controlador que pertenece a web api.
    [Route("api/[controller]")] // Se le indica la ruta a la que debe responder al realizar las peticiones http.
    public class ClientController : ControllerBase
    {
        private readonly IClientUseCase _clientUseCase;

        public ClientController(IClientUseCase clientUseCase)
        {
            _clientUseCase = clientUseCase ?? throw new ArgumentNullException(nameof(clientUseCase));
        }

        [HttpPost]
        [Route(template: "Create", Name = "CreateClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<GenericResponse<string>> CreateClient([FromBody] ClientRequest clientRequest)
        {
            return _clientUseCase.AddClient(clientRequest);
        }
    }
}
