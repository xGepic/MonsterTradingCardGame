﻿using System;

namespace MonsterTradingCardGame
{
    static class Tools
    {
        public static void PressAnyKey()
        {
            ConsoleKeyInfo k;
            Console.Write("\nPress ENTER to exit...");
            while (true)
            {
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}