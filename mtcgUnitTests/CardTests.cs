using NUnit.Framework;
using MonsterTradingCardGame;
using System.Collections.Generic;

namespace mtcgUnitTests
{
    class CardTests
    {
        private readonly string username = "CardTester";
        private readonly string pw = "unit123";
        private readonly int elo = 1200;
        private readonly int coins = 20;
        private readonly string card1 = "FireKnight";
        private readonly string card2 = "WaterWizzard";

        [Test]
        public void TestCountPlayerStack()
        {
            // ARRANGE
            DBConnector cmd = DBConnector.GetInstance();
            List<string> cardlist = new();
            cardlist.Add(card1);
            cardlist.Add(card2);

            // ACT
            cmd.RegisterUser(username, pw, elo, coins);
            cmd.AddCardToStack(username, cardlist);
            var result = cmd.CountPlayerStack(username);

            // ASSERT 
            Assert.AreEqual(result, 2);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            DBConnector cmd = DBConnector.GetInstance();
            cmd.RemoveCardFromStack(card1);
            cmd.RemoveCardFromStack(card2);
            cmd.RemoveUser(username);
        }
    }
}
