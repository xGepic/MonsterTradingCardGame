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
        public int AddCard(ICard Card)
        {
            if (MyStack.Count < 9)
            {
                MyStack.Add(Card.Name, Card);
                return 0;
            }
            else
            {
                return -1;
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
        public int RemoveCard(string name)
        {
            if (MyStack.Remove(name))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public void PrintCards()
        {
            foreach (var val in MyStack)
            {
                Console.WriteLine($"{val.Key} Found!");
            }
        }
        public int CountCards()
        {
            return MyStack.Count;
        }
        public void ClearCards()
        {
            MyStack.Clear();
        }
    }
}