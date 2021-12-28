﻿using System;

namespace MonsterTradingCardGame
{
    class Shop
    {
        public Shop()
        {

        }
        public static void PrintShopMenu()
        {
            Console.WriteLine("1 - Buy a Card Pack");
            Console.WriteLine("2 - Go Back");
            Console.Write("\nInput: ");
        }
        public static int GetShopInput()
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
        public void ShopMenu(string username)
        {
            while (true)
            {
                PrintShopMenu();
                int shopInput = GetShopInput();
                if (shopInput == 1)
                {
                    DBConnector myDB = DBConnector.GetInstance();
                    if (myDB.GetPlayerCoins(username) > 5)
                    {
                        myDB.DecreaseCoinsofPlayer(username);
                        myDB.BuyACardPack();
                        Tools.PressAnyKey();
                    }
                    else
                    {
                        Console.WriteLine("[ERROR] You dont have enough Coins to buy a Card Pack!");
                    }
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