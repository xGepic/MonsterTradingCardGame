﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Npgsql;
using System;
using System.Collections.Generic;
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
        public int GetPlayerElo(string username)
        {
            Open();
            NpgsqlCommand cmd = new("SELECT elo FROM player WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            Object elo = cmd.ExecuteScalar();
            if (elo != null)
            {
                int playerElo = Convert.ToInt32(elo);
                Close();
                return playerElo;
            }
            Close();
            return 0;
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
        public void DecreaseCoinsofPlayer(string username)
        {
            Open();
            NpgsqlCommand myCommand = new("UPDATE player SET coins=coins-5 WHERE username = @name;", connection);
            myCommand.Parameters.AddWithValue("name", username);
            myCommand.ExecuteNonQuery();
            Close();
        }
        public void BuyACardPack(string username)
        {
            int index = 1;
            List<string> CardList = new();
            Open();
            NpgsqlCommand myCommand = new("SELECT * FROM card ORDER BY RANDOM() LIMIT 5;", connection);
            using NpgsqlDataReader reader = myCommand.ExecuteReader();
            if (reader != null)
            {
                Console.Clear();
                Console.WriteLine("You acquired the following cards:\n");
                while (reader.Read())
                {
                    if (reader.IsDBNull(4))
                    {
                        Console.WriteLine(index + ". Name: {0}, Damage: {1}, CardType: {2}, ElementType: {3}\n", reader.GetString(0), reader.GetInt32(1), (CardType)reader.GetInt32(2), (ElementType)reader.GetInt32(3));
                        CardList.Add(reader.GetString(0));
                        index++;
                    }
                    else
                    {
                        Console.WriteLine(index + ". Name: {0}, Damage: {1}, CardType: {2}, ElementType: {3}, MonsterType: {4}\n", reader.GetString(0), reader.GetInt32(1), (CardType)reader.GetInt32(2), (ElementType)reader.GetInt32(3), (MonsterType)reader.GetInt32(4));
                        CardList.Add(reader.GetString(0));
                        index++;
                    }
                }
                Console.WriteLine("\nAll new Cards have been added to your Stack!\n\n");
                Close();
                AddCardToStack(username, CardList);
            }
            Close();
        }
        public void AddCardToStack(string username, List<string> cardList)
        {
            Open();
            NpgsqlCommand searchCommand = new("SELECT cardname FROM stackcards WHERE username = @name AND cardname = @name2", connection);
            NpgsqlCommand insertCommand = new("INSERT INTO stackcards (username, cardname) VALUES (@username, @cardname);", connection);
            for (int i = 0; i < 5; i++)
            {
                searchCommand.Parameters.Clear();
                searchCommand.Parameters.AddWithValue("name", username);
                searchCommand.Parameters.AddWithValue("name2", cardList[i]);
                Object response = searchCommand.ExecuteScalar();
                if (response == null)
                {
                    insertCommand.Parameters.Clear();
                    insertCommand.Parameters.AddWithValue("username", username);
                    insertCommand.Parameters.AddWithValue("cardname", cardList[i]);
                    insertCommand.ExecuteNonQuery();
                }
            }
            Close();
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
        public void AddCardsToDeck(string username, List<int> cardlist)
        {
            Open();
            NpgsqlCommand cmd = new("SELECT cardname FROM stackcards WHERE username = @name LIMIT 1 OFFSET @offset", connection);
            NpgsqlCommand insertCommand = new("INSERT INTO deckcards (username, cardname) VALUES (@username, @cardname);", connection);
            for (int i = 0; i < cardlist.Count; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("name", username);
                cmd.Parameters.AddWithValue("offset", cardlist[i] - 1);
                Object response = cmd.ExecuteScalar();
                string tempCard = response.ToString();
                insertCommand.Parameters.Clear();
                insertCommand.Parameters.AddWithValue("username", username);
                insertCommand.Parameters.AddWithValue("cardname", tempCard);
                insertCommand.ExecuteNonQuery();
            }
            Close();
        }
        public void ClearDeck(string username)
        {
            Open();
            NpgsqlCommand cmd = new("DELETE FROM deckcards WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            cmd.ExecuteScalar();
            Close();
            Console.Clear();
            Console.WriteLine("Deck cleared!\n");
            Tools.PressAnyKey();
            Console.Clear();
        }
        public void PrintPlayerDeck(string username)
        {
            int index = 1;
            Open();
            NpgsqlCommand cmd = new("SELECT * FROM deckcards WHERE username = @name", connection);
            cmd.Parameters.AddWithValue("name", username);
            Object response = cmd.ExecuteScalar();
            if (response == null)
            {
                Console.Clear();
                Console.WriteLine("You have no Cards!\n");
                Close();
                Tools.PressAnyKey();
            }
            else
            {
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    Console.Clear();
                    Console.WriteLine("You will enter the Arena with the following Cards:\n");
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
        public Deck GetPlayerDeck(string username)
        {
            Open();
            List<string> tempList = new();
            Deck myDeck = new();
            NpgsqlCommand seachCmd = new("SELECT * FROM deckcards WHERE username = @name", connection);
            seachCmd.Parameters.AddWithValue("name", username);
            using NpgsqlDataReader reader = seachCmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    string temp = reader.GetString(1);
                    tempList.Add(temp);
                }
            }
            Close();
            Open();
            NpgsqlCommand getCardCmd = new("SELECT * FROM card WHERE name = @cardname", connection);
            for (int i = 0; i < tempList.Count; i++)
            {
                getCardCmd.Parameters.Clear();
                getCardCmd.Parameters.AddWithValue("cardname", tempList[i]);
                using NpgsqlDataReader reader2 = getCardCmd.ExecuteReader();
                if (reader2 != null)
                {
                    while (reader2.Read())
                    {
                        if (reader2.IsDBNull(4))
                        {
                            myDeck.AddCard(new SpellCard(reader2.GetString(0), reader2.GetInt32(1), (ElementType)reader2.GetInt32(3)));
                        }
                        else
                        {
                            myDeck.AddCard(new MonsterCard(reader2.GetString(0), reader2.GetInt32(1), (ElementType)reader2.GetInt32(3), (MonsterType)reader2.GetInt32(4)));
                        }
                    }
                }
            }
            Close();
            return myDeck;
        }
        public Deck GetBotDeck()
        {
            Deck myDeck = new();
            Open();
            NpgsqlCommand cmd = new("SELECT * FROM card ORDER BY RANDOM() LIMIT 4;", connection);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    if (reader.IsDBNull(4))
                    {
                        myDeck.AddCard(new SpellCard(reader.GetString(0), reader.GetInt32(1), (ElementType)reader.GetInt32(3)));
                    }
                    else
                    {
                        myDeck.AddCard(new MonsterCard(reader.GetString(0), reader.GetInt32(1), (ElementType)reader.GetInt32(3), (MonsterType)reader.GetInt32(4)));
                    }
                }
            }
            Close();
            return myDeck;
        }
    }
}