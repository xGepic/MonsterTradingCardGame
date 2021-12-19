using System;
using System.Threading;

namespace MonsterTradingCardGame
{
    static class Menu
    {
        public static int PrintStartingMenu()
        {
            int i;
            Console.WriteLine("What would you like to do?:");
            Console.WriteLine("1 - LOGIN");
            Console.WriteLine("2 - SIGNUP");
            Console.WriteLine("3 - QUIT");
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
                if (i != 1 && i != 2 && i != 3)
                {
                    throw new ArgumentException("Invalid Input");
                }
                else
                {
                    return i;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n[Error] " + e.Message + "\n\n");
                return 0;
            }
        }
        public static void PrintLogIn()
        {
            string username;
            string pwd;
            Console.Clear();
            Console.WriteLine("--| LOGIN |--\n");
            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Password: ");
            pwd = User.GetPassword();

            DBConnector myDB = DBConnector.GetInstance();
            if (myDB.LogInUser(username, pwd))
            {
                Console.WriteLine("\n\nSuccess! - You will be taken to the Menu in 3 Seconds!");
                Thread.Sleep(3000);
                Console.Clear();
                LoggedInUser(username);
            }
            else
            {
                Console.WriteLine("\n[Error] Invalid Credentials!\n");
                return;
            }
        }
        public static void PrintSignUp()
        {
            string username;
            string pwd1;
            string pwd2;
            Console.Clear();
            Console.WriteLine("--| SIGN UP |--\n");
            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            do
            {
                Console.WriteLine("Password: ");
                pwd1 = Console.ReadLine();
                Console.WriteLine("Please repeat the Password: ");
                pwd2 = Console.ReadLine();
                if (pwd1 != pwd2)
                {
                    Console.WriteLine("\n[ERROR] Passwords are not equal!\n\n");
                }
            } while (pwd1 != pwd2);

            DBConnector myDB = DBConnector.GetInstance();
            if (myDB.RegisterUser(username, pwd1, 1000, 20))
            {
                Console.WriteLine("\nSignup Successful! - You will be taken to the Menu in 3 Seconds!");
                Thread.Sleep(3000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nSignup Failed!");
            }
        }
        public static int GetUserMenuInput()
        {
            int i;
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
                if (i < 1 || i > 7)
                {
                    throw new ArgumentException("Invalid Input");
                }
                else
                {
                    return i;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n[Error] " + e.Message + "\n\n");
                return 0;
            }
        }
        public static void LoggedInUser(string userName)
        {
            while (true)
            {
                UI.PrintUserMenu(userName);
                int i = GetUserMenuInput();

                //to do

                if (i == 1)
                {
                    Console.WriteLine("Play");
                }
                if (i == 2)
                {
                    Console.WriteLine("Buy a Package");
                }
                if (i == 3)
                {
                    Console.WriteLine("Craft your Deck");
                }
                if (i == 4)
                {
                    Console.WriteLine("View the Leaderboard");
                }
                if (i == 5)
                {
                    Console.WriteLine("View your Profile");
                }
                if (i == 6)
                {
                    Console.WriteLine("Trade");
                }
                if (i == 7)
                {
                    Console.Clear();
                    return;
                }
            }
        }
    }
}