using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    public class Deck : IDeck
    {
        public Dictionary<string, ICard> MyCards;
        public Deck()
        {
            MyCards = new Dictionary<string, ICard>();
        }
        public void AddCard(ICard Card)
        {
            if (MyCards.Count < 4)
            {
                MyCards.Add(Card.Name, Card);
            }
            return;
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

        public void RemoveCard(ICard Card)
        {
            if (MyCards.Count < 1)
            {
                return;
            }
            else
            {
                MyCards.Remove(Card.Name);
            }
        }
        public void PrintCards()
        {
            foreach (var val in MyCards)
            {
                Console.WriteLine($"{val.Key} Found!");
            }
        }
    }
}