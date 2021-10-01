using System;

namespace MonsterTradingCardGame.Cards
{
    public abstract class CardBase
    {
        protected string Name { get; set; }
        protected int Damage { get; set; }
        protected ElementType EType { get; set; }
        protected MonsterType MType {get;set;}
        public CardBase(string cardname, int cardDamage, ElementType cardType, MonsterType monsterType)
        {
            Name = cardname;
            Damage = cardDamage;
            EType = cardType;
            MType = monsterType;
        }
    }
}
