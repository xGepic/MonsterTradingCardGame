using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame.Cards
{
    enum elementType
    {
        normal,
        fire,
        water
    }
    abstract class CardBase
    {
        private int Damage { get; set; }
        private elementType Type { get; set; }
        public CardBase()
        {
            //CardBase
        }
    }
}
