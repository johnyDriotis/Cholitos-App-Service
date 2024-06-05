﻿using AppFullWebAPI.Models;
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
        //}

        [HttpGet]
        public IEnumerable<Student> GetStudents() {
            return CollegeRepository.Students;
        }

        [HttpGet("{id:int}")]
        public Student GetStudentById(int id)
        {
            return CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
