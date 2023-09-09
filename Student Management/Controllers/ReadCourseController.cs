using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management.Dto;
using Student_Management.IRepository.Course;
using Student_Management.Models;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadCourseController : ControllerBase
    {
        private readonly IReadCourse _readCourse;
        private readonly IMapper _mapper;
        public ReadCourseController(IReadCourse readCourse, IMapper mapper)
        {
            _readCourse = readCourse;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TbCourse>))]
        public IActionResult GetAll()
        {
            var users = _mapper.Map<List<DtoCourse>>(_readCourse.GetAll());
            return Ok(users);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TbCourse>))]
        public IActionResult GetUser(int id)
        {
            var user = _mapper.Map<List<DtoCourse>>(_readCourse.GetWhere(p => p.Id == id));
            return Ok(user);
        }
        [HttpGet("CourseAdı")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TbCourse>))]
        public IActionResult GetCourseName(string courseName)
        {
            var user = _mapper.Map<List<DtoCourse>>(_readCourse.GetWhere(p => p.CourseName == courseName));
            return Ok(user);
        }
    }
}
