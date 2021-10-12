using System;
using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    class User
    {
        private const int StartingCoins = 20;
        private const int PackCost = 5;
        private const int StartingElo = 100;
        List<ICard> Stack = new();
        List<ICard> Deck = new();
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
        private void BuyPackage()
        {
            //add cards to Stack
            this.Coins -= PackCost;
        }
    }
}