using System;
using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
        Stack<ICard> Deck = new Stack<ICard>();
    }
}