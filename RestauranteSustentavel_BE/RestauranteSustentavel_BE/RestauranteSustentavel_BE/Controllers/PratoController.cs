using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Services;

namespace RestauranteSustentavel_BE.Controllers
{

    [Route("[controller]/api")]
    [ApiController]
    public class PratoController: ControllerBase
    {


        private readonly PratoService pratoService;



        public PratoController(PratoService pratoService)
        {
            this.pratoService = pratoService;
        }   

        [HttpPost("InsertPrato")]
        public Prato InsertPrato(Prato prato)
        {
            return pratoService.InsertPrato(prato);
        }


        [HttpGet("GetAllPrato")]
        public List<Prato> GetAllPrato()
        {
            return pratoService.GetAllPrato();
        }

        [HttpDelete("DeletePrato")]
        public void DeletePrato(int idPrato)
        {
            pratoService.DeletePrato(idPrato);
        }

        [HttpGet("BuscaPratosEmPedido")]
        public List<Prato> BuscaPratosEmPedido(int idPedido)
        {
            return pratoService.BuscaPratosEmPedido(idPedido);
        }
    }
}
