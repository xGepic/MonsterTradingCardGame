using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame
{
    interface ICard
    {
        protected string Name { get; set; }
        protected int Damage { get; set; }
    }
}
