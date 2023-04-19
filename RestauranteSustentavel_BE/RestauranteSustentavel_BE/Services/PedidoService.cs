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

        //READ
        public List<Pedido> Get()
        {
            return pedidoRepository.GetAllPedidos();
        }


    }
}
