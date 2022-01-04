using Npgsql;

namespace MonsterTradingCardGame
{
    public partial class DBConnector
    {
        private readonly static DBConnector DatabaseInstance = new();
        private readonly static NpgsqlConnection connection = new("Server=localhost; User Id=postgres; Password=asdf; Database=postgres;");
        private DBConnector()
        {

        }
        public static DBConnector GetInstance()
        {
            return DatabaseInstance;
        }
        public static void Open()
        {
            connection.Open();
        }
        public static void Close()
        {
            connection.Close();
        }
        public void AddCardToCards()
        {
            Open();
            NpgsqlCommand insertCmd = new("INSERT INTO card VALUES('SolarBeam', 20, 0, 0);", connection);
            insertCmd.ExecuteNonQuery();
            Close();
        }
    }
}