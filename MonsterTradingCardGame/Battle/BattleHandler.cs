using System;
using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    class BattleHandler
    {
        private readonly User Player1;
        private readonly User Player2;
        private readonly List<ICard> BattleDeck1 = new();
        private readonly List<ICard> BattleDeck2 = new();
        private int roundCounter = 1;
        private const int player1Won = 1;
        private const int player2Won = 2;
        private const int maxRoundCounter = 100;
        private const int kValue = 30;
        public BattleHandler(User User1, User User2)
        {
            Player1 = User1;
            Player2 = User2;
        }
        public void StartBattle()
        {
            Random rand = new();
            int Player1DeckCount = Player1.MyDeck.CountCards();
            int Player2DeckCount = Player2.MyDeck.CountCards();
            for (int i = 0; i < Player1DeckCount; i++)
            {
                BattleDeck1.Add(Player1.MyDeck.GetCard(i));
            }
            Player1.MyDeck.ClearCards();
            for (int i = 0; i < Player2DeckCount; i++)
            {
                BattleDeck2.Add(Player2.MyDeck.GetCard(i));
            }
            Player2.MyDeck.ClearCards();
            while (true)
            {
                if (BattleDeck1.Count == 0 || BattleDeck2.Count == 0)
                {
                    break;
                }
                Console.WriteLine($"          Round {roundCounter}");
                int p1Card = rand.Next(0, BattleDeck1.Count);
                int p2Card = rand.Next(0, BattleDeck2.Count);
                int whoWon = Battle.DamageCalc(BattleDeck1[p1Card], BattleDeck2[p2Card]);
                if (whoWon == player1Won)
                {
                    BattleDeck1.Add(BattleDeck2[p2Card]);
                    BattleDeck2.RemoveAt(p2Card);
                }
                if (whoWon == player2Won)
                {
                    BattleDeck2.Add(BattleDeck1[p1Card]);
                    BattleDeck1.RemoveAt(p1Card);
                }
                if (roundCounter == maxRoundCounter)
                {
                    Console.WriteLine("Round Limit exceeded!");
                    return;
                }
                roundCounter++;
            }
            if (BattleDeck1.Count == 0)
            {
                Console.WriteLine("Player 2 is the Winner!");
                for (int i = 0; i < BattleDeck2.Count; i++)
                {
                    Player2.MyStack.AddCard(BattleDeck2[i]);
                }
                float probablilityPlayer1 = Probability(Player1.Elo, Player2.Elo);
                float probablilityPlayer2 = Probability(Player2.Elo, Player1.Elo);
                Player1.Elo += (int)Math.Round(kValue * (0 - probablilityPlayer1));
                Player2.Elo += (int)Math.Round(kValue * (1 - probablilityPlayer2));
            }
            if (BattleDeck2.Count == 0)
            {
                Console.WriteLine("Player 1 is the Winner!");
                for (int i = 0; i < BattleDeck1.Count; i++)
                {
                    Player1.MyStack.AddCard(BattleDeck1[i]);
                }
                float probablilityPlayer1 = Probability(Player1.Elo, Player2.Elo);
                float probablilityPlayer2 = Probability(Player2.Elo, Player1.Elo);
                Player1.Elo += (int)Math.Round(kValue * (1 - probablilityPlayer1));
                Player2.Elo += (int)Math.Round(kValue * (0 - probablilityPlayer2));
            }
        }
        public static float Probability(float rating1, float rating2)
        {
            //This returns the Winning Probability of rating2
            return 1.0f * 1.0f / (1 + 1.0f * (float)(Math.Pow(10, 1.0f * (rating1 - rating2) / 400)));
        }
    }
}