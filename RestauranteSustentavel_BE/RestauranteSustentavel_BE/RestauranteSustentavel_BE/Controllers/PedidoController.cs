using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;
using RestauranteSustentavel_BE.Services;

namespace RestauranteSustentavel_BE.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly PedidoService pedidoService;
        private readonly PratoService pratoService;

        public PedidoController(PedidoService pedidoService, PratoService pratoService)
        {
            this.pedidoService = pedidoService;
            this.pratoService = pratoService;

        }

        [HttpPost("Insert/")]
        public Pedido InsertPedido(Pedido pedido)
        {
            return pedidoService.InsertPedido(pedido);
        }


        [HttpGet("GetAll/")]
        public List<Pedido> GetAllPedidos()
        {
            return pedidoService.GetAllPedidos();
        }

        [HttpPut("Update/")]
        public Pedido UpdatePedido(Pedido pedido)
        {
            return pedidoService.UpdatePedido(pedido);
        }


        [HttpDelete("Delete/")]
        public int DeletePedido(int i)
        {
            return pedidoService.DeletePedido(i);
        }

        [HttpDelete("Delete/VariosPedidos")]
        public void DeletePedidos()
        {
           pedidoService.DeletePedidos();
        }

        [HttpPost("Insert/PedidoSobremesa")]
        public void InsertSobremesaEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa)
        {
            pedidoService.InsertSobremesaEmPedido(pedidoSobremesa);
        }
       

        [HttpGet("GetAll/PedidoSobremesa")]
        public List<PedidoSobremesa> GetAllPedidoSobremesa()
        {
            return pedidoService.GetAllPedidoSobremesa();
        }
        
        [HttpPut("Update/QuantidadeDeSobremesaEmPedidoSobremesa")]
        public void UpdateQuantidadeSobremesaEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa)
        {

            pedidoService.UpdateQuantidadeDeSobremesasEmPedidoSobremesa(pedidoSobremesa);

        }

        [HttpGet("Busca/PedidoPorIdEmPedidoSobremesa")]
        public List<PedidoSobremesa> BuscaPedidoSobremesasPorPedidoId(int idPedido)
        {
            return pedidoService.BuscaPedidoSobremesasPorPedidoId(idPedido);
        }


       
        [HttpPost("Insert/PedidoBebida")]
        public void InsertPedidoBebida(PedidoBebida pedidoBebida)
        {
            pedidoService.InsertPedidoBebida(pedidoBebida);
        }



        [HttpGet("GetAll/PedidoBebida")]
        public List<PedidoBebida> GetAllPedidoBebida()
        {
            return pedidoService.GetAllPedidoBebida();
        }


        [HttpPut("Update/QuantidadeBebidaEmPedidoBebida")]
        public void UpdateQuantidadeBebidaEmPedidoBebida(PedidoBebida updatePedidoBebida)
        {
            pedidoService.UpdateQuantidadeBebidaEmPedidoBebida(updatePedidoBebida);
        }


        [HttpDelete("Delete/PedidoBebida")]
        public void DeletePedidoBebida(PedidoBebida pedidoBebida)
        {
            pedidoService.DeletePedidoBebida(pedidoBebida);
        }

        [HttpGet("Busca/PedidoEmPedidoBebida")]
        public List<PedidoBebida> BuscaPedidoEmPedidoBebida(int idPedido)
        {
            return pedidoService.BuscaPedidoEmPedidoBebida(idPedido);
        }


        [HttpPost("Insert/IngredientePrato")]
        public void InsertIngredientePrato(IngredientePrato ingredientePrato)
        {
            pratoService.InsertIngredientePrato(ingredientePrato);
        }


        [HttpGet("GetAll/IngredientePrato")]
        public List<IngredientePrato> GetAllIngredientePrato()
        {
            return pratoService.GetAllIngredientePrato();
        }
        /*
        [HttpPut("Update/QuantidadeIngredienteEmIngredientePrato")]
        public void UpdateQuantidadeIngredienteEmIngredientePrato(IngredientePrato ingredientePrato)
        {
            pratoService.UpdateQuantidadeIngredienteEmIngredientePrato(ingredientePrato);
        }
*/
        [HttpDelete("Delete/IngredientePrato")]
        public void DeleteIngredientePrato(IngredientePrato ingredientePrato)
        {
            pratoService.DeleteIngredientePrato(ingredientePrato);
        }


        [HttpGet("Busca/PratoEmIngredientePrato")]
        public List<IngredientePrato> BuscaPratoEmIngredientePrato(int idPrato)
        {
            return pratoService.BuscaPratoEmIngredientePrato(idPrato);
        }

        [HttpGet("Busca/IngredienteEmIngredientePrato")]
        public IngredientePrato BuscaIngredienteEmIngredientePrato(int idIngrediente, int idPrato)
        {
            return pratoService.BuscaIngredienteEmIngredientePrato(idIngrediente, idPrato);
        }

        [HttpGet("Busca/PedidoPorId")]
        public Pedido BuscaUmPedidoEmPedido(int idPedido)
        {
            return pedidoService.BuscaUmPedido(idPedido);

        }

        
       
    }
}
