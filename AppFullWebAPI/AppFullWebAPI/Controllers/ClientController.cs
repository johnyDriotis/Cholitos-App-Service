using CholitosGymWebApi.Models;
using CholitosGymWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CholitosGymWebAPI.Controllers
{

    [ApiController] // Se le indica al controlador que pertenece a web api.
    [Route("api/[controller]")] // Se le indica la ruta a la que debe responder al realizar las peticiones http.
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route(template: "All", Name = "GetAllClients" )]
        public ActionResult<IEnumerable<Client>> GetClients() {

            var clients = ClientRepository.Clients;
            var clientsDto = new List<ClientDTO>();

            // Forma normal de obtener y construir el DTO.
            foreach (var a in clients) {

                ClientDTO clientDto = new ClientDTO();

                clientDto.CodigoCliente = a.Id;
                clientDto.CorreoElectronico = "No tiene correo electronico";
                clientDto.TercerNombre = a.TercerNombre;
                clientDto.SegundoNombre = a.SegundoNombre;
                clientDto.PrimerNombre = a.PrimerNombre;
                clientDto.ApellidoCasada = a.ApellidoCasada;
                clientDto.Edad = a.Edad;
                clientDto.Genero = "M";
                clientDto.PrimerApellido = a.PrimerApellido;
                clientDto.SegundoApellido = a.SegundoApellido;

                clientsDto.Add(clientDto);
            }

            // Ok = 200 - Success
            return Ok(clientsDto);
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
            ClientDTO clientDto = new ClientDTO();

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
                clientDto.CodigoCliente = foundClient.Id;
                clientDto.CorreoElectronico = "No tiene correo electronico";
                clientDto.TercerNombre = foundClient.TercerNombre;
                clientDto.SegundoNombre = foundClient.SegundoNombre;
                clientDto.PrimerNombre = foundClient.PrimerNombre;
                clientDto.ApellidoCasada = foundClient.ApellidoCasada;
                clientDto.Edad = foundClient.Edad;
                clientDto.Genero = "M";
                clientDto.PrimerApellido = foundClient.PrimerApellido;
                clientDto.SegundoApellido = foundClient.SegundoApellido;

                return Ok(clientDto);
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
            ClientDTO clientDto = new ClientDTO();

            var foundClient = ClientRepository.Clients.Where(x => x.PrimerNombre?.ToLower() == name.ToLower()).FirstOrDefault();

            // NotFound - 404 - NotFound - No data found
            if (foundClient == null)
                return NotFound($"No se encontro el cliente con nombre {name}");

            // Ok - 200 - Success
            if (foundClient != null)
            {
                clientDto.CodigoCliente = foundClient.Id;
                clientDto.CorreoElectronico = "No tiene correo electronico";
                //clientDto.TercerNombre = foundClient.TercerNombre;
                //clientDto.SegundoNombre = foundClient.SegundoNombre;
                //clientDto.PrimerNombre = foundClient.PrimerNombre;
                //clientDto.ApellidoCasada = foundClient.ApellidoCasada;
                //clientDto.Edad = foundClient.Edad;
                //clientDto.Genero = "M";
                //clientDto.PrimerApellido = foundClient.PrimerApellido;
                //clientDto.SegundoApellido = foundClient.SegundoApellido;

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

        [HttpPost]
        [Route(template:"Create", Name = "CreateStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ClientDTO> CreateClient([FromBody] ClientDTO model) {

            int newStudentId = 0;
            Client clientDb = new Client();

            if (model == null || string.IsNullOrEmpty(model.PrimerNombre) || string.IsNullOrEmpty(model.SegundoNombre) ||
                string.IsNullOrEmpty(model.PrimerApellido) || string.IsNullOrEmpty(model.SegundoApellido))
                return BadRequest();

            if (model.FechaNacimiento < DateTime.Now.AddDays(-100))
            {
                ModelState.AddModelError(key: "FechaNacimientoValidation", errorMessage: "La fecha de nacimiento es menor a 1924, la persona tiene 101 años.");
                return BadRequest(ModelState);
            }

            newStudentId = ClientRepository.Clients.LastOrDefault().Id + 1;

            if (newStudentId != 0) {

                clientDb = new Client()
                {
                    ApellidoCasada = model.ApellidoCasada,
                    Edad = model.Edad,
                    Genero = model.Genero,
                    PrimerApellido = model.PrimerApellido,
                    PrimerNombre = model.PrimerNombre,
                    SegundoApellido = model.SegundoApellido,
                    SegundoNombre = model.SegundoNombre,
                    TercerNombre = model.TercerNombre,
                    Id = newStudentId

                };

                ClientRepository.Clients.Add(clientDb);
            }
            
            model.CodigoCliente = clientDb.Id;

            return CreatedAtRoute("GetClientById", new { id = model.CodigoCliente }, model);

        }
    }
}
