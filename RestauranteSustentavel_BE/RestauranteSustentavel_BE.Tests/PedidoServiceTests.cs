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
    public class PedidoServiceTests
    {

      
        public PedidoService PreparaBancoDeDadosParaRealizarOsTestes(DbContext dbContext)
        {
            //Arrange: prepara todas as coisas que precisa para realizar o teste
            SQLiteCommand createTableCmmd = new SQLiteCommand("CREATE TABLE Pedido (\r\n\tid INTEGER NOT NULL,\r\n\tdata TEXT,\r\n\thora TEXT,\r\n\tPRIMARY KEY(id AUTOINCREMENT)\r\n)", dbContext.connection);
            createTableCmmd.ExecuteNonQuery();

            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);

            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);

            return pedidoService;

        }

        [Fact]
        public void InsertPedido_PedidoEhValido_PedidoInseridoComSucesso()//Titulo: metodo q tah sendo testado | condicao | retorno
        {
            //Arrange:
            DbContext dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();

            var pedidoService = PreparaBancoDeDadosParaRealizarOsTestes(dbContext);

            //Act: 
            pedidoService.InsertPedido(new Pedido() { data = "14/05/2022", hora = "11:00"});
            
            //Assert:
            var pedidoList = pedidoService.GetAllPedidos();
            
            Assert.Single(pedidoList);// Single = a colecao soh tem um elemento
            Assert.Equal("14/05/2022", pedidoList.First().data);
            Assert.Equal("11:00", pedidoList.First().hora);

           dbContext.connection.Close(); 
            
        }

        [Fact]
        public void GetAllPedidos_BanconDeDadosTemPedidos_RetornaListaComTodosOsPedidosExistentesNoBD()
        {
            //Arrange: prepara todas as coisas que precisa para realizar o teste
            DbContext dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();
            
            var pedidoService = PreparaBancoDeDadosParaRealizarOsTestes(dbContext);

            //Act:Os pedidos que "estao" no BD
            pedidoService.InsertPedido(new Pedido() { data = "14/05/2022", hora = "12:00" });
            pedidoService.InsertPedido(new Pedido() { data = "18/05/2022", hora = "11:00" });
            pedidoService.InsertPedido(new Pedido() { data = "14/05/2022", hora = "18:30" });

            var pedidoList = pedidoService.GetAllPedidos();

            //Assert: verifica se os pedidos estao de acordo com a quantidade dos dados que estao no BD
            Assert.Equal(2, pedidoList.Where(pedido => pedido.data == "14/05/2022").Count());
            Assert.Equal(1, pedidoList.Where(pedido => pedido.data == "18/05/2022").Count());
            Assert.Equal(1, pedidoList.Where(pedido => pedido.data == "14/05/2022" && pedido.hora == "12:00").Count());

            dbContext.connection.Close();
        }

        [Fact]
        public void UpdatePedido_PedidoEhValido_RetornaPedidoAtualizado()//Titulo: oq tah sendo testado | qual a condicao | o que espero
        {
            //Arrange: prepara todas as coisas que precisa para realizar o teste
            DbContext dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();
           
            var pedidoService = PreparaBancoDeDadosParaRealizarOsTestes(dbContext);

            pedidoService.InsertPedido(new Pedido() { data = "14/05/2022", hora = "11:00" });
                  

            //Act: testa o que deseja
            pedidoService.UpdatePedido(new Pedido() { data = "15/05/2023", hora = "13:00", id = 1 });
            
            //Assert: 
            var pedidoList = pedidoService.GetAllPedidos();
            
            Assert.Single(pedidoList);
            Assert.Equal("15/05/2023", pedidoList.First().data);
            Assert.Equal("13:00", pedidoList.First().hora);

            dbContext.connection.Close();

        }


        
        [Fact]
        public void DeletePedido_BancoDeDadosTemPedidoX_ExcluiPedidoXDoBancoDeDados()
        {
            //Arrange
            DbContext dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();
            
            var pedidoService = PreparaBancoDeDadosParaRealizarOsTestes(dbContext);

            var pedidoInserido = pedidoService.InsertPedido(new Pedido() { data = "02/04/2024", hora = "12:00" });
            
            var quantidadePedidosAntesDeletePedido = pedidoService.GetAllPedidos().Count();

            //Act
            pedidoService.DeletePedido(pedidoInserido.id);

            var quantidadePedidosDepoisDeletePedido = pedidoService.GetAllPedidos().Count();

            //Assert
            Assert.Equal(1, quantidadePedidosAntesDeletePedido);
            Assert.Equal(0, quantidadePedidosDepoisDeletePedido);


            
            dbContext.connection.Close();
        }






    }
}

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