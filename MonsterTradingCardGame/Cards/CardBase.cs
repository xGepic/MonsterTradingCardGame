using System;

namespace MonsterTradingCardGame.Cards
{
    public abstract class CardBase
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public ElementType Type { get; set; }
        public CardBase(string cardname, int cardDamage, ElementType cardType)
        {
            Name = cardname;
            Damage = cardDamage;
            Type = cardType;
        }
    }
}
