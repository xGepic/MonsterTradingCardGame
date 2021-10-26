using System;

namespace MonsterTradingCardGame
{
    class Battle
    {
        public Battle()
        {

        }
        public static ICard DamageCalc(ICard Card1, ICard Card2)
        {
            Console.WriteLine("##############################\n");
            if ((Card1.MyCardtype == CardType.Monster && Card2.MyCardtype == CardType.Spell) || Card1.MyCardtype == CardType.Spell && Card2.MyCardtype == CardType.Monster)
            {
                Console.WriteLine($"{Card1.Name} vs {Card2.Name}\n");
                Console.WriteLine("##############################\n");
            }
            if (Card1.MyCardtype == CardType.Monster && Card2.MyCardtype == CardType.Monster)
            {
                Console.WriteLine($"{Card1.Name} vs {Card2.Name}\n");
                Console.WriteLine("##############################\n");
            }
            if (Card1.MyCardtype == CardType.Spell && Card2.MyCardtype == CardType.Spell)
            {
                Console.WriteLine($"{Card1.Name} vs {Card2.Name}\n");
                Console.WriteLine("##############################\n");
            }
            return null;
        }
    }
}