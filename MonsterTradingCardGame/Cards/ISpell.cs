using System;

namespace MonsterTradingCardGame.Cards
{
    interface ISpell : ICard
    {
        protected ElementType Etype { get; set; }
    }
}
