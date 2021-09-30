using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame
{
    class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
        Stack<ICard> Deck = new Stack<ICard>();
    }
}