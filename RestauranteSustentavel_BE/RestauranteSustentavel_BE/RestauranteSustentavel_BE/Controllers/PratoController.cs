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

        //INSERT
        [HttpPost("InsertPrato")]
        public Prato InsertPrato(int pedidoId)
        {
            return pratoService.InsertPrato(pedidoId);
        }

        //GET
        [HttpGet("GetAllPrato")]
        public List<Prato> GetAllPrato()
        {
            return pratoService.GetAllPrato();
        }
        //DELETE
        [HttpDelete("DeletePrato")]
        public void DeletePrato(int idPrato)
        {
            pratoService.DeletePrato(idPrato);
        }
        //BUSCA: Pratos por ID
        [HttpGet("BuscaPratosPorPedidoId")]
        public List<Prato> BuscaPratosPorPedidoId(int idPedido)
        {
            return pratoService.BuscaPratosPorPedidoId(idPedido);
        }
        //BUSCA: Lista que mostra os ingredientes e suas respectivas quantidades em um prato
        [HttpGet("BuscaPratoIngredienteListView")]
        public List<PratoIngredienteListView> BuscaPratoIngredienteListView(int pedidoId)
        {

            return pratoService.ShowIngredientesEmPratoPorPedidoId(pedidoId);

        }

        //Alterar quantidade de ingredientes em um prato
        [HttpPut("Update/QuantidadeIngredienteEmIngredientePrato")]
        public void UpdateQuantidadeIngredienteEmIngredientePrato(IngredientePrato ingredientePrato)
        {
            pratoService.UpdateQuantidadeIngredienteEmIngredientePrato(ingredientePrato);
        }


    }
}
