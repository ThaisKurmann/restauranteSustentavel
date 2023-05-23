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
            SQLiteCommand insertComd = new SQLiteCommand("INSERT into IngredientePrato(quantidade, fk_IngredientePrato_Ingrediente, fk_IngredientePrato_Prato, preco) values (@quantidade, @idIngrediente, @idPrato); ", dbContext.connection);
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

/*
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


        */

    }
}
