using System;

namespace MonsterTradingCardGame.Cards
{
    interface IMonster : ICard
    {
        protected MonsterType Mtype { get; set; }
        protected ElementType EType { get; set; }
    }
}
