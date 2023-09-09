using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management.Dto;
using Student_Management.IRepository.Course;
using Student_Management.IRepository.Student;
using Student_Management.IRepository.User;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteStudentController : ControllerBase
    {
        private readonly IWriteStudent _writeStudent;
        private readonly IMapper _mapper;
        IReadUser _readUser;
        IReadCourse _readCourse;
        IReadStudent _readStudent;
        public WriteStudentController(IWriteStudent writeStudent, IMapper mapper, IReadUser readUser, IReadCourse readCourse, IReadStudent readStudent)
        {
            _writeStudent = writeStudent;
            _mapper = mapper;
            _readUser = readUser;
            _readCourse = readCourse;
            _readStudent = readStudent;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] DtoStudent student)
        {
            //Course ID Kontrolü için
            bool CourseIdVarMı = true;
            foreach (var item in _readCourse.GetAll())
            {
                if (student.CourseId == item.Id)
                {
                    CourseIdVarMı = false;
                }
            }
            if (CourseIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz CourseId hatalıdır!" };
                return BadRequest(hataMesaji);
            }

            //Student ID Kontrolü için
            bool StudentIdVarMı = true;
            foreach (var item in _readUser.GetAll())
            {
                if (student.StudentId == item.Id)
                {
                    StudentIdVarMı = false;
                }
            }
            if (StudentIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz StudentId hatalıdır!" };
                return BadRequest(hataMesaji);
            }

            //Teacher ID Kontrolü için
            bool TeacherIdVarMı = true;
            foreach (var item in _readUser.GetAll())
            {
                if (student.TeacherId == item.Id)
                {
                    TeacherIdVarMı = false;
                }
            }
            if (TeacherIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz TeacherId hatalıdır!" };
                return BadRequest(hataMesaji);
            }

            _writeStudent.Add(new()
            {
                CourseId = student.CourseId,
                StudentId = student.StudentId,
                TeacherId = student.TeacherId,
                Passed = student.Passed,

            });

            return Ok("Tamamlandı");
        }

        [HttpDelete]
        public IActionResult DeleteUser(int studentId)
        {
            _writeStudent.Remove(new() { Id = studentId });
            return Ok("Tamamlandı");
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] DtoStudent student)
        {
            //Course ID Kontrolü için
            bool CourseIdVarMı = true;
            foreach (var item in _readCourse.GetAll())
            {
                if (student.CourseId == item.Id)
                {
                    CourseIdVarMı = false;
                }
            }
            if (CourseIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz CourseId hatalıdır!" };
                return BadRequest(hataMesaji);
            }

            //Student ID Kontrolü için
            bool StudentIdVarMı = true;
            foreach (var item in _readUser.GetAll())
            {
                if (student.StudentId == item.Id)
                {
                    StudentIdVarMı = false;
                }
            }
            if (StudentIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz StudentId hatalıdır!" };
                return BadRequest(hataMesaji);
            }

            //Teacher ID Kontrolü için
            bool TeacherIdVarMı = true;
            foreach (var item in _readUser.GetAll())
            {
                if (student.TeacherId == item.Id)
                {
                    TeacherIdVarMı = false;
                }
            }
            if (TeacherIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz TeacherId hatalıdır!" };
                return BadRequest(hataMesaji);
            }
            _writeStudent.Update(new()
            {
                Id = student.Id,
                CourseId = student.CourseId,
                StudentId = student.StudentId,
                TeacherId = student.TeacherId,
                Passed = student.Passed,
            });

            return Ok("Tamamlandı");
        }
    }
}
