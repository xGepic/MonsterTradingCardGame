using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    public class Stack : IDeck
    {
        public Dictionary<string, ICard> MyStack;
        public Stack()
        {
            MyStack = new Dictionary<string, ICard>();
        }
        public void AddCard(ICard Card)
        {
            if(MyStack.Count < 4)
            {
                //Add Card
            }
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
        public void RemoveCard(ICard Card)
        {
            //Remove Card
        }
    }
}