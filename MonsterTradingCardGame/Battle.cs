using System;

namespace MonsterTradingCardGame
{
    class Battle
    {
        private readonly ICard Card1;
        private readonly ICard Card2;
        public Battle(ICard card1, ICard card2)
        {
            Card1 = card1;
            Card2 = card2;
        }
    }
}