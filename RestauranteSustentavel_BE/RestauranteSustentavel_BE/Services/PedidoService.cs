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


        //[PedidoSobremesa: READ]
        public List<PedidoSobremesa> GetAllPedidoSobremesa()
        {
            return pedidoSobremesaRepository.GetAll();
        }


        //[PedidoSobremesa: BUSCA PEDIDO]
        public List<PedidoSobremesa> BuscaPedidoEmPedidoSobremesa(int idPedido)
        {

            return pedidoSobremesaRepository.BuscaPedidoEmPedidoSobremesa(idPedido);

        }


        //[PedidoSobremesa: INSERT]
        public void InsertSobremesaEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa)
        {
            PedidoSobremesa pedidoSobremesaBD = pedidoSobremesaRepository.BuscaUmaSobremesaEmPedido(pedidoSobremesa.idSobremesa, pedidoSobremesa.idPedido);

            if (pedidoSobremesaBD != null)
            {
                //atualiza quantidade de sobremesas nesse pedido
                pedidoSobremesaBD.quantidade += pedidoSobremesa.quantidade;
                //atualiza dados no BD
                pedidoSobremesaRepository.Update(pedidoSobremesaBD);
            }
            else
            {
                pedidoSobremesaRepository.Insert(pedidoSobremesa);

            }
        }

        //[PedidoSobremesa: UPDATE]
        public void RemoveSobremesaEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa, int quantidadeRemover)
        {
            var pedidoSobremesa1 = pedidoSobremesaRepository.BuscaUmaSobremesaEmPedido(pedidoSobremesa.idSobremesa, pedidoSobremesa.idPedido);

            if (pedidoSobremesa1 == null)
            {
                return;
            }

            pedidoSobremesa1.quantidade = pedidoSobremesa1.quantidade - quantidadeRemover;

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
                pedidoBebidaRepository.UpadatePedidoBebida(pedidoBebidaBD);
            }
            else
            {
                pedidoBebidaRepository.Insert(pedidoBebida);
            }


        }

        //[PedidoBebida: READ] 
        public List<PedidoBebida> GetAllPedidoBebida()
        {
            return pedidoBebidaRepository.GetAllPedidoBebida();

        }

        //[PedidoBebida: UPDATE]
        public void UpdatePedidoBebida(PedidoBebida pedidoBebida, int quantidadeRemover)
        {
            var pedidoBebidaBD = pedidoBebidaRepository.BuscaBebidaQueEstaEmPedido(pedidoBebida.idBebida, pedidoBebida.idPedido);

            if (pedidoBebidaBD == null)
            {
                return;
            }

            pedidoBebidaBD.quantidade -= quantidadeRemover;

            if (pedidoBebidaBD.quantidade > 0)
            {
                pedidoBebidaRepository.UpadatePedidoBebida(pedidoBebidaBD);
            }
            else
            {
                pedidoBebidaRepository.DeletePedidoBebida(pedidoBebidaBD);
            }

        }

        //[PedidoBebida: DELETE] 
        public void DeletePedidoBebida(PedidoBebida pedidoBebida)
        {
            pedidoBebidaRepository.DeletePedidoBebida(pedidoBebida);
        }

        //[PedidoBebida: BUSCA PEDIDOS] 
        public List<PedidoBebida> BuscaPedidoQueContemBebida(int idPedido)
        {
            return pedidoBebidaRepository.BuscaPedidoQueContemBebida(idPedido);
        }


    }
}
