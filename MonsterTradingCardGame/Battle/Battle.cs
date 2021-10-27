using System;

namespace MonsterTradingCardGame
{
    class Battle
    {
        public static int DamageCalc(ICard Card1, ICard Card2)
        {
            int DamageFromCard1 = GetCardDamage(Card1, Card2);
            int DamageFromCard2 = GetCardDamage(Card2, Card1);
            Console.WriteLine("##############################\n");
            if ((Card1.MyCardtype == CardType.Monster && Card2.MyCardtype == CardType.Spell) || Card1.MyCardtype == CardType.Spell && Card2.MyCardtype == CardType.Monster)
            {
                Console.WriteLine("Monster vs Spell Fight");
                Console.WriteLine($"{Card1.Name} ({Card1.Damage}) vs {Card2.Name} ({Card2.Damage})\n");
                if (DamageFromCard1 == 2 && DamageFromCard2 == 1)
                {
                    Console.WriteLine("Player 2 Won!");
                    PrintLine();
                    return 2;
                }
                else if (DamageFromCard1 == 1 && DamageFromCard2 == 2)
                {
                    Console.WriteLine("Player 1 Won!");
                    PrintLine();
                    return 1;
                }
                else
                {
                    Console.WriteLine("It is a Draw!");
                    PrintLine();
                    return 3;
                }
            }
            if (Card1.MyCardtype == CardType.Monster && Card2.MyCardtype == CardType.Monster)
            {
                Console.WriteLine("MonsterFight");
                Console.WriteLine($"{Card1.Name} ({Card1.Damage}) vs {Card2.Name} ({Card2.Damage})\n");
                if (DamageFromCard1 == 2 && DamageFromCard2 == 1)
                {
                    Console.WriteLine("Player 2 Won!");
                    PrintLine();
                    return 2;
                }
                else if (DamageFromCard1 == 1 && DamageFromCard2 == 2)
                {
                    Console.WriteLine("Player 1 Won!");
                    PrintLine();
                    return 1;
                }
                else
                {
                    Console.WriteLine("It is a Draw!");
                    PrintLine();
                    return 3;
                }
            }
            if (Card1.MyCardtype == CardType.Spell && Card2.MyCardtype == CardType.Spell)
            {
                Console.WriteLine("SpellFight!");
                Console.WriteLine($"{Card1.Name} ({Card1.Damage}) vs {Card2.Name} ({Card2.Damage})\n");
                if (DamageFromCard1 == 2 && DamageFromCard2 == 1)
                {
                    Console.WriteLine("Player 2 Won!");
                    PrintLine();
                    return 2;
                }
                else if (DamageFromCard1 == 1 && DamageFromCard2 == 2)
                {
                    Console.WriteLine("Player 1 Won!");
                    PrintLine();
                    return 1;
                }
                else
                {
                    Console.WriteLine("It is a Draw!");
                    PrintLine();
                    return 3;
                }
            }
            return -1;
        }
        private static int GetCardDamage(ICard card1, ICard card2)
        {
            if (card1.Damage > card2.Damage)
            {
                return 1;
            }
            if (card1.Damage < card2.Damage)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        private static void PrintLine()
        {
            Console.WriteLine("##############################\n");
        }
    }
}