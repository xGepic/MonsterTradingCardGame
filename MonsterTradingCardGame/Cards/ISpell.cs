using System;

namespace MonsterTradingCardGame
{
    interface ISpell : ICard
    {
        ElementType Etype { get; set; }
    }
}
