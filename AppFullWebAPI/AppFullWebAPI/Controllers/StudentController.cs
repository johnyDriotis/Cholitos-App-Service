using AppFullWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppFullWebAPI.Controllers
{

    [ApiController] // Se le indica al controlador que pertenece a web api.
    [Route("api/[controller]")] // Se le indica la ruta a la que debe responder al realizar las peticiones http.
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route(template: "All", Name = "GetAllStudents" )]
        public IEnumerable<Student> GetStudents() {
            return CollegeRepository.Students;
        }

        [HttpGet]
        [Route(template: "{id:int}", Name = "GetStudentById")]
        public Student GetStudentById(int id)
        {
            var student = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();

            if (student != null) {
                return student;
            }
            return null;
        }

        [HttpGet]
        [Route(template: "{name:alpha}", Name = "GetStudentByName")]
        public Student GetStudentByName(string name)
        {
            var student = CollegeRepository.Students.Where(x => x.StudentName == name).FirstOrDefault();

            if (student != null)
            {
                return student;
            }
            return null;
        }

        [HttpDelete]
        [Route(template: "{id:int}", Name = "DeleteStudent")]
        public bool DeleteStudent(int id) { 
            var student = CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();

            if (student != null) {
                CollegeRepository.Students.Remove(student);
                return true;
            }
            return false;
        }
    }
}
