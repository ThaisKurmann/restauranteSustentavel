//realiza requisicoes no BD

using RestauranteSustentavel_BE.Models;
using System.Data.SQLite;

namespace RestauranteSustentavel_BE.Repository
{
    public class BebidaRepository
    {

        private readonly DbContext dbContext;

        public BebidaRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //CREATE
        public Bebida InsertBebida(Bebida bebida)
        {

            SQLiteCommand insertCmd = new SQLiteCommand("insert into Bebida(nome, alcoolica, preco) values(@nome, @bool, @preco)", dbContext.connection);
            insertCmd.Parameters.AddWithValue("@nome", bebida.nome);
            insertCmd.Parameters.AddWithValue("@bool", bebida.alcoolica);
            insertCmd.Parameters.AddWithValue("@preco", bebida.preco);
            insertCmd.ExecuteNonQuery();

            //pegando o Id da tabela Bebida
            insertCmd.CommandText = "select last_insert_rowid()";
            Int64 LastRowID64 = (Int64)insertCmd.ExecuteScalar();
            bebida.id = (int)LastRowID64;

            return bebida;
        }



        //READ
        public List<Bebida> GetAllBebida()
        {


            var bebidas = new List<Bebida>();


            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM Bebida", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();


            while (reader.Read())
            {
                var bebida = new Bebida()
                {
                    nome = reader["nome"].ToString(),
                    alcoolica = int.Parse(reader["alcoolica"].ToString()) == 1, //pega o resultado e compara com 1, resultando em um booleano, ou seja, se a == 1, entao eh verdadeiro;
                    id = int.Parse(reader["id"].ToString()),//pegando o Id da tabela Bebida
                    preco = float.Parse(reader["preco"].ToString()),
                };

                bebidas.Add(bebida);//add o obj na lista bebidas
            }


            return bebidas;
        }

        //UPDATE
        public Bebida UpateBebida(Bebida bebida)
        {

            SQLiteCommand updateCmd = new SQLiteCommand("UPDATE Bebida SET nome = @nomeBebida, alcoolica = @bool, preco = @preco WHERE id = @id", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@nomeBebida", bebida.nome);
            updateCmd.Parameters.AddWithValue("@bool", bebida.alcoolica);
            updateCmd.Parameters.AddWithValue("@preco", bebida.preco);
            updateCmd.Parameters.AddWithValue("@id", bebida.id);

            updateCmd.ExecuteNonQuery();


            return bebida;
        }


        //DELETE
        public int DeleteBebida(int i)
        {
            SQLiteCommand deleteCmd = new SQLiteCommand("DELETE FROM Bebida WHERE id = @id", dbContext.connection);
            deleteCmd.Parameters.AddWithValue("@id", i);

            deleteCmd.ExecuteNonQuery();

            return i;//retorna a bebida que foi excluida
        }

      
        public Bebida BuscaBebidaPorId(int idBebida)
        {
            SQLiteCommand searchCmd = new SQLiteCommand("SELECT * FROM Bebida Where id = @id", dbContext.connection);
            searchCmd.Parameters.AddWithValue("@id", idBebida);

            SQLiteDataReader reader = searchCmd.ExecuteReader();


            if (reader.Read())
            { 
                return new Bebida() { 
                    nome = reader["nome"].ToString(),
                    alcoolica = int.Parse(reader["alcoolica"].ToString()) == 1, //pega o resultado e compara com 1, resultando em um booleano, ou seja, se a == 1, entao eh verdadeiro;
                    id = int.Parse(reader["id"].ToString()),//pegando o Id da tabela Bebida
                    preco = float.Parse(reader["preco"].ToString()),
                };
            }


            return null;
        }






    }
}


