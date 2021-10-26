using System;

namespace MonsterTradingCardGame
{
    class User
    {
        private const int StartingCoins = 20;
        private const int StartingElo = 100;
        public Deck MyDeck = new();
        public Stack MyStack = new();
        private string Username { get; }
        private string Password { get; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Coins { get; set; }
        public int Elo { get; set; }
        public string Token { get; set; }
        public User(string myUsername, string myPassword)
        {
            Username = myUsername;
            Password = myPassword;
            Wins = 0;
            Loses = 0;
            Coins = StartingCoins;
            Elo = StartingElo;
            Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}