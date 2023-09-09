using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management.Dto;
using Student_Management.Models;
using Student_Management.IRepository.User;
using static Student_Management.Enums.DataEnums;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadUserController : ControllerBase
    {
        private readonly IReadUser _readUser;
        private readonly IMapper _mapper;
        public ReadUserController(IReadUser readUser, IMapper mapper)
        {
            _readUser = readUser;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DtoUser>))]
        public IActionResult GetAll()
        {
            var users = _mapper.Map<List<DtoUser>>(_readUser.GetAll());
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DtoUser>))]
        public IActionResult GetUser(int id)
        {
            var user = _mapper.Map<List<DtoUser>>(_readUser.GetWhere(p => p.Id == id));
            return Ok(user);
        }

        [HttpGet("Teacher")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TbUser>))]
        public IActionResult GetTeacher()
        {
            var user = _mapper.Map<List<DtoUser>>(_readUser.GetWhere(p => p.DetailId == (int)DetailEnum.Teacher));
            return Ok(user);
        }


        [HttpGet("Student")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TbUser>))]
        public IActionResult GetStudent()
        {
            var user = _mapper.Map<List<DtoUser>>(_readUser.GetWhere(p => p.DetailId == (int)DetailEnum.Student));
            return Ok(user);
        }

        [HttpGet("Admin")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TbUser>))]
        public IActionResult GetAdmin()
        {
            var user = _mapper.Map<List<DtoUser>>(_readUser.GetWhere(p => p.DetailId == (int)DetailEnum.Admin));
            return Ok(user);
        }
    }
}
