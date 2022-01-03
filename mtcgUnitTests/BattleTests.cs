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

            // ACT 


            // ASSERT 


        }
        [Test]
        public void TestSpellBattle()
        {
            // ARRANGE
            SpellCard Spell1 = new("testCard1", 15, ElementType.Fire);
            SpellCard Spell2 = new("testCard2", 10, ElementType.Water);

            // ACT 


            // ASSERT 


        }
        [Test]
        public void TestMixBattle()
        {
            // ARRANGE
            MonsterCard Monster1 = new("testCard1", 15, ElementType.Fire, MonsterType.Knight);
            SpellCard Spell1 = new("testCard1", 15, ElementType.Fire);

            // ACT 


            // ASSERT 


        }
    }
}