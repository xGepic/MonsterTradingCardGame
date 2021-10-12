using System;

namespace MonsterTradingCardGame
{
    interface ICard
    {
        protected string Name { get; set; }
        protected int Damage { get; set; }
    }
}
