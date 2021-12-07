using System;

namespace MonsterTradingCardGame
{
    static class Game
    {
        public static void GameLoop()
        {
            while (true)
            {
                Menu.PrintWelcomeMessage();
                int getMenu = Menu.PrintStartingMenu();
                if (getMenu == 1)
                {
                    string getLogIn = Menu.PrintLogIn();
                    Menu.LoggedInUser(getLogIn);
                    return;
                }
                else if(getMenu == 2)
                {
                    Menu.PrintSignUp();
                }
                else if (getMenu == 3)
                {
                    Console.WriteLine("GoodBye!");
                    return;
                }
            }
        }
    }
}
