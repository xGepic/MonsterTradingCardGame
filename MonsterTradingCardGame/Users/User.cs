using System;
using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private int Money { get; set; }
        private Guid Token { get; set; }
        List<ICard> Deck = new();
        List<ICard> MyCards = new();
        public User(string myUsername, string myPassword)
        {
            Username = myUsername;
            Password = myPassword;
        }
    }
}