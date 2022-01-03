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
        public void EmergencyCoins(string username)
        {
            Open();
            int playerCoins = GetPlayerCoins(username);
            int playerCards = CountPlayerStack(username);
            int newCoins = 20;
            int minPlayerCoins = 5;
            int minPlayerCards = 4;
            if (playerCoins < minPlayerCoins && playerCards < minPlayerCards)
            {
                NpgsqlCommand cmd = new("UPDATE player SET coins = @coins WHERE username = @name", connection);
                cmd.Parameters.AddWithValue("coins", newCoins);
                cmd.Parameters.AddWithValue("name", username);
                cmd.ExecuteNonQuery();
                Close();
            }
            Close();
        }
    }
}