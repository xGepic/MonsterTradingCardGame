using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    public class Deck
    {
        Dictionary<string, ICard> MyCards;
        public Deck()
        {
            MyCards = new Dictionary<string, ICard>();
        }
        public Deck(Dictionary<string, ICard> cards)
        {
            this.MyCards = cards;
        }
        public ICard GetCard(string name)
        {
            bool boo = MyCards.TryGetValue(name, out ICard card);
            if (boo)
            {
                return card;
            }
            else
            {
                return null;
            }
        }
        public ICard GetCard(int id)
        {
            return MyCards.ElementAt(id).Value;
        }
        public void GetCards(out Dictionary<string, ICard> Cards)
        {
            Cards = this.MyCards;
        }
        public int AddCard(ICard Card)
        {
            //Add Card
            return 0;
        }
    }
}