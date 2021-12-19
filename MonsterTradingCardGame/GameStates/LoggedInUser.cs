using System;

namespace MonsterTradingCardGame
{
    static class LoggedInUser
    {
        public static void LoggedInMenu(string userName)
        {
            while (true)
            {
                UI.PrintUserMenu(userName);
                int input = UI.GetUserMenuInput();

                //to do

                if (input == 1)
                {
                    Console.WriteLine("Play");
                }
                if (input == 2)
                {
                    Console.WriteLine("Buy a Package");
                }
                if (input == 3)
                {
                    Console.WriteLine("Craft your Deck");
                }
                if (input == 4)
                {
                    Console.WriteLine("View the Leaderboard");
                }
                if (input == 5)
                {
                    Console.WriteLine("View your Profile");
                }
                if (input == 6)
                {
                    Console.WriteLine("Trade");
                }
                if (input == 7)
                {
                    Console.Clear();
                    return;
                }
            }
        }
    }
}
