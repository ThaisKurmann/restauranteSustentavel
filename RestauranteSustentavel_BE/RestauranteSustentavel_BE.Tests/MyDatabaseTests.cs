using System.Data.SQLite;
using Xunit;
using RestauranteSustentavel_BE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Services;
using RestauranteSustentavel_BE.Repository;

namespace RestauranteSustentavel_BE.Tests
{
    public class MyDataBaseTests
    {

        [Fact]
        public void TestDatabaseConnection()
        {
            DbContext dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();

            SQLiteCommand createTableCmmd = new SQLiteCommand("CREATE TABLE Pedido (\r\n\tid INTEGER NOT NULL,\r\n\tdata TEXT,\r\n\thora TEXT,\r\n\tPRIMARY KEY(id AUTOINCREMENT)\r\n)", dbContext.connection);
            createTableCmmd.ExecuteNonQuery();

           /* SQLiteCommand insertCmd = new SQLiteCommand("insert into Pedido(data, hora) values(@data, @hora)", dbContext.connection);
            insertCmd.Parameters.AddWithValue("@data","10/05/2023");
            insertCmd.Parameters.AddWithValue("@hora", "11:00");
            insertCmd.ExecuteNonQuery();

            //pegando o Id da tabela 
            insertCmd.CommandText = "select last_insert_rowid()";
            Int64 LastRowID64 = (Int64)insertCmd.ExecuteScalar();
            var id = (int)LastRowID64;

            var pedidos = new List<Pedido>();

            SQLiteCommand getCmd = new SQLiteCommand("SELECT * FROM Pedido", dbContext.connection);
            SQLiteDataReader reader = getCmd.ExecuteReader();

            while (reader.Read())
            {
                var pedido = new Pedido()
                {
                    data = reader["data"].ToString(),
                    hora = reader["hora"].ToString(),
                    id = int.Parse(reader["id"].ToString())//pegando o Id da tabela 
                };

                pedidos.Add(pedido);//add o obj na lista 
            }
           */
            
            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);
            
            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);

            pedidoService.InsertPedido(new Pedido() { data = "14/05/2022", hora = "11:00"});
            var pedidoList = pedidoService.GetAllPedidos();

            Assert.Single(pedidoList);// Single = a colecao soh tem um elemento
            Assert.Equal("14/05/2022", pedidoList.First().data);
            Assert.Equal("11:00", pedidoList.First().hora);


            dbContext.connection.Close(); 
            
        }

        //Add outros metodos de teste se necessario
      

    }
}