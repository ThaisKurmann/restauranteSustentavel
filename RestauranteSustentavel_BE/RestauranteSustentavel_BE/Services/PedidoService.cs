using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;

namespace RestauranteSustentavel_BE.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository pedidoRepository;

        public PedidoService(PedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
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

        //add sobremesa ao pedido do cliente
        public Sobremesa AddSobremesa(Sobremesa sobremesa)
        {
            
            
            return sobremesa;
        }
    }
}
