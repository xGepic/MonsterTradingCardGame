using System;

namespace MonsterTradingCardGame
{
    interface IMonster : ICard
    {
        protected MonsterType Mtype { get; set; }
        protected ElementType EType { get; set; }
    }
}
