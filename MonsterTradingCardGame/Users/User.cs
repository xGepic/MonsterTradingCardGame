﻿using System;
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