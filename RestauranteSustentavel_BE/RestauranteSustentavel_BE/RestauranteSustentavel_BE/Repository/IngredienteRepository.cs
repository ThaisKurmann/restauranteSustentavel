using RestauranteSustentavel_BE.Models;
using System.Data.SQLite;

namespace RestauranteSustentavel_BE.Repository
{
    public class IngredienteRepository
    {
        private readonly DbContext dbContext;
        public IngredienteRepository(DbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        
        
        
        //CREATE
        public Ingrediente InsertIngrediente(Ingrediente ingrediente)
        {

            SQLiteCommand insertCmd = new SQLiteCommand("insert into Ingrediente(nome, porcaoEmGramas, tipoDoAlimento, preco) values(@nome, @porcao, @tipo, @preco)", dbContext.connection);
            insertCmd.Parameters.AddWithValue("@nome", ingrediente.nome);
            insertCmd.Parameters.AddWithValue("@porcao", ingrediente.porcao);
            insertCmd.Parameters.AddWithValue("@tipo", ingrediente.tipoAlimento);
            insertCmd.Parameters.AddWithValue("@preco", ingrediente.preco);
            insertCmd.ExecuteNonQuery();

            //pegando o Id da tabela Bebida
            insertCmd.CommandText = "select last_insert_rowid()";
            Int64 LastRowID64 = (Int64)insertCmd.ExecuteScalar();
            ingrediente.id = (int)LastRowID64;

            return ingrediente;
        }


       
        //READ
        public List<Ingrediente> GetAllIngrediente()
        {


            var ingredientes = new List<Ingrediente>();


            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM Ingrediente", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();


            while (reader.Read())
            {
                var ingrediente = new Ingrediente()
                {
                    nome = reader["nome"].ToString(),
                    porcao = int.Parse(reader["porcaoEmGramas"].ToString()),
                    tipoAlimento = reader["tipoDoAlimento"].ToString(),
                    id = int.Parse(reader["id"].ToString()),//pegando o Id da tabela 
                    preco = float.Parse(reader["preco"].ToString()),
                };

                ingredientes.Add(ingrediente);//add o obj na lista ingredientes
            }


            return ingredientes;
        }

        //UPDATE
        public Ingrediente UpateBebida(Ingrediente ingrediente)
        {

            SQLiteCommand updateCmd = new SQLiteCommand("UPDATE Ingrediente SET nome = @nome, porcaoEmGramas = @gramas, tipoDoAlimento = @tipo, preco = @preco WHERE id = @id", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@nome", ingrediente.nome);
            updateCmd.Parameters.AddWithValue("@gramas", ingrediente.porcao);
            updateCmd.Parameters.AddWithValue("@tipo", ingrediente.tipoAlimento);
            updateCmd.Parameters.AddWithValue("@id", ingrediente.id);
            updateCmd.Parameters.AddWithValue("@preco", ingrediente.preco);
            updateCmd.ExecuteNonQuery();


            return ingrediente;
        }

        
       //DELETE
       public int DeleteIngrediente(int i)
       {
           SQLiteCommand updateCmd = new SQLiteCommand("DELETE FROM Ingrediente WHERE id = @id", dbContext.connection);
           updateCmd.Parameters.AddWithValue("@id", i);

           updateCmd.ExecuteNonQuery();

           return i;//retorna a ingrediente excluido
       }

        //BUSCA UM INGREDIENTE NO BD
        public Ingrediente BuscaIngredientePorId(int idIngrediente)
        {
            SQLiteCommand searchCmd = new SQLiteCommand("SELECT * FROM Ingrediente Where id = @id", dbContext.connection);
            searchCmd.Parameters.AddWithValue("@id", idIngrediente);

            SQLiteDataReader reader = searchCmd.ExecuteReader();


            if (reader.Read())
            {   //pega os dados do BD
                return new Ingrediente()
                {
                    nome = reader["nome"].ToString(),
                    id = int.Parse(reader["id"].ToString()),
                    preco = float.Parse(reader["preco"].ToString()),
                    porcao = int.Parse(reader["porcaoEmGramas"].ToString()),
                    tipoAlimento = reader["tipoDoAlimento"].ToString()

                };
            }


            return null;
        }



    }
}
