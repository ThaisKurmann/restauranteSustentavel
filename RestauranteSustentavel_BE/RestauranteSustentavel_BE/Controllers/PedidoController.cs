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


        [HttpGet("Read")]
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


        [HttpPost("getAllPedidoSobremesa")]
        public List<PedidoSobremesa> GetPedidoSobremesa()
        {
            return pedidoService.GetAllPedidoSobremesa();
        }

        //TODO: Alterar nome do metodo. Colocar um nome mais legivel
        [HttpGet("BuscaPedido")]
        public List<PedidoSobremesa> BuscaPedido(int idPedido)
        {
            return pedidoService.BuscaPedido(idPedido);
        }


        [HttpPut("AddSobremesaAoPedido")]
        public void AddSobremesaAoPedido(PedidoSobremesa pedidoSobremesa)
        {
            pedidoService.AddSobremesaAoPedido(pedidoSobremesa);
        }


        //Chamar service para que elimina a quantidade de sobremesas desejada pelo cliente
        [HttpPost("Alterar ou Excluir pedido")]
        public void RemoveSobremesaDoPedido(PedidoSobremesa pedidoSobremesa, int quantidadeRemover)
        {

            pedidoService.RemoveAlteraQuantidadeSobremesaNoPedido(pedidoSobremesa, quantidadeRemover);

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


        [HttpPut("UpdatePedidoBebida")]
        public void UpdatePedidoBebida(PedidoBebida pedidoBebida, int quantidadeRemover)
        {
            pedidoService.UpdatePedidoBebida(pedidoBebida, quantidadeRemover);
        }


        [HttpDelete("DeletePedidoBebida")]
        public void DeletePedidoBebida(PedidoBebida pedidoBebida)
        {
            pedidoService.DeletePedidoBebida(pedidoBebida);
        }

        [HttpGet("BuscaPedidoQueContemBebida")]
        public List<PedidoBebida> BuscaPedidoQueContemBebida(int idPedido)
        {
            return pedidoService.BuscaPedidoQueContemBebida(idPedido);
        }


        [HttpPost("InsertIngredientePrato")]
        public void InsertIngredientePrato(IngredientePrato ingredientePrato)
        {
            pratoService.Insert(ingredientePrato);
        }


        [HttpGet("GetAllIngredientePrato")]
        public List<IngredientePrato> GetAllIngredientePrato()
        {
            return pratoService.GetAllIngredientePrato();
        }

        [HttpPut("UpdateIngredientePrato")]
        public void UpdateIngredientePrato(IngredientePrato ingredientePrato, int quantidadeRemover)
        {
            pratoService.UpdateIngredientePrato(ingredientePrato, quantidadeRemover);
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

        [HttpGet("BuscaIngredienteDePrato")]
        public IngredientePrato BuscaIngredienteEmPrato(int idIngrediente, int idPrato)
        {
            return pratoService.BuscaIngredienteEmIngredientePrato(idIngrediente, idPrato);
        }
    }
}
