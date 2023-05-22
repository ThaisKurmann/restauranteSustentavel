using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;
using System.Security.Permissions;

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




        //CREATE
        public Pedido Insert(Pedido pedido)
        {
            return pedidoRepository.InsertPedido(pedido);
        }

        //READ
        public List<Pedido> Get()
        {
            return pedidoRepository.GetAllPedidos();
        }

        //UPDATE
        public Pedido Update(Pedido pedido)
        {
            return pedidoRepository.UpatePedido(pedido);
        }


        //DELETE
        public int Delete(int i)
        {
            return pedidoRepository.DeletePedido(i);
        }


        //[PedidoSobremesa]
        public List<PedidoSobremesa> GetAllPedidoSobremesa()
        {
            return pedidoSobremesaRepository.GetAllPedidoSobremesa();
        }


        //[PedidoSobremesa]
        public List<PedidoSobremesa> BuscaPedido(int idPedido)
        {
                  
            return pedidoSobremesaRepository.BuscaPedido(idPedido); 

        }


        //[PedidoSobremesa]
        public void AddSobremesaAoPedido (PedidoSobremesa pedidoSobremesa)
        {
            PedidoSobremesa pedidoSobremesaBD = pedidoSobremesaRepository.BuscaUmaSobremesaEmPedido(pedidoSobremesa.idSobremesa, pedidoSobremesa.idPedido);

            if(pedidoSobremesaBD != null)
            {
                //atualiza quantidade de sobremesas nesse pedido
                pedidoSobremesaBD.quantidade += pedidoSobremesa.quantidade;
                //atualiza dados no BD
                pedidoSobremesaRepository.Update(pedidoSobremesaBD);
            }
            else
            {
                pedidoSobremesaRepository.InsertPedidoSobremesa(pedidoSobremesa);

            } 
        }

        //[PedidoSobremesa]
        public void RemoveAlteraQuantidadeSobremesaNoPedido(PedidoSobremesa pedidoSobremesa, int quantidadeRemover)
        {
            var pedidoSobremesa1 = pedidoSobremesaRepository.BuscaUmaSobremesaEmPedido(pedidoSobremesa.idSobremesa, pedidoSobremesa.idPedido);

            if(pedidoSobremesa1 == null)
            {
                return;
            }

            pedidoSobremesa1.quantidade = pedidoSobremesa1.quantidade - quantidadeRemover;

            if(pedidoSobremesa1.quantidade > 0)
            {
                pedidoSobremesaRepository.Update(pedidoSobremesa1);
            }
            else
            {
                pedidoSobremesaRepository.Delete(pedidoSobremesa1);
            }
                
           
        }
       

        //[PedidoBebida] 
        public PedidoBebida InsertPedidoBebida(PedidoBebida pedidoBebida)
        {
            return pedidoBebidaRepository.Insert(pedidoBebida);
        }

        //[PedidoBebida] 
        public List<PedidoBebida> GetAllPedidoBebida()
        {
            return pedidoBebidaRepository.GetAllPedidoBebida();

        }

        //[PedidoBebida] 
        public PedidoBebida UpdatePedidoBebida(PedidoBebida pedidoBebida)
        {
            return pedidoBebidaRepository.UpadatePedidoBebida(pedidoBebida);
        }

        //[PedidoBebida] 
        public void DeletePedidoBebida(PedidoBebida pedidoBebida)
        {
            pedidoBebidaRepository.DeletePedidoBebida(pedidoBebida);
        }

        //[PedidoBebida] 
        public List<PedidoBebida> BuscaPedidoQueContemBebida(int idPedido)
        {
            return pedidoBebidaRepository.BuscaPedidoQueContemBebida(idPedido);
        }


    }
}
