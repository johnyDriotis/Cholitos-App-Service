using AppFullWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AppFullWebAPI.Controllers
{

    [ApiController] // Se le indica al controlador que pertenece a web api.
    [Route("api/[controller]")] // Se le indica la ruta a la que debe responder al realizar las peticiones http.
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route(template: "All", Name = "GetAllStudents" )]
        public ActionResult<IEnumerable<Student>> GetStudents() {

            // Ok = 200 - Success
            return Ok(CollegeRepository.Students);
        }

        [HttpGet]
        [Route(template: "{id:int}", Name = "GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            // BadRequest - 400 - BadRequest - Client Error
            if (id <= 0)
                return BadRequest("El id debe ser mayor a 0");

            var foundStudent = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();

            // NotFound - 404 - NotFound - No data found
            if (foundStudent == null)
                return NotFound($"No se encontro el estudiante con id {id}");

            // Ok - 200 - Success
            if (foundStudent != null)
            {
                return Ok(foundStudent);
            }

            // BadRequest - 400 - BadRequest - Error no controlado
            return BadRequest("No se pudo controlar el error");
        }

        [HttpGet]
        [Route(template: "{name:alpha}", Name = "GetStudentByName")]
        public ActionResult<Student> GetStudentByName(string name)
        {
            var foundStudent = CollegeRepository.Students.Where(x => x.StudentName?.ToLower() == name).FirstOrDefault();

            // NotFound - 404 - NotFound - No data found
            if (foundStudent == null)
                return NotFound($"No se encontro el estudiante con nombre {name}");

            // Ok - 200 - Success
            if (foundStudent != null)
            {
                return Ok(foundStudent);
            }

            // BadRequest - 400 - BadRequest - Error no controlado
            return BadRequest("No se pudo controlar el error");
        }

        [HttpDelete]
        [Route(template: "{id:int}", Name = "DeleteStudent")]
        public ActionResult<bool> DeleteStudent(int id) {

            // BadRequest - 400 - BadRequest - Client Error
            if (id <= 0)
                return BadRequest("El id debe ser mayor a 0");

            var foundStudent = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();

            // NotFound - 404 - NotFound - No data found
            if (foundStudent == null)
                return NotFound($"No se encontro el estudiante con id {id}");

            // Ok - 200 - Success
            if (foundStudent != null) {
                CollegeRepository.Students.Remove(foundStudent);
                return Ok(true);
            }

            // BadRequest - 400 - BadRequest - Error no controlado
            return BadRequest("No se pudo controlar el error");
        }
    }
}
