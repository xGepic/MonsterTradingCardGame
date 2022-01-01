using System;


namespace MonsterTradingCardGame
{
    static class TradeMenu
    {
        public static void PrintTradeMenu()
        {
            Console.WriteLine("TRADE MENU");
            Console.WriteLine("1 - Trade Cards");
            Console.WriteLine("2 - Go Back");
            Console.Write("\nInput: ");
        }
        public static int GetTradeInput()
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
        public static void GetTradeMenu(string username)
        {
            while (true)
            {
                PrintTradeMenu();
                int tradeInput = GetTradeInput();
                if (tradeInput == 1)
                {
                    //to do
                }
                if (tradeInput == 2)
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
