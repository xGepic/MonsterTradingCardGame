using System;

namespace MonsterTradingCardGame.Cards
{
    public class Card : CardBase, ICard
    {
        public Card(string cardname, int cardDamage, ElementType cardType) : base(cardname, cardDamage, cardType)
        {
            Console.WriteLine("Here");
        }
    }
}
