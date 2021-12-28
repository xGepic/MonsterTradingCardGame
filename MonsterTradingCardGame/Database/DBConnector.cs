using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Npgsql;
using System;
using System.Security.Cryptography;

namespace MonsterTradingCardGame
{
    public class DBConnector
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
        public bool RegisterUser(string username, string password, int eloPoints, int coins)
        {
            Open();
            RNGCryptoServiceProvider provider = new();
            byte[] mySalt = new byte[128 / 8];
            provider.GetBytes(mySalt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
              password: password,
              salt: mySalt,
              prf: KeyDerivationPrf.HMACSHA256,
              iterationCount: 100000,
              numBytesRequested: 256 / 8));
            NpgsqlCommand command1 = new("SELECT username FROM player WHERE username = @name", connection);
            command1.Parameters.AddWithValue("name", username);
            command1.ExecuteScalar();
            NpgsqlCommand command2 = new("SELECT username FROM player WHERE username = @name", connection);
            command2.Parameters.AddWithValue("name", username);
            Object response2 = command2.ExecuteScalar();
            if (response2 == null)
            {
                NpgsqlCommand insertCommand = new("INSERT INTO player (username, password, elo, coins, salt) VALUES (@name, @password, @elo, @coins, @salt);", connection);
                insertCommand.Parameters.AddWithValue("name", username);
                insertCommand.Parameters.AddWithValue("password", hashed);
                insertCommand.Parameters.AddWithValue("elo", eloPoints);
                insertCommand.Parameters.AddWithValue("coins", coins);
                insertCommand.Parameters.AddWithValue("salt", mySalt);
                insertCommand.ExecuteReader();
                Close();
                return true;
            }
            Close();
            return false;
        }
        public bool LogInUser(string username, string password)
        {
            Open();
            NpgsqlCommand saltCommand = new("SELECT salt FROM player WHERE username = @name;", connection);
            saltCommand.Parameters.AddWithValue("name", username);
            Object salt = saltCommand.ExecuteScalar();
            if (salt != null)
            {
                NpgsqlCommand passwordCommand = new("SELECT password FROM player WHERE username = @name;", connection);
                passwordCommand.Parameters.AddWithValue("name", username);
                string passwordInDB = (string)passwordCommand.ExecuteScalar();
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: (byte[])salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
                if (hashed == passwordInDB)
                {
                    Close();
                    return true;
                }
            }
            Close();
            return false;
        }
        public bool GetLeaderboard()
        {
            int index = 1;
            Open();
            NpgsqlCommand myCommand = new("SELECT * FROM player ORDER BY elo DESC", connection);
            using NpgsqlDataReader reader = myCommand.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Console.WriteLine(index + ". Name: {0} ELO: {1}\n", reader.GetString(0).PadRight(10, ' '), reader.GetInt32(2).ToString().PadRight(10, ' '));
                    index++;
                }
                Close();
                return true;
            }
            Close();
            return false;
        }
        public bool GetProfile(string username)
        {
            Open();
            NpgsqlCommand myCommand = new("SELECT * FROM player WHERE username = @name;", connection);
            myCommand.Parameters.AddWithValue("name", username);
            using NpgsqlDataReader reader = myCommand.ExecuteReader();
            if (reader != null)
            {
                reader.Read();
                Console.WriteLine("Name: {0}\nELO: {1}\nCoins: {2}", reader.GetString(0), reader.GetInt32(2), reader.GetInt32(3));
                Close();
                return true;
            }
            Close();
            return false;
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
        public bool DecreaseCoinsofPlayer(string username)
        {
            Open();
            NpgsqlCommand myCommand = new("UPDATE player SET coins=coins-5 WHERE username = @name;", connection);
            myCommand.Parameters.AddWithValue("name", username);
            int rows = myCommand.ExecuteNonQuery();
            if (rows == 1)
            {
                Close();
                return true;
            }
            Close();
            return false;
        }
        public bool BuyACardPack()
        {
            int index = 1;
            Open();
            NpgsqlCommand myCommand = new("SELECT * FROM card ORDER BY RANDOM() LIMIT 5;", connection);
            using NpgsqlDataReader reader = myCommand.ExecuteReader();
            if (reader != null)
            {
                Console.WriteLine("You acquired the following cards:\n");
                while (reader.Read())
                {
                    if (reader.IsDBNull(4))
                    {
                        Console.WriteLine(index + ". Name: {0}, Damage: {1}, CardType: {2}, ElementType: {3}\n", reader.GetString(0), reader.GetInt32(1), (CardType)reader.GetInt32(2), (ElementType)reader.GetInt32(3));
                        index++;
                    }
                    else
                    {
                        Console.WriteLine(index + ". Name: {0}, Damage: {1}, CardType: {2}, ElementType: {3}, MonsterType: {4}\n", reader.GetString(0), reader.GetInt32(1), (CardType)reader.GetInt32(2), (ElementType)reader.GetInt32(3), (MonsterType)reader.GetInt32(4));
                        index++;
                    }
                }
                Close();
                return true;
            }
            Close();
            return false;
        }
    }
}