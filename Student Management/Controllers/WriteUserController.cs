using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management.Dto;
using Student_Management.IRepository.Course;
using Student_Management.IRepository.Detail;
using Student_Management.IRepository.Student;
using Student_Management.IRepository.User;
using Student_Management.Models;
using Student_Management.Repository.Course;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteUserController : ControllerBase
    {
        private readonly IMapper _mapper;
        IWriteUser _writeUser;
        IReadDetail _readDetail;

   
        public WriteUserController( IMapper mapper, IWriteUser writeUser,IReadDetail readDetail)
        {
            _mapper = mapper;
            _readDetail = readDetail;
            _writeUser = writeUser;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] DtoUser user)
        {
            //Name alanı dolumu diye kontrol ediyor.
            if (string.IsNullOrEmpty(user.Name))
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Name alanı boş olamaz!" };
                return BadRequest(hataMesaji);
            }
            //password alanı dolumu diye kontrol ediyor.
            if (string.IsNullOrEmpty(user.Password))
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Password alanı boş olamaz!" };
                return BadRequest(hataMesaji);
            }
            //Detail Id veri tabanında var mı diye kontrol ediliyor.
            bool DetailIdVarMı = true;
            foreach (var item in _readDetail.GetAll())
            {
                if (user.DetailId == item.Id)
                {
                    DetailIdVarMı = false;
                }
            }
            if (DetailIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz CourseId hatalıdır!" };
                return BadRequest(hataMesaji);
            }
            _writeUser.Add(new()
            {
               Name= user.Name,
               Password= user.Password,
               DetailId= user.DetailId,
            });

            return Ok("Tamamlandı");
        }

        [HttpDelete]
        public IActionResult DeleteUser(int UserDeleteId)
        {
            _writeUser.Remove(new() { Id = UserDeleteId });
            return Ok("Tamamlandı");
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] DtoUser user)
        {
            //Name alanı dolumu diye kontrol ediyor.
            if (string.IsNullOrEmpty(user.Name))
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Name alanı boş olamaz!" };
                return BadRequest(hataMesaji);
            }
            //password alanı dolumu diye kontrol ediyor.
            if (string.IsNullOrEmpty(user.Password))
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Password alanı boş olamaz!" };
                return BadRequest(hataMesaji);
            }
            //Detail Id veri tabanında var mı diye kontrol ediliyor.
            bool DetailIdVarMı = true;
            foreach (var item in _readDetail.GetAll())
            {
                if (user.DetailId == item.Id)
                {
                    DetailIdVarMı = false;
                }
            }
            if (DetailIdVarMı)
            {
                var hataMesaji = new { HataKodu = 400, Hata = "Girdiğiniz CourseId hatalıdır!" };
                return BadRequest(hataMesaji);
            }
            _writeUser.Update(new()
            {
                Name = user.Name,
                Password = user.Password,
                DetailId = user.DetailId,
            });

            return Ok("Tamamlandı");
        }
    }
}
