using RestauranteSustentavel_BE.Models;
using System.Data;
using System.Data.SQLite;

namespace RestauranteSustentavel_BE.Repository
{
    public class PedidoRepository
    {



        private readonly DbContext dbContext;


        public PedidoRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //CREATE
        public Pedido Insert(Pedido pedido)
        {

            SQLiteCommand insertCmd = new SQLiteCommand("insert into Pedido(data, hora) values(@data, @hora)", dbContext.connection);
            insertCmd.Parameters.AddWithValue("@data", pedido.data);
            insertCmd.Parameters.AddWithValue("@hora", pedido.hora);
            insertCmd.ExecuteNonQuery();

            //pegando o Id da tabela 
            insertCmd.CommandText = "select last_insert_rowid()";
            Int64 LastRowID64 = (Int64)insertCmd.ExecuteScalar();
            pedido.id = (int)LastRowID64;

            return pedido;
        }



        //READ
        public List<Pedido> GetAll()
        {
            var pedidos = new List<Pedido>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM Pedido", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();


            while (reader.Read())
            {
                var pedido = new Pedido()
                {
                    data = reader["data"].ToString(),
                    hora = reader["hora"].ToString(),
                    id = int.Parse(reader["id"].ToString())//pegando o Id da tabela Bebida
                };

                pedidos.Add(pedido);//add o obj na lista pedidos
            }

            return pedidos;
        }

        //UPDATE
        public Pedido Upate(Pedido pedido)
        {

            SQLiteCommand updateCmd = new SQLiteCommand("UPDATE Pedido SET data = @data, hora = @hora WHERE id = @id", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@data", pedido.data);
            updateCmd.Parameters.AddWithValue("@hora", pedido.hora);
            updateCmd.Parameters.AddWithValue("@id", pedido.id);

            updateCmd.ExecuteNonQuery();


            return pedido;
        }


        //DELETE
        public int Delete(int i)
        {
            SQLiteCommand deleteCmd = new SQLiteCommand("DELETE FROM Pedido WHERE id = @id", dbContext.connection);
            deleteCmd.Parameters.AddWithValue("id", i);
            deleteCmd.ExecuteNonQuery();

            return i;
        }


    }
}
