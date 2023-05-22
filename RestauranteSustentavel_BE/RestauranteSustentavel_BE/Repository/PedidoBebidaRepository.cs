using RestauranteSustentavel_BE.Models;
using System.Data.SQLite;


namespace RestauranteSustentavel_BE.Repository
{
    public class PedidoBebidaRepository
    {

        private readonly DbContext dbContext;

        public PedidoBebidaRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        //CREATE
        public PedidoBebida Insert(PedidoBebida pedidoBebida)
        {
            SQLiteCommand insertComd = new SQLiteCommand("INSERT into PedidoBebida(quantidade, fk_PedidoBebida_Bebida, fk_PedidoBebida_Pedido) values (@quantidade, @idBebida, @idPedido) ", dbContext.connection);
            insertComd.Parameters.AddWithValue("@quantidade", pedidoBebida.quantidade);
            insertComd.Parameters.AddWithValue("@idBebida", pedidoBebida.idBebida);
            insertComd.Parameters.AddWithValue("@idPedido", pedidoBebida.idPedido);
            insertComd.ExecuteNonQuery();


            return pedidoBebida;
        }



        //READ
       public List<PedidoBebida> GetAllPedidoBebida()
        {
            var pedidoBebidas = new List<PedidoBebida>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM PedidoBebida", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();

            while (reader.Read())
            {
                var pedidoBebida = new PedidoBebida()
                {
                    quantidade = int.Parse(reader["quantidade"].ToString()),
                    idBebida = int.Parse(reader["fk_PedidoBebida_Bebida"].ToString()),
                    idPedido = int.Parse(reader["fk_PedidoBebida_Pedido"].ToString()),
                };

                pedidoBebidas.Add(pedidoBebida);//add o obj na lista bebidas
            }

            return pedidoBebidas;
        }

        
        //UPDATE
        public PedidoBebida UpadatePedidoBebida(PedidoBebida pedidoBebida)
        {
            SQLiteCommand updateCmd = new SQLiteCommand("UPDATE PedidoBebida \r\nSET quantidade = @quantidade\r\nWHERE PedidoBebida.fk_PedidoBebida_Bebida = @idBebida AND PedidoBebida.fk_PedidoBebida_Pedido = @idPedido;", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@quantidade", pedidoBebida.quantidade);
            updateCmd.Parameters.AddWithValue("@idBebida", pedidoBebida.idBebida);
            updateCmd.Parameters.AddWithValue("@idPedido", pedidoBebida.idPedido);

            updateCmd.ExecuteNonQuery();


            return pedidoBebida;
        } 



        //DELETE
        public void DeletePedidoBebida(PedidoBebida pedidoBebida)
        {
            SQLiteCommand deleteCmd = new SQLiteCommand("DELETE FROM PedidoBebida WHERE fk_PedidoBebida_Bebida = @idBebida AND fk_PedidoBebida_Pedido = @idPedido", dbContext.connection);
            deleteCmd.Parameters.AddWithValue("@idBebida", pedidoBebida.idBebida);
            deleteCmd.Parameters.AddWithValue("@idPedido", pedidoBebida.idPedido);
            deleteCmd.ExecuteNonQuery();

        }


        //BUSCA UM PEDIDO na tabela PedidoBebida
        public List<PedidoBebida> BuscaPedidoQueContemBebida(int idPedido)
        {
            var pedidoBebidas = new List<PedidoBebida>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM PedidoBebida WHERE fk_PedidoBebida_Pedido = @idPedido", dbContext.connection);
            getCmd.Parameters.AddWithValue("@idPedido", idPedido);
            SQLiteDataReader reader = getCmd.ExecuteReader();

            while (reader.Read())
            {
                var pedidoBebida = new PedidoBebida()
                {
                    quantidade = int.Parse(reader["quantidade"].ToString()),
                    idBebida = int.Parse(reader["fk_PedidoBebida_Bebida"].ToString()),
                    idPedido = int.Parse(reader["fk_PedidoBebida_Pedido"].ToString()),
                };
                pedidoBebidas.Add(pedidoBebida);
            }

            return pedidoBebidas;
        }


        public PedidoBebida BuscaBebidaQueEstaEmPedido(int idBebida, int idPedido)
        {
            SQLiteCommand getCmd = new SQLiteCommand("SELECT PedidoBebida.fk_PedidoBebida_Bebida, PedidoBebida.fk_PedidoBebida_Pedido, PedidoBebida.quantidade\r\nFROM PedidoBebida\r\nWHERE PedidoBebida.fk_PedidoBebida_Bebida = @idBebida AND PedidoBebida.fk_PedidoBebida_Pedido = @idPedido;", dbContext.connection);
            getCmd.Parameters.AddWithValue("@idBebida", idBebida);
            getCmd.Parameters.AddWithValue("@idPedido", idPedido);


            SQLiteDataReader reader = getCmd.ExecuteReader();

            reader.Read();

            if (!reader.HasRows)
            {

                return null;

            }
            var pedidoBebida = new PedidoBebida()
            {
                quantidade = int.Parse(reader["quantidade"].ToString()),
                idBebida = int.Parse(reader["fk_PedidoBebida_Bebida"].ToString()),
                idPedido = int.Parse(reader["fk_PedidoBebida_Pedido"].ToString()),
            };


            return pedidoBebida;
        }





    }
}
