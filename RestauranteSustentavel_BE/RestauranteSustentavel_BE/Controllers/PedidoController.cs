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
        
        [HttpPut("InsertSobremesaEmPedido")]
        public void InsertSobremesaEmPedidoSobremesa(int idSobremesa, int idPedido, int quantidadeSobremesa)
        {
            pedidoService.InsertSobremesaEmPedido(idSobremesa, idPedido, quantidadeSobremesa);
        }
       

        [HttpPost("GetAllPedidoSobremesa")]
        public List<PedidoSobremesa> GetAllPedidoSobremesa()
        {
            return pedidoService.GetAllPedidoSobremesa();
        }
        
        [HttpPost("UpdateQuantidadeDeSobremesaEmPedidoSobremesa")]
        public void UpdateQuantidadeSobremesaEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa, int quantidadeRemover)
        {

            pedidoService.UpdateQuantidadeDeSobremesasEmPedidoSobremesa(pedidoSobremesa, quantidadeRemover);

        }

        [HttpGet("BuscaPedidoPoIdEmPedidoSobremesa")]
        public List<PedidoSobremesa> BuscaPedidoSobremesasPorPedidoId(int idPedido)
        {
            return pedidoService.BuscaPedidoSobremesasPorPedidoId(idPedido);
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

        [HttpGet("BuscaUmPedidoEmPedido")]
        public Pedido BuscaUmPedidoEmPedido(int idPedido)
        {
            return pedidoService.BuscaUmPedido(idPedido);

        }

        
       
    }
}
