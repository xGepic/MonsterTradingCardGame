using System;

namespace MonsterTradingCardGame.Cards
{
    public class Card : CardBase, ICard
    {
        public Card(string cardname, int cardDamage, ElementType cardType, MonsterType monsterType) : base(cardname, cardDamage, cardType, monsterType)
        {
            //Card
        }
    }
}
