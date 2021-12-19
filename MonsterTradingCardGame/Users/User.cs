using System;

namespace MonsterTradingCardGame
{
    class User
    {
        private readonly string Username;
        public Deck MyDeck = new();
        public Stack MyStack;
        public int Coins { get; set; }
        public int Elo { get; set; }
        public User(string myUsername, Stack userStack, int eloPoints, int coins)
        {
            Username = myUsername;
            MyStack = userStack;
            Coins = coins;
            Elo = eloPoints;
        }
        public static String GetPassword()
        {
            string pwd = "";
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd = pwd.Remove(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000')
                {
                    pwd += (i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
    }
}