using RestauranteSustentavel_BE.Models;
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
        public PedidoSobremesa InsertSobremesaEmPedido(int idSobremesa, int idPedido, int quantidadeSobremesa)
        {
            PedidoSobremesa pedidoSobremesaBD = pedidoSobremesaRepository.BuscaSobremesaEmPedidoSobremesa(idSobremesa, idPedido);

            if (pedidoSobremesaBD != null)
            {
                //atualiza quantidade de sobremesas nesse pedido
                pedidoSobremesaBD.quantidade += quantidadeSobremesa;
                //atualiza dados no BD
                pedidoSobremesaRepository.Update(pedidoSobremesaBD);

                return pedidoSobremesaBD;
            }
            else
            {
                return pedidoSobremesaRepository.Insert(idSobremesa, idPedido, quantidadeSobremesa);
                
            }

        }

        //[PedidoSobremesa: READ]
        public List<PedidoSobremesa> GetAllPedidoSobremesa()
        {
            return pedidoSobremesaRepository.GetAll();
        }

        //[PedidoSobremesa: UPDATE]
        public void UpdateQuantidadeDeSobremesasEmPedidoSobremesa(PedidoSobremesa pedidoSobremesa, int quantidadeRemover)
        {
            var pedidoSobremesa1 = pedidoSobremesaRepository.BuscaSobremesaEmPedidoSobremesa(pedidoSobremesa.idSobremesa, pedidoSobremesa.idPedido);

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
        public void UpdateQuantidadeBebidaEmPedidoBebida(PedidoBebida pedidoBebida, int quantidadeRemover)
        {
            var pedidoBebidaBD = pedidoBebidaRepository.BuscaBebidaQueEstaEmPedido(pedidoBebida.idBebida, pedidoBebida.idPedido);

            if (pedidoBebidaBD == null)
            {
                return;
            }

            pedidoBebidaBD.quantidade -= quantidadeRemover;

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
