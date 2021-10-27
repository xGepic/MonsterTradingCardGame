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
                Console.WriteLine($"{Card1.Name} vs {Card2.Name}\n");
                Console.WriteLine($"{Card1.Damage} vs {Card2.Damage}\n");
                Console.WriteLine("##############################\n");
                if (DamageFromCard1 < DamageFromCard2)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            if (Card1.MyCardtype == CardType.Monster && Card2.MyCardtype == CardType.Monster)
            {
                Console.WriteLine($"{Card1.Name} vs {Card2.Name}\n");
                Console.WriteLine($"{Card1.Damage} vs {Card2.Damage}\n");
                Console.WriteLine("##############################\n");
                if (DamageFromCard1 < DamageFromCard2)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            if (Card1.MyCardtype == CardType.Spell && Card2.MyCardtype == CardType.Spell)
            {
                Console.WriteLine($"{Card1.Name} vs {Card2.Name}\n");
                Console.WriteLine($"{Card1.Damage} vs {Card2.Damage}\n");
                Console.WriteLine("##############################\n");
                if (DamageFromCard1 < DamageFromCard2)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            return -1;
        }
        private static int GetCardDamage(ICard card1, ICard card2)
        {
            return 1;
        }
    }
}