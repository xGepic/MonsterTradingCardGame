using System;

namespace MonsterTradingCardGame
{
    static class Menu
    {
        public static void PrintStartingMenu()
        {
            Console.WriteLine("Monster Trading Card Game by Stefan Simanek");
        }
        public static User GetUser1()
        {
            return new User("Stefan", "123");
        }
        public static User GetUser2()
        {
            return new User("Markus", "69");
        }
    }
}