using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;

namespace RestauranteSustentavel_BE.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository pedidoRepository;
        private readonly PedidoSobremesaRepository pedidoSobremesaRepository;

        public PedidoService(PedidoRepository pedidoRepository, PedidoSobremesaRepository pedidoSobremesaRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.pedidoSobremesaRepository = pedidoSobremesaRepository;
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

        
        //fazer metedo que add sobremesa ao pedido do cliente como nome de AddSobremesa(Pedido pedido);

        public List<PedidoSobremesa> GetAllPedidoSobremesaTest(Sobremesa sobremesa)
        {
            
            //TESTTANDO METODO: getAllPedidoSobremesa do Repositorio
            return pedidoSobremesaRepository.GetAllPedidoSobremesa();
        }
    }
}
