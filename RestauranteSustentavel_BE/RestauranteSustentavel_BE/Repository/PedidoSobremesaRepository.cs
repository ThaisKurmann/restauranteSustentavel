using RestauranteSustentavel_BE.Models;
using System.Data.SQLite;

namespace RestauranteSustentavel_BE.Repository
{
    public class PedidoSobremesaRepository
    {

        private readonly DbContext dbContext;


        public PedidoSobremesaRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //READ -->FUNCIONA!!!!!!! :))
        public List<PedidoSobremesa> GetAllPedidoSobremesa()
        {
            var pedidoSobremesas = new List<PedidoSobremesa>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM PedidoSobremesa", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();

            while (reader.Read())
            {
                var pedidoSobremesa = new PedidoSobremesa()
                {
                    quantidade = int.Parse(reader["quantidade"].ToString()),
                    preco = float.Parse(reader["preco"].ToString()), //pega o resultado e compara com 1, resultando em um booleano, ou seja, se a == 1, entao eh verdadeiro;
                    idSobremesa = int.Parse(reader["fk_PedidoSobremesa_Sobremesa"].ToString()),//pegando o Id da tabela Bebida
                    idPedido = int.Parse(reader["fk_PedidoSobremesa_Pedido"].ToString()),
                };

                pedidoSobremesas.Add(pedidoSobremesa);//add o obj na lista bebidas
            }

            return pedidoSobremesas;
        }



    }
}
