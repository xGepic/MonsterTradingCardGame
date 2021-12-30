﻿using System;
using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    static class LoggedInUser
    {
        public static void LoggedInMenu(string userName)
        {
            Shop myShop = new();
            while (true)
            {
                UI.PrintUserMenu(userName);
                int input = UI.GetUserMenuInput();

                if (input == 1)
                {
                    Console.Clear();
                    Console.WriteLine("WELCOME TO THE ARENA\n");
                    BattleMenu.GetBattleMenu(userName);
                }
                if (input == 2)
                {
                    Console.Clear();
                    Console.WriteLine("WELCOME TO THE SHOP\n");
                    myShop.ShopMenu(userName);
                    Console.Clear();
                }
                if (input == 3)
                {
                    Console.Clear();
                    CraftYourDeck.DeckCraftingMenu(userName);
                    Console.Clear();
                }
                if (input == 4)
                {
                    Console.Clear();
                    Console.WriteLine("LEADERBOARD\n");
                    DBConnector myDB = DBConnector.GetInstance();
                    myDB.GetLeaderboard();
                    Tools.PressAnyKey();
                    Console.Clear();
                }
                if (input == 5)
                {
                    Console.Clear();
                    Console.WriteLine("MY PROFILE\n");
                    DBConnector myDB = DBConnector.GetInstance();
                    myDB.GetProfile(userName);
                    Tools.PressAnyKey();
                    Console.Clear();
                }
                if (input == 6)
                {
                    //to do
                    Console.WriteLine("Trade");
                }
                if (input == 7)
                {
                    Console.Clear();
                    return;
                }
                if (input == 8)
                {
                    Console.Clear();
                    Console.WriteLine("GoodBye!");
                    Environment.Exit(0);
                }
            }
        }
    }
}