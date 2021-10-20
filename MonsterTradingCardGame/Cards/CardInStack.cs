using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    public class CardInStack : IDeck
    {
        Dictionary<string, ICard> MyCardInStack;
        public CardInStack()
        {
            MyCardInStack = new Dictionary<string, ICard>();
        }
        public CardInStack(Dictionary<string, ICard> cards)
        {
            this.MyCardInStack = cards;
        }
        public void AddCard(ICard Card)
        {
            if(MyCardInStack.Count < 4)
            {
                //Add Card
            }
        }
        public ICard GetCard(string name)
        {
            bool myTry = MyCardInStack.TryGetValue(name, out ICard card);
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
            return MyCardInStack.ElementAt(id).Value;
        }
        public void GetCards(out Dictionary<string, ICard> Cards)
        {
            Cards = this.MyCardInStack;
        }
        public void RemoveCard(ICard Card)
        {
            bool myTry = MyCardInStack.TryGetValue(Card.Name, out ICard card);
            if (myTry)
            {
                MyCardInStack.Remove(card.Name);
            }
            else
            {
                return;
            }
        }
    }
}