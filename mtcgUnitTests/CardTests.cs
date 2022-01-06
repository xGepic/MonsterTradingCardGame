using NUnit.Framework;
using MonsterTradingCardGame;

namespace mtcgUnitTests
{
    class CardTests
    {
        private readonly string username = "CardTester";
        private readonly string pw = "unit123";
        private readonly int elo = 1200;
        private readonly int coins = 20;
        private readonly int newElo = 1000;
        [Test]
        public void TestUpdateElo()
        {
            // ARRANGE
            DBConnector cmd = DBConnector.GetInstance();

            // ACT
            cmd.RegisterUser(username, pw, elo, coins);
            cmd.UpdatePlayerElo(username, newElo);
            var result = cmd.GetPlayerElo(username);

            // ASSERT 
            Assert.AreEqual(result, newElo);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            DBConnector cmd = DBConnector.GetInstance();
            cmd.RemoveUser(username);
        }
    }
}
