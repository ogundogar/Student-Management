using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management.Dto;
using Student_Management.IRepository.Detail;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteDetailController : ControllerBase
    {
        private readonly IWriteDetail _writeDetail;
        private readonly IMapper _mapper;
        public WriteDetailController(IWriteDetail writeDetail, IMapper mapper)
        {
            _writeDetail = writeDetail;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] DtoDetail detail)
        {
            if (string.IsNullOrEmpty(detail.Detail))
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Detail alanı boş olamaz!" };
                return BadRequest(hataMesaji);
            }
            _writeDetail.Add(new()
            {
                Detail = detail.Detail
            });
            return Ok("Tamamlandı");
        }

        [HttpDelete]
        public IActionResult DeleteUser(int detailId)
        {
            _writeDetail.Remove(new() { Id = detailId });
            return Ok("Tamamlandı");
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody] DtoDetail detail)
        {
            if (string.IsNullOrEmpty(detail.Detail))
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Detail alanı boş olamaz!" };
                return BadRequest(hataMesaji);
            }
            _writeDetail.Update(new()
            {
                Id = detail.Id,
                Detail = detail.Detail
            });
            return Ok("Tamamlandı");
        }
    }
}
