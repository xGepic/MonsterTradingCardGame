using System;
using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    class User
    {
        private const int StartingCoins = 20;
        private const int StartingElo = 100;
        private string Username { get; set; }
        private string Password { get; set; }
        public Deck MyDeck = new();
        public Stack MyStack = new();
        public int Wins { get; set; }
        public int Loses { get; set; }

        public int Coins { get; set; }
        public Guid Token { get; set; }
        public int Elo { get; set; }
        public User(string myUsername, string myPassword)
        {
            Username = myUsername;
            Password = myPassword;
            Coins = StartingCoins;
            Elo = StartingElo;
        }
    }
}