using Npgsql;
using System;
using System.Security.Cryptography;

namespace MonsterTradingCardGame.Database
{
    class DBConnector
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
        public static int Open()
        {
            connection.Open();
            return 0;
        }
        public static int Close()
        {
            connection.Close();
            return 0;
        }
        public bool RegisterUser(string username, string password, int eloPoints, int coins)
        {
            Open();
            RNGCryptoServiceProvider provider = new();
            byte[] salt = new byte[24];
            provider.GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new(password, salt, 100000);

            NpgsqlCommand cmd = new("SELECT username FROM player WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            Object response = cmd.ExecuteScalar();

            //to do

            Close();
            return true;
        }
        public User GetUser(string username)
        {
            int posOfEloInDbResponse = 0;
            int posOfCoinsInDbResponse = 1;
            Stack userCardStack = GetPlayerStack(username);
            NpgsqlCommand command = new("SELECT elo, coins FROM player WHERE username = @username", connection);
            command.Parameters.AddWithValue("username", username);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            int eloPoints = (int)dataReader[posOfEloInDbResponse];
            int coins = (int)dataReader[posOfCoinsInDbResponse];
            Close();
            User myUser = new(username, userCardStack, eloPoints, coins);
            return myUser;
        }
        public Stack GetPlayerStack(string username)
        {
            //to do
            return new Stack();
        }
    }
}
