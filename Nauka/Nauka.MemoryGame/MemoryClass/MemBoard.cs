using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Nauka.MemoryGame.MemoryClass
{
    public class MemBoard//: Panel
    {
        public enum Level
        {
            Easy = 16,
            Normal = 24,
            Hard = 36
        };
       
        public List<MemField> Board = new List<MemField>();
        private Level _gameLevel;

        public MemBoard(Level level, Control parent)
        {
            _gameLevel = level;
            for (int i = 0; i < 4 ; i++)
            {
                for (int j = 0; j < (int)level / 4; j++)
                {
                    Board.Add(new MemField(j, i, parent));
                }
            }
            
        }

       

        
    }
}