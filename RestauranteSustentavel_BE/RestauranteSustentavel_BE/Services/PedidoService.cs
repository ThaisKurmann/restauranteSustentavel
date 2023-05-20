using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;
using System.Security.Permissions;

namespace RestauranteSustentavel_BE.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository pedidoRepository;
        private readonly PedidoSobremesaRepository pedidoSobremesaRepository;
        private readonly SobremesaRepository sobremesaRepository;
        public PedidoService(PedidoRepository pedidoRepository, PedidoSobremesaRepository pedidoSobremesaRepository, SobremesaRepository sobremesaRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.pedidoSobremesaRepository = pedidoSobremesaRepository;
            this.sobremesaRepository = sobremesaRepository;
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

        
        //GET ALL PEDIDOS in PedidoSobremesa
        public List<PedidoSobremesa> GetAllPedidoSobremesaTest(Sobremesa sobremesa)
        {
            return pedidoSobremesaRepository.GetAllPedidoSobremesa();
        }


        //Buscar informacoes do pedido feito pelo cliente
        public List<PedidoSobremesa> BuscaPedido(int idPedido)
        {
                  
            return pedidoSobremesaRepository.BuscaPedido(idPedido); 

        }


        //Adicionar sobremesa ao pedido
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


        public void DeletePedidSobremesa(PedidoSobremesa pedidoSobremesa)
        {
            pedidoSobremesaRepository.Delete(pedidoSobremesa);
        }

        

    }
}
