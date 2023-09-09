using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management.Dto;
using Student_Management.IRepository.Course;
using Student_Management.IRepository.User;
using static Student_Management.Enums.DataEnums;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteCourseController : ControllerBase
    {
        private readonly IWriteCourse _writeCourse;
        IReadUser _readUser;
        public WriteCourseController(IWriteCourse writeCourse, IReadUser readUser)
        {
            _writeCourse = writeCourse;
            _readUser = readUser;

        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] DtoCourse course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                var hataMesaji = new { HataKodu = 400, Hata = "CourseName alanı boş olamaz!" };
                return BadRequest(hataMesaji);
            }
            bool TeacherIdVarMı = true;

            foreach (var item in _readUser.GetAll())
            {
                if (course.TeacherId == item.Id)
                {
                    if (item.DetailId == (int)DetailEnum.Teacher)
                    {
                        TeacherIdVarMı = false;
                    }
                }
            }
            if (TeacherIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz TeacherId değeri veri tabanında bulunmamaktadır veya TeacherId hatalıdır!" };
                return BadRequest(hataMesaji);
            }

            _writeCourse.Add(new()
            {
                CourseName = course.CourseName,
                Duration = course.Duration,
                Fees = course.Fees,
                TeacherId = course.TeacherId,
            });

            return Ok("Tamamlandı");
        }

        [HttpDelete]
        public IActionResult DeleteUser(int courseId)
        {
            _writeCourse.Remove(new() { Id = courseId });
            return Ok("Tamamlandı");
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] DtoCourse course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Name alanı boş olamaz!" };
                return BadRequest(hataMesaji);
            }

            bool TeacherIdVarMı = true;

            foreach (var item in _readUser.GetAll())
            {
                if (course.TeacherId == item.Id)
                {
                    if (item.DetailId == (int)DetailEnum.Teacher)
                    {
                        TeacherIdVarMı = false;
                    }
                }
            }

            if (TeacherIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz TeacherId değeri veri tabanında bulunmamaktadır veya TeacherId hatalıdır!" };
                return BadRequest(hataMesaji);
            }

            _writeCourse.Update(new()
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Duration = course.Duration,
                Fees = course.Fees,
                TeacherId = course.TeacherId,
            });

            return Ok("Tamamlandı");
        }
    }
}
