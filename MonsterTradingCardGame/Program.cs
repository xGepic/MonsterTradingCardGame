namespace MonsterTradingCardGame
{
    class Program
    {
        static void Main()
        {
            Menu.PrintStartingMenu();
            User Player1 = Menu.GetUser1();
            User Player2 = Menu.GetUser2();

            Player1.MyDeck.AddCard(Menu.GetRngCard(1));
            Player1.MyDeck.AddCard(Menu.GetRngCard(2));
            Player1.MyDeck.AddCard(Menu.GetRngCard(3));
            Player1.MyDeck.AddCard(Menu.GetRngCard(4));
            Player1.MyDeck.AddCard(Menu.GetRngCard(5));

            Player2.MyDeck.AddCard(Menu.GetRngCard2(1));
            Player2.MyDeck.AddCard(Menu.GetRngCard2(2));
            Player2.MyDeck.AddCard(Menu.GetRngCard2(3));
            Player2.MyDeck.AddCard(Menu.GetRngCard2(4));
            Player2.MyDeck.AddCard(Menu.GetRngCard2(5));

            BattleHandler MyBattle = new(Player1, Player2);
            MyBattle.StartBattle();
        }
    }
}