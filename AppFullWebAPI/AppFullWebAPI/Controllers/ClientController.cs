using AppFullWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AppFullWebAPI.Controllers
{

    [ApiController] // Se le indica al controlador que pertenece a web api.
    [Route("api/[controller]")] // Se le indica la ruta a la que debe responder al realizar las peticiones http.
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route(template: "All", Name = "GetAllClients" )]
        public ActionResult<IEnumerable<Client>> GetClients() {

            // Ok = 200 - Success
            return Ok(ClientRepository.Clients);
        }

        [HttpGet]
        #region Documentacion de Status Codes - Saldran los esquemas
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [Route(template: "{id:int}", Name = "GetClientById")]
        public ActionResult<Client> GetClientById(int id)
        {
            // BadRequest - 400 - BadRequest - Client Error
            if (id <= 0)
                return BadRequest("El id debe ser mayor a 0");

            var foundClient = ClientRepository.Clients.Where(x => x.Id == id).FirstOrDefault();

            // NotFound - 404 - NotFound - No data found
            if (foundClient == null)
                return NotFound($"No se encontro el cliente con id {id}");

            // Ok - 200 - Success
            if (foundClient != null)
            {
                return Ok(foundClient);
            }

            // BadRequest - 400 - BadRequest - Error no controlado
            return BadRequest("No se pudo controlar el error");
        }

        [HttpGet]
        #region Documentacion de Status Codes
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [Route(template: "{name:alpha}", Name = "GetClientByName")]
        public ActionResult GetClientByName(string name)
        {
            var foundClient = ClientRepository.Clients.Where(x => x.PrimerNombre?.ToLower() == name).FirstOrDefault();

            // NotFound - 404 - NotFound - No data found
            if (foundClient == null)
                return NotFound($"No se encontro el cliente con nombre {name}");

            // Ok - 200 - Success
            if (foundClient != null)
            {
                return Ok(foundClient);
            }

            // BadRequest - 400 - BadRequest - Error no controlado
            return BadRequest("No se pudo controlar el error");
        }

        [HttpDelete]
        #region Documentacion de Status Codes - Saldran los esquemas
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        #endregion
        [Route(template: "{id:int}", Name = "DeleteClient")]
        public ActionResult<bool> DeleteClient(int id) {

            // BadRequest - 400 - BadRequest - Client Error
            if (id <= 0)
                return BadRequest("El id debe ser mayor a 0");

            var foundClient = ClientRepository.Clients.Where(x => x.Id == id).FirstOrDefault();

            // NotFound - 404 - NotFound - No data found
            if (foundClient == null)
                return NotFound($"No se encontro el cliente con id {id}");

            // Ok - 200 - Success
            if (foundClient != null) {
                ClientRepository.Clients.Remove(foundClient);
                return Ok(true);
            }

            // BadRequest - 400 - BadRequest - Error no controlado
            return BadRequest("No se pudo controlar el error");
        }
    }
}
