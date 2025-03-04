using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Product.Models;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllStudents")]
        public ActionResult<IEnumerable<StudentDTO>> GetStudentDetails()
        {
            //var student = new List<StudentDTO>();
            //foreach(var item in CollegeRepository.Student)
            //{
            //    StudentDTO studentObj = new StudentDTO()
            //    {
            //        id = item.id,
            //        name = item.name,
            //        email = item.email,
            //        age = item.age
            //    };
            //    student.Add(studentObj);
            //}

            //LINQ
            var student = CollegeRepository.Student.Select(s => new StudentDTO()
            {
                id = s.id,
                name = s.name,
                email = s.email,
                age = s.age

            });
            return Ok(student);
        }

        [HttpGet]
        [Route("GetStudentById/{id:int}")]
        public ActionResult<Student> GetStudentDetailsById(int id)
        {
            if (id <= 0) return BadRequest("Student id is required");
            var student = CollegeRepository.Student.Where(col => col.id == id).FirstOrDefault();
            if (student == null) return NotFound($"Student With id : {id} Not Found");
            return Ok(student);
        } 

        [HttpGet]
        [Route("GetStudentByName/{name}")]
        public ActionResult<Student> GetStudentDetailsByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest("Student Name required");
            var result = CollegeRepository.Student.Where(col => col.name == name).FirstOrDefault();
            if (result == null) return NotFound($"Student With name : {name} Not Found");
            return result;

        }

        [HttpDelete]
        [Route("DeleteStudentById/{id:int}")]

        public ActionResult<bool> DeletStudentById(int  id)
        {
            if (id <= 0) return BadRequest("Student Id is required should not be 0");
            var student = CollegeRepository.Student.Where(col => col.id == id).FirstOrDefault();
            if (student == null) return NotFound($"Student With id : {id} Not Found");
            CollegeRepository.Student.Remove(student);
            return true;

        }

        [HttpPost]
        [Route("CreateStudent")]

        public ActionResult<StudentDTO> CreateStudent([FromBody]StudentDTO responseFromUI)
        {
            if (responseFromUI == null) return BadRequest();

            var newId = CollegeRepository.Student.LastOrDefault().id + 1;
            Student stud = new Student
            {
                id = newId,
                name = responseFromUI.name,
                email = responseFromUI.email,
                age = responseFromUI.age
            };
            CollegeRepository.Student.Add(stud);

            responseFromUI.id = stud.id;
            return Ok(responseFromUI);
           // return CreatedAtRoute($"GetStudentById{responseFromUI.id}",  responseFromUI);
        }
    }
}
