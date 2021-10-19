using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    public interface IDeck
    {
        public ICard GetCard(string name);
        public ICard GetCard(int id);
        public void GetCards(out Dictionary<string, ICard> Cards);
        public void AddCard(ICard Card);
        public void RemoveCard(ICard Card);
    }
}