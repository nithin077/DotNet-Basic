using Microsoft.AspNetCore.Http;
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
        public IEnumerable<Student> GetStudentDetails()
        {
            return CollegeRepository.Student;
        }

        [HttpGet("{id}")]
        public Student GetStudentDetailsById(int id)
        {
            return CollegeRepository.Student.Where(col => col.id == id).FirstOrDefault();
        }
    }
}
