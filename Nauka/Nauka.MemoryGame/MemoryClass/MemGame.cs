using System;
using System.Linq;
using System.Reflection;

namespace Nauka.MemoryGame.MemoryClass
{
    public class MemGame
    {

        public void ShufleFields(MemBoard memBoard)
        {
            Random numer = new Random(new DateTime().Millisecond);
            var hList = memBoard.Board;
            var info = memBoard.GetType().GetField("_gameLevel", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(memBoard);
            if (info != null)
            {
                var level = (int)info;

                for (int i = 0; i < level/2; i++)
                {
                    var x = hList.Count - 1;
                    hList.Where(field => field.Sign == 0).ToList()[numer.Next(0, hList.Count-1 - i * 2)].Sign = i + 1;
                    hList.Where(field => field.Sign == 0).ToList()[numer.Next(0, hList.Count-2 - i * 2)].Sign = -(i + 1);
                }
            }
            hList.ForEach(field => field.Text = field.Sign.ToString());
        }


    }
}