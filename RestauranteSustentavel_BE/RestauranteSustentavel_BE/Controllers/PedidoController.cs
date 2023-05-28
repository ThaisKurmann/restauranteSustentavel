using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;
using RestauranteSustentavel_BE.Services;

namespace RestauranteSustentavel_BE.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("Insert")]
        public Pedido InsertPedido(Pedido pedido)
        {
            return pedidoService.InsertPedido(pedido);
        }


        [HttpGet("GetAll")]
        public List<Pedido> GetAllPedidos()
        {
            return pedidoService.GetAllPedidos();
        }

        [HttpPut("Update")]
        public Pedido UpdatePedido(Pedido pedido)
        {
            return pedidoService.UpdatePedido(pedido);
        }


        [HttpDelete("Delete")]
        public int DeletePedido(int i)
        {
            return pedidoService.DeletePedido(i);
        }


        [HttpPost("GetAllPedidoSobremesa")]
        public List<PedidoSobremesa> GetAllPedidoSobremesa()
        {
            return pedidoService.GetAllPedidoSobremesa();
        }

       
        [HttpGet("BuscaPedidoEmPedidoSobremesa")]
        public List<PedidoSobremesa> BuscaPedidoEmPedidoSobremesa(int idPedido)
        {
            return pedidoService.BuscaPedidoEmPedidoSobremesa(idPedido);
        }


        [HttpPut("InsertSobremesaEmPedidoSobremesa")]
        public void InsertSobremesaEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa)
        {
            pedidoService.InsertSobremesaEmPedidoSobremesa(pedidoSobremesa);
        }


        [HttpPost("UpdateQuantidadeSobremesaEmPedidoSobremesa")]
        public void UpdateQuantidadeSobremesaEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa, int quantidadeRemover)
        {

            pedidoService.UpdateQuantidadeSobremesaEmPedidoSobremesa(pedidoSobremesa, quantidadeRemover);

        }



        [HttpPost("InsertPedidoBebida")]
        public void InsertPedidoBebida(PedidoBebida pedidoBebida)
        {
            pedidoService.InsertPedidoBebida(pedidoBebida);
        }



        [HttpGet("GetAllPedidoBebida")]
        public List<PedidoBebida> GetAllPedidoBebida()
        {
            return pedidoService.GetAllPedidoBebida();
        }


        [HttpPut("UpdateQuantidadeBebidaEmPedidoBebida")]
        public void UpdateQuantidadeBebidaEmPedidoBebida(PedidoBebida pedidoBebida, int quantidadeRemover)
        {
            pedidoService.UpdateQuantidadeBebidaEmPedidoBebida(pedidoBebida, quantidadeRemover);
        }


        [HttpDelete("DeletePedidoBebida")]
        public void DeletePedidoBebida(PedidoBebida pedidoBebida)
        {
            pedidoService.DeletePedidoBebida(pedidoBebida);
        }

        [HttpGet("BuscaPedidoEmPedidoBebida")]
        public List<PedidoBebida> BuscaPedidoEmPedidoBebida(int idPedido)
        {
            return pedidoService.BuscaPedidoEmPedidoBebida(idPedido);
        }


        [HttpPost("InsertIngredientePrato")]
        public void InsertIngredientePrato(IngredientePrato ingredientePrato)
        {
            pratoService.InsertIngredientePrato(ingredientePrato);
        }


        [HttpGet("GetAllIngredientePrato")]
        public List<IngredientePrato> GetAllIngredientePrato()
        {
            return pratoService.GetAllIngredientePrato();
        }

        [HttpPut("UpdateQuantidadeIngredienteEmIngredientePrato")]
        public void UpdateQuantidadeIngredienteEmIngredientePrato(IngredientePrato ingredientePrato, int quantidadeRemover)
        {
            pratoService.UpdateQuantidadeIngredienteEmIngredientePrato(ingredientePrato, quantidadeRemover);
        }

        [HttpDelete("DeleteIngredientePrato")]
        public void DeleteIngredientePrato(IngredientePrato ingredientePrato)
        {
            pratoService.DeleteIngredientePrato(ingredientePrato);
        }


        [HttpGet("BuscaPratoEmIngredientePrato")]
        public List<IngredientePrato> BuscaPratoEmIngredientePrato(int idPrato)
        {
            return pratoService.BuscaPratoEmIngredientePrato(idPrato);
        }

        [HttpGet("BuscaIngredienteEmIngredientePrato")]
        public IngredientePrato BuscaIngredienteEmIngredientePrato(int idIngrediente, int idPrato)
        {
            return pratoService.BuscaIngredienteEmIngredientePrato(idIngrediente, idPrato);
        }

        //teste
        [HttpGet("GetAllPrato")]
        public List<Prato> GetAllPrato()
        {
            return pratoService.GetAllPrato();
        }
    }
}
