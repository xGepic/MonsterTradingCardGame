using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame.Cards
{
    class Spell : ICard
    {
        string ICard.Name { get; set; }
        int ICard.Damage { get; set; }
        ElementType ICard.EType { get; set; }
        MonsterType ICard.MType { get; set; }
    }
}
