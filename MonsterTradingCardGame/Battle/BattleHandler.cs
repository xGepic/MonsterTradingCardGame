using System;

namespace MonsterTradingCardGame
{
    class BattleHandler
    {
        private readonly User Player1;
        private readonly User Player2;
        public BattleHandler(User User1, User User2)
        {
            Player1 = User1;
            Player2 = User2;
        }
        public void StartBattle()
        {
            Random rand = new();
            Console.WriteLine("          New Round!");

            int Player1DeckCount = Player1.MyDeck.CountCards();
            int Player2DeckCount = Player2.MyDeck.CountCards();

            while (Player1DeckCount > 0 && Player2DeckCount > 0)
            {
                int rCard = rand.Next(0, Player1DeckCount);
                Battle.DamageCalc(Player1.MyDeck.GetCard(rCard), Player2.MyDeck.GetCard(rCard));
            }
        }
    }
}