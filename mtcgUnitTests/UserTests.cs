using NUnit.Framework;
using MonsterTradingCardGame;

namespace mtcgUnitTests
{
    class UserTests
    {
        private readonly string username = "Unit";
        private readonly string pw = "unit123";
        private readonly int elo = 1200;
        private readonly int coins = 20;
        [Test]
        public void TestRegister()
        {
            // ARRANGE
            DBConnector cmd = DBConnector.GetInstance();

            // ACT
            var result = cmd.RegisterUser(username, pw, elo, coins);

            // ASSERT 
            Assert.AreEqual(result, true);
        }
        [TearDown]
        public void Cleanup()
        {
            DBConnector cmd = DBConnector.GetInstance();
            cmd.RemoveUser(username);
        }
    }
}
