using System;

namespace MonsterTradingCardGame
{
    class Shop
    {
        public Shop()
        {

        }
        public void PrintShopMenu()
        {
            Console.WriteLine("1 - Buy a Card Pack");
            Console.WriteLine("2 - Go Back");
            Console.Write("\nInput: ");
        }
        public int GetShopInput()
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
        public void ShopMenu()
        {
            while (true)
            {
                PrintShopMenu();
                int shopInput = GetShopInput();
                if (shopInput == 1)
                {

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