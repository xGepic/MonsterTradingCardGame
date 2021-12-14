using System;

namespace MonsterTradingCardGame
{
    class User
    {
        private readonly string Username;
        private readonly string Password;
        public Deck MyDeck;
        public Stack MyStack;
        public int Coins { get; set; }
        public int Elo { get; set; }
        public User(string myUsername, Stack userStack, int eloPoints, int coins)
        {
            Username = myUsername;
            MyStack = userStack;
            Coins = coins;
            Elo = eloPoints;
        }
    }
}