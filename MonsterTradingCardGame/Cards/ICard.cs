using System;

namespace MonsterTradingCardGame
{
    public interface ICard
    {
        string Name { get; set; }
        int Damage { get; set; }
    }
}
