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

        //CREATE
        public PedidoSobremesa InsertPedidoSobremesa(PedidoSobremesa pedidoSobremesa)
        {
            SQLiteCommand insertComd = new SQLiteCommand("INSERT into PedidoSobremesa(quantidade, fk_PedidoSobremesa_Sobremesa, fk_PedidoSobremesa_Pedido) values (@quantidade, @idSobremesa, @idPedido) ", dbContext.connection);
            insertComd.Parameters.AddWithValue("@quantidade", pedidoSobremesa.quantidade);
            insertComd.Parameters.AddWithValue("@idSobremesa", pedidoSobremesa.idSobremesa);
            insertComd.Parameters.AddWithValue("@idPedido", pedidoSobremesa.idPedido);
            insertComd.ExecuteNonQuery();


            return pedidoSobremesa;
        }


        //READ
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
                    //preco = float.Parse(reader["preco"].ToString()), //pega o resultado e compara com 1, resultando em um booleano, ou seja, se a == 1, entao eh verdadeiro;
                    idSobremesa = int.Parse(reader["fk_PedidoSobremesa_Sobremesa"].ToString()),//pegando o Id da tabela Bebida
                    idPedido = int.Parse(reader["fk_PedidoSobremesa_Pedido"].ToString()),
                };

                pedidoSobremesas.Add(pedidoSobremesa);//add o obj na lista bebidas
            }

            return pedidoSobremesas;
        }

        //UPDATE
        public PedidoSobremesa Update(PedidoSobremesa pedidoSobremesa)
        {
            SQLiteCommand updateCmd = new SQLiteCommand("UPDATE PedidoSobremesa \r\nSET quantidade = @quantidade\r\nWHERE PedidoSobremesa.fk_PedidoSobremesa_Sobremesa = @idSobremesa AND PedidoSobremesa.fk_PedidoSobremesa_Pedido = @idPedido;", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@quantidade", pedidoSobremesa.quantidade);
            updateCmd.Parameters.AddWithValue("@idSobremesa", pedidoSobremesa.idSobremesa);
            updateCmd.Parameters.AddWithValue("@idPedido", pedidoSobremesa.idPedido);
            
            updateCmd.ExecuteNonQuery();

            return pedidoSobremesa;
        }

        //DELETE
        public void Delete(PedidoSobremesa pedidoSobremesa)
        {
            SQLiteCommand deleteCmd = new SQLiteCommand("DELETE FROM PedidoSobremesa WHERE fk_PedidoSobremesa_Sobremesa = @idSobremesa AND fk_PedidoSobremesa_Pedido = @idPedido", dbContext.connection);
            deleteCmd.Parameters.AddWithValue("@idSobremesa", pedidoSobremesa.idSobremesa);
            deleteCmd.Parameters.AddWithValue("@idPedido", pedidoSobremesa.idPedido);
            deleteCmd.ExecuteNonQuery();
        }

        //BUSCA UM PEDIDO na tabela PedidoSobremesa
        public List<PedidoSobremesa> BuscaPedido(int idPedido)
        {
           var pedidoSobremesas = new List<PedidoSobremesa>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM PedidoSobremesa WHERE fk_PedidoSobremesa_Pedido = @idPedido", dbContext.connection);
            getCmd.Parameters.AddWithValue("@idPedido", idPedido);
            SQLiteDataReader reader = getCmd.ExecuteReader();

            while(reader.Read())
            {
                var pedidoSobremesa = new PedidoSobremesa()
                {
                    quantidade = int.Parse(reader["quantidade"].ToString()),
                    idSobremesa = int.Parse(reader["fk_PedidoSobremesa_Sobremesa"].ToString()),
                    idPedido = int.Parse(reader["fk_PedidoSobremesa_Pedido"].ToString()),
                };
                pedidoSobremesas.Add(pedidoSobremesa);
            } 

            return pedidoSobremesas;
        }

        
        public PedidoSobremesa BuscaUmaSobremesaEmPedido(int idSobremesa, int idPedido)
        {
            SQLiteCommand getCmd = new SQLiteCommand("SELECT PedidoSobremesa.fk_PedidoSobremesa_Sobremesa, PedidoSobremesa.fk_PedidoSobremesa_Pedido, PedidoSobremesa.quantidade\r\nFROM PedidoSobremesa\r\nWHERE PedidoSobremesa.fk_PedidoSobremesa_Sobremesa = @idSobremesa AND PedidoSobremesa.fk_PedidoSobremesa_Pedido = @idPedido;", dbContext.connection);
            getCmd.Parameters.AddWithValue("@idSobremesa", idSobremesa);
            getCmd.Parameters.AddWithValue("@idPedido", idPedido);
            

            SQLiteDataReader reader = getCmd.ExecuteReader();

            reader.Read();

            if(!reader.HasRows) {

                return null;
            
            }
            var pedidoSobremesa = new PedidoSobremesa()
            {
                quantidade = int.Parse(reader["quantidade"].ToString()),
                idSobremesa = int.Parse(reader["fk_PedidoSobremesa_Sobremesa"].ToString()),
                idPedido = int.Parse(reader["fk_PedidoSobremesa_Pedido"].ToString()),
            };
           

            return pedidoSobremesa;
        }
        
        

       

    }
}
