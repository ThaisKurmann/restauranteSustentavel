using RestauranteSustentavel_BE.Models;
using System.Data.SQLite;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestauranteSustentavel_BE.Repository
{
    public class SobremesaRepository
    {
        private readonly DbContext dbContext;
        public SobremesaRepository(DbContext dbContext) 
        {
            this.dbContext = dbContext;
        }


        //CREATE
        public Sobremesa InsertSobremesa(Sobremesa sobremesa)
        {

            SQLiteCommand insertCmd = new SQLiteCommand("insert into Sobremesa(nome, porcao) values(@nome, @gramas)", dbContext.connection);
            insertCmd.Parameters.AddWithValue("@nome", sobremesa.nome);
            insertCmd.Parameters.AddWithValue("@gramas", sobremesa.porcao);
            insertCmd.ExecuteNonQuery();

            //pegando o Id da tabela Sobremesa
            insertCmd.CommandText = "select last_insert_rowid()";
            Int64 LastRowID64 = (Int64)insertCmd.ExecuteScalar();
            sobremesa.id = (int)LastRowID64;

            return sobremesa;
        }

        //READ
        public List<Sobremesa> GetAllSobremesa()
        {


            var sobremesas = new List<Sobremesa>();


            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM Sobremesa", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();


            while (reader.Read())
            {
                var sobremesa = new Sobremesa()
                {
                    nome = reader["nome"].ToString(),
                    porcao = int.Parse(reader["porcao"].ToString()),
                    id = int.Parse(reader["id"].ToString()),//pegando o Id da tabela Sobremesa
                };

                sobremesas.Add(sobremesa);//add o obj na lista sobremesas
            }


            return sobremesas;
        }

        //UPDATE
        public Sobremesa UpateSobremesa(Sobremesa sobremesa)
        {

            SQLiteCommand updateCmd = new SQLiteCommand("UPDATE Sobremesa SET nome = @nomeSobremesa, porcao = @gramas WHERE id = @id", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@nomeSobremesa", sobremesa.nome);
            updateCmd.Parameters.AddWithValue("@gramas", sobremesa.porcao);
            updateCmd.Parameters.AddWithValue("@id", sobremesa.id);

            updateCmd.ExecuteNonQuery();


               return sobremesa;
        }


        //DELETE
        public int DeleteSobremesa(int i)
        {
            SQLiteCommand updateCmd = new SQLiteCommand("DELETE FROM Sobremesa WHERE id = @id", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@id", i);

            updateCmd.ExecuteNonQuery();

            return i;//retorna a sobremesa que foi excluida
        }


    }
}
