using NUnit.Framework;
using MonsterTradingCardGame;

namespace mtcgUnitTests
{
    public class Tests
    {
        [Test]
        public void TestMonsterBattle()
        {
            // ARRANGE
            MonsterCard Monster1 = new("testCard1", 15, ElementType.Fire, MonsterType.Knight);
            MonsterCard Monster2 = new("testCard2", 10, ElementType.Water, MonsterType.Goblin);
        }
    }
}