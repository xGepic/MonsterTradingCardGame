using System.Collections.Generic;

namespace MonsterTradingCardGame
{
    public interface IDeck
    {
        public ICard GetCard(string name);
        public ICard GetCard(int id);
        public int AddCard(ICard Card);
        public int RemoveCard(string name);
        public void PrintCards();
        public int CountCards();
    }
}