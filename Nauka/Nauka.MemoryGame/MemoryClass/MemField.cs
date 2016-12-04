using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nauka.MemoryGame.MemoryClass
{
    public sealed class MemField: Button
    {
        private Size _fSize = new Size(60,70);
        //public FSi
        public int Sign = 0;
        public bool Clicked = false;

        public MemField(int x, int y, Control parent)
        {
            Size = _fSize;
            Parent = parent;
            Top = y*Height;
            Left = x*Width;
            Text = "";
            BackgroundImage = null;
            FlatStyle = FlatStyle.Popup;
            BackgroundImageLayout = ImageLayout.Stretch;

        }

        

        public void ShowMe(List<MemField> fields)
        {
            fields.ForEach(field => field.Visible = true);
        }

        public void ShowPicture(MemField memField)
        {
            memField.BackgroundImage = Image.FromFile("../../MemoryImage/" + (memField.Sign > 0 ? memField.Sign : memField.Sign * -1) + ".png");
        }

        public void PictureBack()
        {
            BackgroundImage = null;
        }

    }
}