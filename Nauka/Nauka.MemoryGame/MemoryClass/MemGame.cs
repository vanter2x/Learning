using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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

                for (int i = 0; i < level / 2; i++)
                {
                    var x = hList.Count - 1;
                    hList.Where(field => field.Sign == 0).ToList()[numer.Next(0, hList.Count - 1 - i * 2)].Sign = i + 1;
                    hList.Where(field => field.Sign == 0).ToList()[numer.Next(0, hList.Count - 2 - i * 2)].Sign = -(i + 1);
                }
            }
            hList.ForEach(field => field.Text = field.Sign.ToString());
        }

        public async void Clicker(MemField memField, List<MemField> fieldsList)
        {
            if (fieldsList.Count(mm => mm.Clicked) >= 2 || memField.Clicked) return; // 2 clicked
            if (!fieldsList.Any(mm => mm.Clicked)) // if nothing is clicked...
            {
                memField.Clicked = true;
                memField.ShowPicture(memField);
                return;
            }

            //if one of blocks is clicked...
            memField.ShowPicture(memField);
            memField.Clicked = true;
            await Task.Delay(1000);
            
            var helpInt = 0;
            fieldsList.Where(field => field.Clicked).ToList().ForEach(mm => helpInt += mm.Sign); // chceck Sign
            fieldsList.FindAll(ff=>ff.Clicked).ForEach(mm=>mm.Visible = helpInt == 0 ? false : true); // set visible if sign is the same or different
            //change back a picture and clicked..
            fieldsList.FindAll(ff => ff.Clicked).ForEach(mm => mm.PictureBack());
            fieldsList.ForEach(ff=>ff.Clicked = false);

        }

       

        


    }
}