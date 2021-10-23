using System;

namespace MonsterTradingCardGame
{
    class Program
    {
        static void Main()
        {
            Menu.PrintStartingMenu();

            User User1 = Menu.GetUser1();
            User User2 = Menu.GetUser2();

            BattleHandler Battle = new(User1, User2);
            Battle.StartBattle();


            Console.WriteLine("Task Finished Succesfully!");
        }
    }
}