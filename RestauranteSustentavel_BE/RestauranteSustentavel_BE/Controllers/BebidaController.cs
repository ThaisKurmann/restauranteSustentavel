using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Services;

namespace RestauranteSustentavel_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BebidaController : ControllerBase
    {
        private readonly BebidaService bebidaService;

        public BebidaController(BebidaService bebidaService)
        {
            this.bebidaService = bebidaService;
        }

        //READ
        [HttpGet("GetAll")]
        public IEnumerable<Bebida> GetAll()
        {
            return bebidaService.GetAll();
        }
        //INSERT
        [HttpPost("Insert")]
        public Bebida Insert(Bebida bebida)
        {

            return bebidaService.Insert(bebida);
        }
        //UPDATE
        [HttpPut("Update")]
        public Bebida Update(Bebida bebida)
        {
            return bebidaService.Update(bebida);
        }
        //DELETE
        [HttpDelete("Delete")]
        public int Delete(int i)
        {
            return bebidaService.Delete(i);
        }




    }
}
