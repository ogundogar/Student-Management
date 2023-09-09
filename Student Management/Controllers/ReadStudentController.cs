using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management.Dto;
using Student_Management.IRepository.Student;
using Student_Management.IRepository.User;
using Student_Management.Models;
using Student_Management.Repository.User;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadStudentController : ControllerBase
    {
        private readonly IReadStudent _readStudent;
        private readonly IMapper _mapper;
        public ReadStudentController(IReadStudent readStudent, IMapper mapper)
        {
            _readStudent = readStudent;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DtoStudent>))]
        public IActionResult GetAll()
        {
            var users = _mapper.Map<List<DtoStudent>>(_readStudent.GetAll());
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DtoStudent>))]
        public IActionResult GetUser(int id)
        {
            var user = _mapper.Map<List<DtoStudent>>(_readStudent.GetWhere(p => p.Id == id));
            return Ok(user);
        }

        [HttpGet("Course")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DtoStudent>))]
        public IActionResult GetCourse(int id)
        {
            var user = _mapper.Map<List<DtoStudent>>(_readStudent.GetWhere(p => p.CourseId == id));
            return Ok(user);
        }
        [HttpGet("Student")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DtoStudent>))]
        public IActionResult GetStudent(int id)
        {
            var user = _mapper.Map<List<DtoStudent>>(_readStudent.GetWhere(p => p.StudentId == id));
            return Ok(user);
        }

    }
}
