using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterTradingCardGame
{
    class BattleHandler
    {
        private readonly User Player1;
        private readonly User Player2;
        private List<ICard> Deck1;
        private List<ICard> Deck2;
        public BattleHandler(User User1, User User2)
        {
            Player1 = User1;
            Player2 = User2;
            Deck1 = new();
            Deck2 = new();
        }
        public void StartBattle()
        {
            Deck1.Add(Player1.MyDeck.GetCard(0));
            Deck1.Add(Player1.MyDeck.GetCard(1));
            Deck1.Add(Player1.MyDeck.GetCard(2));
            Deck1.Add(Player1.MyDeck.GetCard(3));
            Deck2.Add(Player2.MyDeck.GetCard(0));
            Deck2.Add(Player2.MyDeck.GetCard(1));
            Deck2.Add(Player2.MyDeck.GetCard(2));
            Deck2.Add(Player2.MyDeck.GetCard(3));

            Deck1 = Shuffle(Deck1);
            Deck2 = Shuffle(Deck2);

            while (true)
            {
                //Combat
            }
        }
        private List<ICard> Shuffle(List<ICard> Deck)
        {
            Random rand = new();
            return Deck.OrderBy(x => rand.Next()).ToList();
        }
    }
}