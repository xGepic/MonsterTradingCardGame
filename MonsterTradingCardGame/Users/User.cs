using System;
using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    class User
    {
        private const int StartingCoins = 20;
        private const int PackCost = 5;
        private const int StartingElo = 100;

        //Deck and Stack

        private int Wins { get; set; }
        private int Loses { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private int Coins { get; set; }
        public Guid Token { get; set; }
        private int Elo { get; set; }
        public User(string myUsername, string myPassword)
        {
            Username = myUsername;
            Password = myPassword;
            Coins = StartingCoins;
            Elo = StartingElo;
        }
    }
}