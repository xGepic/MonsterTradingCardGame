using System;
using Npgsql;

namespace MonsterTradingCardGame
{
    public partial class DBConnector
    {
        public void EmergencyCoins(string username)
        {
            int playerCoins = GetPlayerCoins(username);
            int playerCards = CountPlayerStack(username);
            Open();
            int newCoins = 20;
            int minPlayerCoins = 5;
            int minPlayerCards = 4;
            if (playerCoins < minPlayerCoins && playerCards < minPlayerCards)
            {
                Console.WriteLine("You received 20 new Coins!\n");
                NpgsqlCommand cmd = new("UPDATE player SET coins = @coins WHERE username = @name", connection);
                cmd.Parameters.AddWithValue("coins", newCoins);
                cmd.Parameters.AddWithValue("name", username);
                cmd.ExecuteNonQuery();
                Close();
                return;
            }
            else
            {
                Console.WriteLine("You can only get the EmergencyCoins when you meet these requirements:\n");
                Console.WriteLine("- You have less than 5 coins");
                Console.WriteLine("- You have less than 4 cards");
            }
            Close();
        }
        public bool CheckIfUserExists(string username)
        {
            Open();
            NpgsqlCommand cmd = new("SELECT * FROM player WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            Object response = cmd.ExecuteScalar();
            if (response == null)
            {
                Close();
                return false;
            }
            Close();
            return true;
        }
        public void RemoveUser(string username)
        {
            Open();
            NpgsqlCommand cmd = new("DELETE FROM player WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            cmd.ExecuteScalar();
            Close();
        }
        public string GetPWHash(string username)
        {
            Open();
            NpgsqlCommand cmd = new("SELECT password FROM player WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            string response = cmd.ExecuteScalar().ToString();
            Close();
            return response;
        }
    }
}
