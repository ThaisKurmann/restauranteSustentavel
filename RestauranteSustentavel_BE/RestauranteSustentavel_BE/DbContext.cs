using System.Data.SQLite;

namespace RestauranteSustentavel_BE
{
    public class DbContext
    {

        public readonly SQLiteConnection connection;

        public DbContext() 
        {
            connection = new SQLiteConnection("Data Source = ../../RestauranteSustentavelDB.db; Version = 3; New = True; Compress = True;");
            connection.Open();
        }
    }
}
