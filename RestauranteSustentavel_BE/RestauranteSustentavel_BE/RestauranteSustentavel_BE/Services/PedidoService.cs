﻿using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;
using System.Security.Permissions;
using Xunit;

namespace RestauranteSustentavel_BE.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository pedidoRepository;
        private readonly PedidoSobremesaRepository pedidoSobremesaRepository;
        private readonly PedidoBebidaRepository pedidoBebidaRepository;
        public PedidoService(PedidoRepository pedidoRepository, PedidoSobremesaRepository pedidoSobremesaRepository, PedidoBebidaRepository pedidoBebidaRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.pedidoSobremesaRepository = pedidoSobremesaRepository;
            this.pedidoBebidaRepository = pedidoBebidaRepository;
        }




        //[Pedido: CREATE]
        public Pedido InsertPedido(Pedido pedido)
        {
            return pedidoRepository.Insert(pedido);
        }

        //[Pedido: READ]
        public List<Pedido> GetAllPedidos()
        {            
            return pedidoRepository.GetAll();
        }

        //[Pedido: UPDATE]
        public Pedido UpdatePedido(Pedido pedido)
        {
            return pedidoRepository.Upate(pedido);
        }

        //[Pedido: DELETE]
        public int DeletePedido(int i)
        {
            return pedidoRepository.Delete(i);
        }

        public void DeletePedidos()
        {
            //colocar os pedidos num vetor|lista
            var pedidos = new List<Pedido>();

            pedidos = pedidoRepository.GetAll();

            //excluir pedidos a partir de pedido de id 18
            foreach(var pedido in pedidos)
            {
                if(pedido.id >= 18)
                {
                    DeletePedido(pedido.id);
                }
            }
        }

        //[Pedido: Busca um Pedido por Pedido id no Banco de Dados]
        public Pedido BuscaUmPedido(int idPedido)
        {
            var pedido = pedidoRepository.GetById(idPedido);

            return pedido;
        }

        //[PedidoSobremesa: BUSCA PedidoSobremesas por Pedido id em PedidoSobremesa]
        public List<PedidoSobremesa> BuscaPedidoSobremesasPorPedidoId(int idPedido)
        {
            return pedidoSobremesaRepository.BuscaPedidoSobremesasPorPedidoId(idPedido);
        }

        //[PedidoSobremesa: INSERT]
        public PedidoSobremesa InsertSobremesaEmPedido(PedidoSobremesa pedidoSobremesa)
        {
            PedidoSobremesa pedidoSobremesaBD = pedidoSobremesaRepository.BuscaSobremesaEmPedidoSobremesa(pedidoSobremesa.idSobremesa, pedidoSobremesa.idPedido);

            if (pedidoSobremesaBD != null)
            {
                //atualiza quantidade de sobremesas nesse pedido
                pedidoSobremesaBD.quantidade += pedidoSobremesa.quantidade;
                //atualiza dados no BD
                pedidoSobremesaRepository.Update(pedidoSobremesaBD);

                return pedidoSobremesaBD;
            }
            else
            {
                return pedidoSobremesaRepository.Insert(pedidoSobremesa);
                
            }

        }

        //[PedidoSobremesa: READ]
        public List<PedidoSobremesa> GetAllPedidoSobremesa()
        {
            return pedidoSobremesaRepository.GetAll();
        }

        //[PedidoSobremesa: UPDATE]
        public void UpdateQuantidadeDeSobremesasEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa)
        {
            var pedidoSobremesa1 = pedidoSobremesaRepository.BuscaSobremesaEmPedidoSobremesa(pedidoSobremesa.idSobremesa, pedidoSobremesa.idPedido);

            if (pedidoSobremesa1 == null)
            {
                return;
            }

            pedidoSobremesa1.quantidade = pedidoSobremesa.quantidade;

            if (pedidoSobremesa1.quantidade > 0)
            {
                pedidoSobremesaRepository.Update(pedidoSobremesa1);
            }
            else
            {
                pedidoSobremesaRepository.Delete(pedidoSobremesa1);
            }


        }

        //[PedidoBebida: INSERT] 
        public void InsertPedidoBebida(PedidoBebida pedidoBebida)
        {
            var pedidoBebidaBD = pedidoBebidaRepository.BuscaBebidaQueEstaEmPedido(pedidoBebida.idBebida, pedidoBebida.idPedido);

            if (pedidoBebidaBD != null)
            {
                //atualiza quantidade de sobremesas nesse pedido
                pedidoBebidaBD.quantidade += pedidoBebida.quantidade;
                //atualiza dados no BD
                pedidoBebidaRepository.Update(pedidoBebidaBD);
            }
            else
            {
                pedidoBebidaRepository.Insert(pedidoBebida);
            }


        }

        //[PedidoBebida: READ] 
        public List<PedidoBebida> GetAllPedidoBebida()
        {
            return pedidoBebidaRepository.GetAll();

        }

        //[PedidoBebida: UPDATE]
        public void UpdateQuantidadeBebidaEmPedidoBebida(PedidoBebida updatePedidoBebida)
        {
            var pedidoBebidaBD = pedidoBebidaRepository.BuscaBebidaQueEstaEmPedido(updatePedidoBebida.idBebida, updatePedidoBebida.idPedido);

            if (pedidoBebidaBD == null)
            {
                return;
            }

            pedidoBebidaBD.quantidade = updatePedidoBebida.quantidade;

            if (pedidoBebidaBD.quantidade > 0)
            {
                pedidoBebidaRepository.Update(pedidoBebidaBD);
            }
            else
            {
                pedidoBebidaRepository.Delete(pedidoBebidaBD);
            }

        }

        //[PedidoBebida: DELETE] 
        public void DeletePedidoBebida(PedidoBebida pedidoBebida)
        {
            pedidoBebidaRepository.Delete(pedidoBebida);
        }

        //[PedidoBebida: BUSCA] 
        public List<PedidoBebida> BuscaPedidoEmPedidoBebida(int idPedido)
        {
            return pedidoBebidaRepository.BuscaPedidoEmPedidoBebida(idPedido);
        }

        
    }
}
