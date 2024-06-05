using AppFullWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppFullWebAPI.Controllers
{
    
    [ApiController] // Se le indica al controlador que pertenece a web api.
    [Route("api/[controller]")] // Se le indica la ruta a la que debe responder al realizar las peticiones http.
    public class StudentController : ControllerBase
    {
        //[HttpGet]
        //public string GetStudentName() {
        //    return "Nombre de estudiante #1";
        //}W

        [HttpGet]
        public IEnumerable<Student> GetStudents() {
            return new List<Student>
            {
                new Student{ 
                    Id = 1,
                    StudentName = "Nombre de estudiante #1",
                    Address = "Direccion estudiante #1",
                    Email = "studiante1@gmail.com"
                },
                new Student{
                    Id = 2,
                    StudentName = "Nombre de estudiante #2",
                    Address = "Direccion estudiante #2",
                    Email = "studiante2@gmail.com"
                }
            };
        }
    }
}
