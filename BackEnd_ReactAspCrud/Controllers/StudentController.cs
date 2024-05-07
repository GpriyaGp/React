using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAspCrud.Models;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _studentDBContext;
        public StudentController(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }
        [HttpGet]
        [Route("GetStudents")]
        public async Task<IEnumerable<Student>> GetStudents() {

            return await _studentDBContext.Student.ToListAsync();
        }
        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student student)
        {
            _studentDBContext.Student.Add(student);
            await _studentDBContext.SaveChangesAsync();
            return student;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(Student student)
        {
            _studentDBContext.Entry(student).State = EntityState.Modified;
            await _studentDBContext.SaveChangesAsync();
            return student;     
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent (int id)
        {
            bool a = false;
            var student = _studentDBContext.Student.Find(id);
            if(student != null)
            {
                a = true;
                _studentDBContext.Entry(student).State = EntityState.Deleted;
                _studentDBContext.SaveChanges();
            }
            return a;
        }

    }

}
