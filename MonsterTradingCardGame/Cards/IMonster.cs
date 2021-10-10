using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame.Cards
{
    interface IMonster : ICard
    {
        MonsterType Mtype { get; set; }
    }
}
