using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Services;

namespace RestauranteSustentavel_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SobremesaController : ControllerBase
    {

        private readonly SobremesaService sobremesaService;

        public SobremesaController(SobremesaService sobremesaService)
        {
            this.sobremesaService = sobremesaService;
        }

        //CREATE
        [HttpPost("Insert")]
        public Sobremesa Insert(Sobremesa sobremesa)
        {
            return sobremesaService.Insert(sobremesa);
        }
        //READ
        [HttpGet("GetAll")]
        public List<Sobremesa> Get() 
        {
            return sobremesaService.Get();
        }

        //UPDATE
        [HttpPut("Update")]
        public Sobremesa Update(Sobremesa sobremesa)
        {
            return sobremesaService.Update(sobremesa);
        }
        //DELETE
        [HttpDelete("Delete")]
        public int Delete(int i)
        {
            return sobremesaService.Delete(i);
        }

        
     


    }
}
