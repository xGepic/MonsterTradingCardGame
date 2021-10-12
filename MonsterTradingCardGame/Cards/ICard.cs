using System;

namespace MonsterTradingCardGame
{
    interface ICard
    {
        string Name { get; set; }
        int Damage { get; set; }
    }
}
