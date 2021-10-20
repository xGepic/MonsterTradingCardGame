using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    public class Deck : IDeck
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
        public void AddCard(ICard Card)
        {
            if (MyCards.Count < 4)
            {
                //Add Card
            }
        }
        public ICard GetCard(string name)
        {
            bool myTry = MyCards.TryGetValue(name, out ICard card);
            if (myTry)
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
        public void RemoveCard(ICard Card)
        {
            bool myTry = MyCards.TryGetValue(Card.Name, out ICard card);
            if (myTry)
            {
                MyCards.Remove(card.Name);
            }
            else
            {
                return;
            }
        }
    }
}