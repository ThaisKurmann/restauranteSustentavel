﻿using Microsoft.AspNetCore.Http;
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


        [HttpGet("Read")]
        public List<Pedido> Get()
        {
            return pedidoService.Get();
        }

        [HttpPost("Insert")]
        public Pedido Insert(Pedido pedido)
        {
            return pedidoService.Insert(pedido);
        }


        [HttpPut("Update")]
        public Pedido Update(Pedido pedido)
        {
            return pedidoService.Update(pedido);
        }


        [HttpDelete("Delete")]
        public int Delete(int i)
        {
            return pedidoService.Delete(i);
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
        public void RemoveSobremesaDoPedido(PedidoSobremesa pedidoSobremesa, int quantidadeRemover) {

            pedidoService.RemoveAlteraQuantidadeSobremesaNoPedido(pedidoSobremesa, quantidadeRemover);
        
        }

      

        [HttpPost("InsertPedidoBebida")]
        public PedidoBebida InsertPedidoBebida(PedidoBebida pedidoBebida)
        {
            return pedidoService.InsertPedidoBebida(pedidoBebida);
        }


        
        [HttpGet("GetAllPedidoBebida")]
        public List<PedidoBebida> GetAllPedidoBebida()
        {
            return pedidoService.GetAllPedidoBebida();
        }

        
        [HttpPut("UpdatePedidoBebida")] 
        public PedidoBebida UpdatePedidoBebida(PedidoBebida pedidoBebida)
        {
            return pedidoService.UpdatePedidoBebida(pedidoBebida);
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

        //teste
        [HttpPost("InsertIngredientePrato")]
        public IngredientePrato InsertIngredientePrato(IngredientePrato ingredientePrato)
        {
            return pratoService.Insert(ingredientePrato);
        }

    }
}
