using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Services;

namespace RestauranteSustentavel_BE.Controllers
{

    [Route("[controller]/api")]
    [ApiController]
    public class PratoController : ControllerBase
    {


        private readonly PratoService pratoService;



        public PratoController(PratoService pratoService)
        {
            this.pratoService = pratoService;
        }

        [HttpPost("InsertPrato")]
        public Prato InsertPrato(int pedidoId)
        {
            return pratoService.InsertPrato(pedidoId);
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

        [HttpGet("BuscaPratosPorPedidoId")]
        public List<Prato> BuscaPratosPorPedidoId(int idPedido)
        {
            return pratoService.BuscaPratosPorPedidoId(idPedido);
        }

        [HttpGet("BuscaPratoIngredienteListView")]
        public List<PratoIngredienteListView> BuscaPratoIngredienteListView(int pedidoId)
        {

            return pratoService.ShowIngredientesEmPratoPorPedidoId(pedidoId);

        }

      
    }
}
