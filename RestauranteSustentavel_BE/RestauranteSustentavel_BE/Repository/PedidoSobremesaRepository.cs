using RestauranteSustentavel_BE.Models;

namespace RestauranteSustentavel_BE.Repository
{
    public class PedidoSobremesaRepository
    {

        private readonly DbContext dbContext;


        public PedidoSobremesaRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //READ
        public PedidoSobremesa GetAllPedidoSobremesa(PedidoSobremesa pedidoSobremesa)
        {

            return pedidoSobremesa;
        }



    }
}
