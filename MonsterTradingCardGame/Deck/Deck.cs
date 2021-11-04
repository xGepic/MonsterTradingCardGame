using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    public class Deck : IDeck
    {
        public Dictionary<string, ICard> MyCards;
        private const int maxCardCount = 5;
        public Deck()
        {
            MyCards = new Dictionary<string, ICard>();
        }
        public int AddCard(ICard Card)
        {
            if (MyCards.Count < maxCardCount)
            {
                MyCards.Add(Card.Name, Card);
                return 0;
            }
            else
            {
                return -1;
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
        public int RemoveCard(string name)
        {
            if (MyCards.Remove(name))
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
            int counter = 1;
            foreach (var val in MyCards)
            {
                Console.WriteLine($"{counter}. {val.Key}");
                counter++;
            }
        }
        public int CountCards()
        {
            return MyCards.Count;
        }
        public void ClearCards()
        {
            MyCards.Clear();
        }
    }
}