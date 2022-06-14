using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentDetails;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentwebapi2.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet, Route("api/Student/StudentDetails")]
        public IEnumerable<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }
        [HttpGet, Route("api/student/InsertStudentData/{Name}/{Class}")]
        public IEnumerable<Student> insert(Student student)
        {
            if (_studentService.InsertData(student))
            {
                return _studentService.GetStudents();
            }

            return Enumerable.Empty<Student>();
        }

        [HttpGet, Route("api/Student/PromoteToNextClass/{rollNumber}")]
        public IEnumerable<Student> PromoteToNextClass(int rollNumber)
        {
            if (_studentService.ToNextClass(rollNumber))
            {
                return _studentService.GetStudents().Where(s => s.Id == rollNumber);
            }

            return Enumerable.Empty<Student>();
        }

        [HttpGet, Route("api/Student/DeleStudent/{rollNumber}")]
        public IEnumerable<Student> DeleStudent(int rollNumber)
        {
            if (_studentService.DeleteStudent(rollNumber))
            {
                return _studentService.GetStudents();
            }

            return Enumerable.Empty<Student>();
        }
    }
}
