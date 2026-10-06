using CampusDocs.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusDocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {

          

            Student newStudent = new Student
            {
                Age = student.Age,
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Status = student.Status
            };

            SourceStudents.Add(newStudent);

            return Ok("Student created successfully.");
        }
      

        public static List<Student> SourceStudents = new List<Student>();

    }
}
