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
                Object passwordInDB = passwordCommand.ExecuteScalar();
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: (byte[])salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
                Console.WriteLine(hashed);
                Console.WriteLine(passwordInDB);
                if (hashed == (string)passwordInDB)
                {
                    Close();
                    return true;
                }
            }
            Close();
            return false;
        }
    }
}