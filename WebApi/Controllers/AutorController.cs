using Domain.Dto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController
    {
        private AutorService _autorService;

        public AutorController()
        {
            _autorService = new AutorService();
        }
        [HttpGet]
        public List<Autor> GetAutors()
        {
            return _autorService.GetAutors();
        }

        [HttpPost("Insert")]
        public int InsertAutors(Autor autor)
        {
            return _autorService.InsertAutors(autor);
        }

        [HttpPut("Update")]
        public int UpdateAutors(Autor autor)
        {
            return _autorService.UpdateAutors(autor);
        }

        [HttpDelete("Delete")]
        public int DeleteAutors(int id)
        {
            return _autorService.DeleteAutors(id);
        }
    }
}