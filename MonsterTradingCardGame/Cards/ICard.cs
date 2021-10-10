using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame
{
    interface ICard
    {
        string Name { get; set; }
        int Damage { get; set; }
    }
}
