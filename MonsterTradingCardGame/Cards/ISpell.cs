using System;

namespace MonsterTradingCardGame.Cards
{
    interface ISpell : ICard
    {
        ElementType Etype { get; set; }
    }
}
