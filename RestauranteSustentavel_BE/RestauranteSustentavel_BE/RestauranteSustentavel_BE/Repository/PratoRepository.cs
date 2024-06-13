using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Services;
using System.Data.Entity;
using System.Data.SQLite;

namespace RestauranteSustentavel_BE.Repository
{
    public class PratoRepository
    {

        private readonly DbContext dbContext;

        public PratoRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //CREATE
        public Prato Insert(int pedidoId)
        {

            SQLiteCommand insertCmd = new SQLiteCommand("insert into Prato(fk_Prato_Pedido) values(@idPedido)", dbContext.connection);
            insertCmd.Parameters.AddWithValue("@idPedido", pedidoId);
            insertCmd.ExecuteNonQuery();

            //pegando o Id da tabela Prato
            insertCmd.CommandText = "select last_insert_rowid()";
            Int64 LastRowID64 = (Int64)insertCmd.ExecuteScalar();

            var prato  = new Prato();

            prato.idPrato = (int)LastRowID64;
            prato.idPedido = pedidoId;

            return prato;
        }


        //READ
        public List<Prato> GetAll()
        {


            var pratos = new List<Prato>();


            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM Prato", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();


            while (reader.Read())
            {
                var prato = new Prato()
                {
                    idPrato = int.Parse(reader["id"].ToString()),
                    idPedido = int.Parse(reader["fk_Prato_Pedido"].ToString()),

                };

                pratos.Add(prato);//add o obj na lista 
            }


            return pratos;
        }

     
        //DELETE
        public int Delete(int i)
        {
            SQLiteCommand deleteCmd = new SQLiteCommand("DELETE FROM Prato WHERE id = @id", dbContext.connection);
            deleteCmd.Parameters.AddWithValue("@id", i);

            deleteCmd.ExecuteNonQuery();

            return i;//retorna o prato que foi excluido
        }

        //BUSCA todos os Prato do Pedido x
        public List<Prato> BuscaPratosPorPedidoId(int idPedido)
        {
            var pratos = new List<Prato>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM Prato WHERE fk_Prato_Pedido = @idPedido", dbContext.connection);
            getCmd.Parameters.AddWithValue("@idPedido", idPedido);
            SQLiteDataReader reader = getCmd.ExecuteReader();

            while (reader.Read())
            {
                var prato = new Prato()
                {
                    idPrato = int.Parse(reader["id"].ToString()),
                    idPedido = int.Parse(reader["fk_Prato_Pedido"].ToString()),
                };
                pratos.Add(prato);
            }

            return pratos;
        }





    }
}
