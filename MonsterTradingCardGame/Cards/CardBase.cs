using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame.Cards
{
    public abstract class CardBase : IMonster, ISpell
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public MonsterType Mtype { get; set; }
        public ElementType Etype { get; set; }
        public CardBase(string name, int dmg, MonsterType typeM, ElementType typeE)
        {
            this.Name = name;
            this.Damage = dmg;
            this.Mtype = typeM;
            this.Etype = typeE;
        }
    }
}