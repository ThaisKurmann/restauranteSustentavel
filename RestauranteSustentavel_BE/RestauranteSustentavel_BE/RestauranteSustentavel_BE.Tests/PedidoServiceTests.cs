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

        public void CriaTabelaPedido(DbContext dbContext)
        {
            SQLiteCommand createTableCmmd = new SQLiteCommand("CREATE TABLE Pedido (\r\n\tid INTEGER NOT NULL,\r\n\tdata TEXT,\r\n\thora TEXT,\r\n\tPRIMARY KEY(id AUTOINCREMENT)\r\n)", dbContext.connection);
            createTableCmmd.ExecuteNonQuery();

        }

        public void CriaTabelaSobremesa(DbContext dbContext)
        {
            SQLiteCommand insertCmd = new SQLiteCommand("CREATE TABLE Sobremesa(\r\n\tnome TEXT,\r\n\tporcao INTEGER,\r\n\tpreco REAL NOT NULL,\r\n\tid INTEGER NOT NULL,\r\n\tPRIMARY KEY(id AUTOINCREMENT)\r\n)", dbContext.connection);
            insertCmd.ExecuteNonQuery();

        }
        public void CriaTabelaPedidoSoobremesa(DbContext dbContext)
        {
            //Arrange: prepara todas as coisas que precisa para realizar o teste
            SQLiteCommand createTableCmmd = new SQLiteCommand("CREATE TABLE \"PedidoSobremesa\" (\r\n\t\"quantidade\"\tINTEGER,\r\n\t\"fk_PedidoSobremesa_Sobremesa\"\tINTEGER NOT NULL,\r\n\t\"fk_PedidoSobremesa_Pedido\"\tINTEGER NOT NULL,\r\n\tFOREIGN KEY(\"fk_PedidoSobremesa_Sobremesa\") REFERENCES \"Sobremesa\"(\"id\"),\r\n\tFOREIGN KEY(\"fk_PedidoSobremesa_Pedido\") REFERENCES \"Pedido\"(\"id\")\r\n);", dbContext.connection);

            createTableCmmd.ExecuteNonQuery();

        }

        [Fact]
        public void InsertPedido_PedidoEhValido_PedidoInseridoComSucesso()//Titulo: metodo q tah sendo testado | condicao | retorno
        {
            //Arrange:
            DbContext dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();


            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);

            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);

            CriaTabelaPedido(dbContext);

            //Act: 
            pedidoRepository.Insert(new Pedido() { data = "14/05/2022", hora = "11:00"});
            
            //Assert:
            var pedidoList = pedidoService.GetAllPedidos();
            
            Assert.Single(pedidoList);// Single = a colecao soh tem um elemento
            Assert.Equal("14/05/2022", pedidoList.First().data);
            Assert.Equal("11:00", pedidoList.First().hora);

           dbContext.connection.Close(); 
            
        }
        //REVER: NAO TERIA QUE TESTAR APENAS OQ A FUNCAO FAZ? ou seja, ela apenas retorna os pedidos que estao no BD
        [Fact]
        public void GetAllPedidos_BanconDeDadosTemPedidos_RetornaListaComTodosOsPedidosExistentesNoBD()
        {
            //Arrange: prepara todas as coisas que precisa para realizar o teste
            DbContext dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();

            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);

            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);

            CriaTabelaPedido(dbContext);
                      
            pedidoRepository.Insert(new Pedido() { data = "14/05/2022", hora = "12:00" });
            pedidoRepository.Insert(new Pedido() { data = "18/05/2022", hora = "11:00" });
            pedidoRepository.Insert(new Pedido() { data = "14/05/2022", hora = "18:30" });
            
            //Act:
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

            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);

            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);


            CriaTabelaPedido(dbContext);

            pedidoRepository.Insert(new Pedido() { data = "14/05/2022", hora = "11:00" });
                  

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

            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);

            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);

            CriaTabelaPedido(dbContext);

            var pedidoInserido = pedidoRepository.Insert(new Pedido() { data = "02/04/2024", hora = "12:00" });
            
            var quantidadePedidosAntesDeletePedido = pedidoService.GetAllPedidos();

            //Act
            pedidoService.DeletePedido(pedidoInserido.id);

            var quantidadePedidosDepoisDeletePedido = pedidoService.GetAllPedidos();

            //Assert
            Assert.Equal(1, quantidadePedidosAntesDeletePedido.Count());
            Assert.Equal(0, quantidadePedidosDepoisDeletePedido.Count());


            
            dbContext.connection.Close();
        }

        [Fact]
        public void BuscaUmPedido_BuscaUmPedidoPorPedidoId_RetornaPedidoDoBancoDeDados()
        {
            //Arrange:
            var dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();
            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);

            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);

            CriaTabelaPedido(dbContext);

            var pedidoInseridoParaTeste = pedidoRepository.Insert(new Pedido() { data = "08/04/2024", hora = "15:00" });

            pedidoRepository.Insert(new Pedido() { data = "01/02/2024", hora = "12:00" });
            pedidoRepository.Insert(new Pedido() { data = "10/07/2024", hora = "12:45" });
            pedidoRepository.Insert(new Pedido() { data = "03/04/2024", hora = "13:00" });

            
            //Act:
            var pedidoBuscado = pedidoService.BuscaUmPedido(pedidoInseridoParaTeste.id);
            var pedidoInexistenteNoBD = pedidoService.BuscaUmPedido(10);            

            //Assert:
            Assert.Equal(pedidoInseridoParaTeste.id, pedidoBuscado.id);
            Assert.Equal(pedidoInseridoParaTeste.data, pedidoBuscado.data);
            Assert.Equal(pedidoInseridoParaTeste.hora, pedidoBuscado.hora);

            Assert.Null(pedidoInexistenteNoBD);

            dbContext.connection.Close();
        }

        //Proximas Task's:

        //[PedidoSobremesa: BUSCA pedido por Id]
        [Fact]
        public void BuscaPedidoSobremesasPorPedidoId_PedidoTemSobremesas_RetornaListaDeSobremesasDoPedido()
        {
            //Arrange:
            var dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();
            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);
            var sobremesaRepository = new SobremesaRepository(dbContext);

            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);

            CriaTabelaPedido(dbContext);
            CriaTabelaSobremesa(dbContext);
            CriaTabelaPedidoSoobremesa(dbContext);
                
            var pedidoParaTeste1 = pedidoRepository.Insert(new Pedido() { data = "02/05/2024", hora = "11:30"});
            var pedidoParaTeste2 = pedidoRepository.Insert(new Pedido() { data = "01/05/2024", hora = "12:30" });
            var pedidoParaTeste3 = pedidoRepository.Insert(new Pedido() { data = "03/06/2024", hora = "12:30" });

            
            var sobremesa1 = sobremesaRepository.InsertSobremesa(new Sobremesa() {nome = "profiteroles", porcao = 90, preco = 7});
            var sobremesa2 = sobremesaRepository.InsertSobremesa(new Sobremesa() { nome = "mousse de maracuja", porcao = 100, preco = 10});

           
            pedidoSobremesaRepository.Insert(sobremesa2.id, pedidoParaTeste2.id, 3);
            pedidoSobremesaRepository.Insert(sobremesa1.id, pedidoParaTeste1.id, 1);
            pedidoSobremesaRepository.Insert(sobremesa1.id, pedidoParaTeste2.id, 5);

            //Act:
            var pedidoTemUmaSobremesa = pedidoService.BuscaPedidoSobremesasPorPedidoId(pedidoParaTeste1.id);
            var pedidoTemMaisDeUmaSobremesa = pedidoService.BuscaPedidoSobremesasPorPedidoId(pedidoParaTeste2.id);
            var pedidoNaoTemSobremesa = pedidoService.BuscaPedidoSobremesasPorPedidoId(pedidoParaTeste3.id);

            //Assert:
            //pedido tem mais de uma sobremesa
            Assert.Equal(2, pedidoTemMaisDeUmaSobremesa.Count());
            //pedido tem uma sobremesa
            Assert.Equal(1, pedidoTemUmaSobremesa.Count());
            //pedido nao tem sobremesa
            Assert.Equal(0, pedidoNaoTemSobremesa.Count());


            dbContext.connection.Close();
        }


        //[PedidoSobremesa: INSERT sobremesa]
        [Fact]
        public void InsertSobremesaEmPedido_PedidoNaoTemSobremesa_RetornaSobremesaAdicionadaAoPedido()
        {
            //Arrange:
            var dbContext = new DbContext(new SQLiteConnection("DataSource=:memory:"));
            dbContext.connection.Open();
            var pedidoRepository = new PedidoRepository(dbContext);
            var pedidoSobremesaRepository = new PedidoSobremesaRepository(dbContext);
            var pedidoBebidaRepository = new PedidoBebidaRepository(dbContext);
            var sobremesaRepository = new SobremesaRepository(dbContext);

            var pedidoService = new PedidoService(pedidoRepository, pedidoSobremesaRepository, pedidoBebidaRepository);

            CriaTabelaPedido(dbContext);
            CriaTabelaSobremesa(dbContext);
            CriaTabelaPedidoSoobremesa(dbContext);

            var pedidoTeste1 = pedidoRepository.Insert(new Pedido() { data = "02/05/2024", hora = "11:30" });
            var pedidoTeste2 = pedidoRepository.Insert(new Pedido() { data = "01/05/2024", hora = "12:30" });
            var pedidoTeste3 = pedidoRepository.Insert(new Pedido() { data = "03/06/2024", hora = "12:30" });


            var sobremesaTeste1 = sobremesaRepository.InsertSobremesa(new Sobremesa() { nome = "profiteroles", porcao = 90, preco = 7 });
            var sobremesaTeste2 = sobremesaRepository.InsertSobremesa(new Sobremesa() { nome = "mousse de maracuja", porcao = 100, preco = 10 });

            //Act:
            //
            //pedidoService.InsertSobremesaEmPedido(sobremesaTeste2.id, pedidoTeste2.id, 5);
            var pedidoComUmaSobremesaInserida = pedidoService.GetAllPedidoSobremesa();

            pedidoService.InsertSobremesaEmPedido(sobremesaTeste1.id, pedidoTeste1.id, 3);
            pedidoService.InsertSobremesaEmPedido(sobremesaTeste2.id, pedidoTeste1.id, 2);
            pedidoService.InsertSobremesaEmPedido(sobremesaTeste2.id, pedidoTeste1.id, 2);

            var pedidoComVariasSobremesas = pedidoService.GetAllPedidoSobremesa();

            //Assert:
            //Verifica se inseriu uma sobremesa a um pedido
            Assert.Equal(1, pedidoComUmaSobremesaInserida.Where(pedido => pedido.idPedido == 2).Count());
            //Verifica se inseriu mais de uma sobremesa a um pedido
            var A = pedidoComVariasSobremesas.Where(pedido => pedido.idPedido == 1).ToList();
            Assert.Equal(2, pedidoComVariasSobremesas.Where(pedido => pedido.idPedido == 1).Count());
            //Nao inseriu sobremesas
            Assert.Equal(0, pedidoComVariasSobremesas.Where(pedido => pedido.idPedido == 3).Count());
            

            dbContext.connection.Close();

        }


        //[PedidoSobremesa: READ]
        //[PedidoSobremesa: UPDATE]
        //------------------------> NAO DEVERIA TER DELETE??

        //[PedidoBebida: INSERT] 
        //[PedidoBebida: READ] 
        //[PedidoBebida: UPDATE]
        //[PedidoBebida: DELETE]
        //[PedidoBebida: BUSCA] 


    }
}