using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Services;

namespace RestauranteSustentavel_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {


        private readonly IngredienteService ingredienteService;

        public IngredienteController(IngredienteService ingredienteService)
        {
            this.ingredienteService = ingredienteService;
        }

        //CREATE
        [HttpPost("Insert")]
        public Ingrediente Insert(Ingrediente ingrediente)
        {

            return ingredienteService.Insert(ingrediente);
        }


        //READ
        [HttpGet("GetAll")]
        public List<Ingrediente> GetAll()
        {
            return ingredienteService.GetAll();
        }

        //UPATE
        [HttpPut("Update")]
        public Ingrediente Update(Ingrediente ingrediente)
        {
            return ingredienteService.Update(ingrediente);
        }


        //DELETE
        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            ingredienteService.Delete(id);
        }


    }
}
