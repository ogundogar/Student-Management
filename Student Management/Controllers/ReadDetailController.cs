using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management.Dto;
using Student_Management.Models;
using Student_Management.IRepository.Detail;


namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadDetailController : ControllerBase
    {
        private readonly IReadDetail _readDetail;
        private readonly IMapper _mapper;
        public ReadDetailController(IReadDetail readDetail, IMapper mapper)
        {
            _readDetail = readDetail;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DtoDetail>))]
        public IActionResult GetAll()
        {
            var details = _mapper.Map<List<DtoDetail>>(_readDetail.GetAll());
            return Ok(details);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TbDetail>))]
        public IActionResult GetUser(int id)
        {
            var detail = _mapper.Map<List<DtoDetail>>(_readDetail.GetWhere(p => p.Id == id));
            return Ok(detail);
        }
    }
}
