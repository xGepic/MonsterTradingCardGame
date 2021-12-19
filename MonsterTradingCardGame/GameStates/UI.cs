using System;

namespace MonsterTradingCardGame
{
    static class UI
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Monster Trading Card Game by Stefan Simanek\n\n");
        }
        public static void PrintUserMenu(string userName)
        {
            Console.WriteLine($"Logged in as {userName}\n\n");
            Console.WriteLine("What would you like to do?:");
            Console.WriteLine("1 - PLAY");
            Console.WriteLine("2 - BUY A PACKAGE");
            Console.WriteLine("3 - CRAFT YOUR DECK");
            Console.WriteLine("4 - View the Leaderboard");
            Console.WriteLine("5 - View your Profile");
            Console.WriteLine("6 - Trade");
            Console.WriteLine("7 - LOGOUT");
        }
        public static int GetUserMenuInput()
        {
            int input;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input < 1 || input > 7)
                {
                    throw new ArgumentException("Invalid Input");
                }
                else
                {
                    return input;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n[Error] " + e.Message + "\n\n");
                return 0;
            }
        }
    }
}
