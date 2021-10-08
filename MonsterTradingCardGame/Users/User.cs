using System;
using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private bool IsRegistered { get; set; }
        Stack<ICard> Deck = new();
        List<ICard> MyCards = new();
        public User(string myUsername, string myPassword)
        {
            Username = myUsername;
            Password = myPassword;
        }
    }
}