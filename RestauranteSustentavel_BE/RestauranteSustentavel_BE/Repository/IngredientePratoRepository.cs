using RestauranteSustentavel_BE.Models;
using System.Data.SQLite;

namespace RestauranteSustentavel_BE.Repository
{
    public class IngredientePratoRepository
    {

        private readonly DbContext dbContext;


        public IngredientePratoRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        
        //CREATE
        public IngredientePrato Insert(IngredientePrato ingredientePrato)
        {
            SQLiteCommand insertComd = new SQLiteCommand("INSERT into IngredientePrato(quantidade, fk_IngredientePrato_Ingrediente, fk_IngredientePrato_Prato) values (@quantidade, @idIngrediente, @idPrato); ", dbContext.connection);
            insertComd.Parameters.AddWithValue("@quantidade", ingredientePrato.quantidade);
            insertComd.Parameters.AddWithValue("@idIngrediente", ingredientePrato.idIngrediente);
            insertComd.Parameters.AddWithValue("@idPrato", ingredientePrato.idPrato);
            insertComd.ExecuteNonQuery();


            return ingredientePrato;
        }



        //READ
        public List<IngredientePrato> GetAllIngredientePrato()
        {
            var ingredientePratos = new List<IngredientePrato>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM IngredientePrato", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();

            while (reader.Read())
            {
                var ingredientePrato = new IngredientePrato()
                {
                    quantidade = int.Parse(reader["quantidade"].ToString()),
                    idIngrediente = int.Parse(reader["fk_IngredientePrato_Ingrediente"].ToString()),
                    idPrato = int.Parse(reader["fk_IngredientePrato_Prato"].ToString()),
                };

                ingredientePratos.Add(ingredientePrato);//add o obj na lista 
            }

            return ingredientePratos;
        }


        //todo:UPDATE
        public IngredientePrato UpadateIngredientePrato(IngredientePrato ingredientePrato)
        {
            SQLiteCommand updateCmd = new SQLiteCommand("UPDATE IngredientePrato \r\nSET quantidade = @quantidade\r\nWHERE IngredientePrato.fk_IngredientePrato_Ingrediente = @idIngrediente AND IngredientePrato.fk_IngredientePrato_Prato = @idPrato;", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@quantidade", ingredientePrato.quantidade);
            updateCmd.Parameters.AddWithValue("@idIngrediente", ingredientePrato.idIngrediente);
            updateCmd.Parameters.AddWithValue("@idPrato", ingredientePrato.idPrato);

            updateCmd.ExecuteNonQuery();


            return ingredientePrato;
        }



        //DELETE
        public void DeleteIngredientePrato(IngredientePrato ingredientePrato)
        {
            SQLiteCommand deleteCmd = new SQLiteCommand("DELETE FROM IngredientePrato WHERE fk_IngredientePrato_Ingrediente = @idIngrediente AND fk_IngredientePrato_Prato = @idPrato", dbContext.connection);
            deleteCmd.Parameters.AddWithValue("@idIngrediente", ingredientePrato.idIngrediente);
            deleteCmd.Parameters.AddWithValue("@idPrato", ingredientePrato.idPrato);
            deleteCmd.ExecuteNonQuery();

        }

       
         //BUSCA UM Prato na tabela IngredientePrato
        public List<IngredientePrato> BuscaPratoEmIngredientePratoBD(int idPrato)
        {
           var ingredientePratos = new List<IngredientePrato>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM IngredientePrato WHERE fk_IngredientePrato_Prato = @idPrato", dbContext.connection);
            getCmd.Parameters.AddWithValue("@idPrato", idPrato);
            SQLiteDataReader reader = getCmd.ExecuteReader();

            while(reader.Read())
            {
                var ingredientePrato = new IngredientePrato()
                {
                    quantidade = int.Parse(reader["quantidade"].ToString()),
                    idIngrediente = int.Parse(reader["fk_IngredientePrato_Ingrediente"].ToString()),
                    idPrato = int.Parse(reader["fk_IngredientePrato_Prato"].ToString()),
                };
                ingredientePratos.Add(ingredientePrato);
            } 

            return ingredientePratos;
        }

       /* 
       public IngredientePrato BuscaUmaSobremesaEmPedido(int idSobremesa, int idPedido)
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
       
        */

    }
}
