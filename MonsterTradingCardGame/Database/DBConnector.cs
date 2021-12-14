using Npgsql;

namespace MonsterTradingCardGame.Database
{
    class DBConnector
    {
        private static DBConnector DatabaseInstance = new DBConnector();
        private static NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=asdf; Database=postgres;");
        private DBConnector()
        {

        }
        public static DBConnector GetInstance()
        {
            return DatabaseInstance;
        }
        public int Open()
        {
            connection.Open();
            return 0;
        }
    }
}
