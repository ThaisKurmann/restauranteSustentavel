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


        //READ
        public List<Pedido> GetAllPedidos()
        {
            var pedidos = new List<Pedido>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM Pedido", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();


            while (reader.Read())
            {
                var pedido = new Pedido()
                {
                    nomeCliente = reader["nomeCliente"].ToString(),
                    data = reader["data"].ToString(), 
                    hora = reader["hora"].ToString(),
                    idPrato = int.Parse(reader["fk_Pedido_Prato"].ToString()),                   
                    id = int.Parse(reader["id"].ToString())//pegando o Id da tabela Bebida
                };

                pedidos.Add(pedido);//add o obj na lista pedidos
            }
                
            return pedidos;
        }



        //CREATE
        //sql insert: insert into Pedido(nomeCliente, data, hora, fk_Pedido_Prato) values('Ana', '19/04/2023', '11:11', 8738246) obs: fk contem o id que esta na tabela 'prato'

    }
}
