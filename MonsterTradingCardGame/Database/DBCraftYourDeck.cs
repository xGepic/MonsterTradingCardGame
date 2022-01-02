using System;
using System.Collections.Generic;
using Npgsql;

namespace MonsterTradingCardGame
{
    public partial class DBConnector
    {
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
    }
}
