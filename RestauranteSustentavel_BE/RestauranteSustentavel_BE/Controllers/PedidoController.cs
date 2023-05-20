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
        private readonly PedidoSobremesaRepository pedidoSobremesaRepository;

        public PedidoController(PedidoService pedidoService, PedidoSobremesaRepository pedidoSobremesaRepository)
        {
            this.pedidoService = pedidoService;
            this.pedidoSobremesaRepository = pedidoSobremesaRepository;
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

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        [HttpPost("getAllPedidoSobremesa")]
        public List<PedidoSobremesa> GetPedidoSobremesa()
        {
            return pedidoService.GetAllPedidoSobremesa();
        }
        
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
        [HttpPost("RemoveSobremesa do Pedido | Exclui")]
        public void RemoveSobremesaDoPedido(PedidoSobremesa pedidoSobremesa, int quantidadeRemover) {

            pedidoService.RemoveAlteraQuantidadeSobremesaNoPedido(pedidoSobremesa, quantidadeRemover);
        
        }
       
        

    }
}