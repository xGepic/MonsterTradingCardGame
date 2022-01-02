using System;
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
        public int GetPlayerCoins(string username)
        {
            Open();
            NpgsqlCommand myCommand = new("SELECT coins FROM player WHERE username = @name;", connection);
            myCommand.Parameters.AddWithValue("name", username);
            Object coins = myCommand.ExecuteScalar();
            if (coins != null)
            {
                int playerCoins = Convert.ToInt32(coins);
                Close();
                return playerCoins;
            }
            Close();
            return 0;
        }
        public void PrintPlayerStack(string username)
        {
            int index = 1;
            Open();
            NpgsqlCommand cmd = new("SELECT * FROM stackcards WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            Object response = cmd.ExecuteScalar();
            if (response == null)
            {
                Console.WriteLine("You have no Cards!\n");
                Close();
                Tools.PressAnyKey();
            }
            else
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    Console.WriteLine("Here are your Cards:\n");
                    while (reader.Read())
                    {
                        Console.WriteLine(index + ". " + reader.GetString(1) + "\n");
                        index++;
                    }
                    Close();
                }
            }
        }
        public bool IsDeckEmpty(string username)
        {
            Open();
            NpgsqlCommand cmd = new("SELECT * FROM deckcards WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            Object response = cmd.ExecuteScalar();
            if (response != null)
            {
                Close();
                return false;
            }
            Close();
            return true;
        }
    }
}