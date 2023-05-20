//realiza requisicoes no BD

using RestauranteSustentavel_BE.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

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

            SQLiteCommand insertCmd = new SQLiteCommand("insert into Bebida(nome, alcoolica) values(@nome, @bool)", dbContext.connection);
            insertCmd.Parameters.AddWithValue("@nome", bebida.nome);
            insertCmd.Parameters.AddWithValue("@bool", bebida.alcoolica);
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
                };

                bebidas.Add(bebida);//add o obj na lista bebidas
            }


            return bebidas;
        }

        //UPDATE
        public Bebida UpateBebida(Bebida bebida)
        {

            SQLiteCommand updateCmd = new SQLiteCommand("UPDATE Bebida SET nome = @nomeBebida, alcoolica = @bool WHERE id = @id", dbContext.connection);
            updateCmd.Parameters.AddWithValue("@nomeBebida", bebida.nome);
            updateCmd.Parameters.AddWithValue("@bool", bebida.alcoolica);
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








    }
}


/*
 private string GetSQLAddClient()// HHIER
{
    return "insert into Client(name, street, salutation, number, postalcode, city, extra, priceperhour, pauchal, wegpauchal) values('" + Name + "', '" + Street + "', '" + Salutation + "', '" + Number + "', '" + PostalCode + "', '" + City + "', '" + Extra + "', '" + PricePerHour.ToString("0.00") + "', '" + Pauchal.ToString("0.00") + "', '" + WegPauchal.ToString("0.00") + "')";
}


private string GetSQLGetWorksOnTimeSpam(string start, string end)
{
    return "SELECT * FROM Work WHERE clientId = " + Id + " and date > '" + start + "' and date < '" + end + "'";
}


public List<Work> GetWorksByTime(string start, string end, SQLiteConnection dbContext)
{
    List<Work> ret = new List<Work>();
    SQLiteCommand getCmd = new SQLiteCommand(GetSQLGetWorksOnTimeSpam(start, end), dbContext);
    SQLiteDataReader reader = getCmd.ExecuteReader();
    while (reader.Read())
    {
        ret.Add(new Work(reader["time"].ToString(), float.Parse(reader["price"].ToString()), reader["date"].ToString(), reader["task"].ToString()));
    }
    return ret;
}




 //Conexao com o BD
        public SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source = ../RestauranteSustentavelDB.db; Version = 3; New = True; Compress = True;");
           
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
            }
            return sqlite_conn;
        }


-UPDATE----------------------------------------------------------------

// Query parameters.
    string lastname = "Bloggs";
    string title = "Mrs";
    int id = 5;

    // Query text incorporated into SQL command.
    var sqlUpdate = connect.CreateCommand();
    sqlUpdate.CommandText = @"
        UPDATE person 
        SET lastname = $lastname, 
            title = $title
        WHERE id = $id
    ";

    // Bind the parameters to the query.
    sqlUpdate.Parameters.AddWithValue("$lastname", lastname);
    sqlUpdate.Parameters.AddWithValue("$title", title);
    sqlUpdate.Parameters.AddWithValue("$id", id);

    // Execute SQL.
    sqlUpdate.ExecuteNonQuery();

    // Confirm successful updating of person information.
    Console.WriteLine("Person information updated successfully.");

-----------------------------------------------------------------


 */