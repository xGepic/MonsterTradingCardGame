using System;

namespace MonsterTradingCardGame
{
    static class BattleMenu
    {
        public static void PrintBattleMenu()
        {
            Console.WriteLine("1 - Battle against the Computer");
            Console.WriteLine("2 - Go Back");
            Console.Write("\nInput: ");
        }
        public static int GetBattleMenuInput()
        {
            int input;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input != 1 && input != 2)
                {
                    throw new ArgumentException("Invalid Input!");
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
        public static void GetBattleMenu(string username)
        {
            while (true)
            {
                PrintBattleMenu();
                int shopInput = GetBattleMenuInput();
                if (shopInput == 1)
                {
                    DBConnector myDB = DBConnector.GetInstance();
                    myDB.PrintPlayerDeck(username);
                }
                if (shopInput == 2)
                {
                    Console.Clear();
                    break;
                }

            }
        }
    }
}