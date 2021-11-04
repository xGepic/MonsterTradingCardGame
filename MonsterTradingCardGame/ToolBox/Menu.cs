using System;

namespace MonsterTradingCardGame
{
    static class Menu
    {
        public static void PrintStartingMenu()
        {
            Console.WriteLine("Monster Trading Card Game by Stefan Simanek\n\n");
        }



        //provisional Methods
        public static User GetUser1()
        {
            return new User("Stefan", "123");
        }
        public static User GetUser2()
        {
            return new User("Markus", "69");
        }
        public static ICard GetRngCard(int i)
        {
            if (i == 1)
            {
                return new MonsterCard("WaterGoblin", 10, ElementType.Water, MonsterType.Goblin);
            }
            if (i == 2)
            {
                return new SpellCard("FireSpell", 10, ElementType.Fire);
            }
            if (i == 3)
            {
                return new MonsterCard("FireOrk", 15, ElementType.Fire, MonsterType.Ork);
            }
            if (i == 4)
            {
                return new SpellCard("WaterSpell", 20, ElementType.Water);
            }
            else
            {
                return new SpellCard("GrassSpell", 10, ElementType.Grass);
            }
        }
        public static ICard GetRngCard2(int j)
        {
            if (j == 1)
            {
                return new MonsterCard("FireKnight", 15, ElementType.Fire, MonsterType.Knight);
            }
            if (j == 2)
            {
                return new MonsterCard("WaterWizzard", 10, ElementType.Water, MonsterType.Wizzard);
            }
            if (j == 3)
            {
                return new MonsterCard("GrassDragon", 20, ElementType.Grass, MonsterType.Dragon);
            }
            if (j == 4)
            {
                return new MonsterCard("The Kraken", 25, ElementType.Water, MonsterType.Kraken);
            }
            else
            {
                return new MonsterCard("WaterElf", 20, ElementType.Water,MonsterType.Elf);
            }
        }
        //provisional Methods
    }
}