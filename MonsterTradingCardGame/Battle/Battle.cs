using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    class Battle
    {
        private readonly List<ICard> Deck1 = new();
        private readonly List<ICard> Deck2 = new();
        public Battle(List<ICard> d1, List<ICard> d2)
        {
            Deck1 = d1;
            Deck2 = d2;
            var rand = new Random();
            Deck1 = Deck1.OrderBy(x => rand.Next()).ToList();
            Deck2 = Deck2.OrderBy(x => rand.Next()).ToList();
        }
    }
}