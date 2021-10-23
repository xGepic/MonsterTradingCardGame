using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame.Cards
{
    class MonsterCard : ICard
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public CardType MyCardtype { get; set; }
        public ElementType MyElementType { get;set;}
        public MonsterType MyMonsterType { get; set; }
        public MonsterCard(string name, int dmg)
        {
            Name = name;
            Damage = dmg;
            MyCardtype = CardType.Monster;
        }
    }
}
