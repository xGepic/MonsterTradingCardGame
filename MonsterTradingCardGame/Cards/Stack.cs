using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    public class Stack : IDeck
    {
        Dictionary<string, ICard> MyStack;
        public Stack()
        {
            MyStack = new Dictionary<string, ICard>();
        }
        public Stack(Dictionary<string, ICard> cards)
        {
            MyStack = cards;
        }
        public void AddCard(ICard Card)
        {
            //Add Card
        }
        public ICard GetCard(string name)
        {
            bool myTry = MyStack.TryGetValue(name, out ICard card);
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
            return MyStack.ElementAt(id).Value;
        }
        public void GetCards(out Dictionary<string, ICard> Cards)
        {
            Cards = this.MyStack;
        }
        public void RemoveCard(ICard Card)
        {
            //Remove Card
        }
    }
}