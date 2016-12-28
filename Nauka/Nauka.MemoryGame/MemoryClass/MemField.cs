using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nauka.MemoryGame.MemoryClass
{
    public sealed class MemField: Button
    {
        private readonly Size _fSize = new Size(60,70);
        //public FSi
        public int Sign = 0;
        public bool Clicked = false;

        public MemField(int x, int y, Control parent)
        {
            
            FlatAppearance.BorderSize = 0;
            Size = _fSize;
            Parent = parent;
            Top = y*Height+25;
            Left = x*Width;
            Text = "";
            BackgroundImage = null;
            FlatStyle = FlatStyle.Flat;
            BackgroundImageLayout = ImageLayout.Stretch;
            PreShowMe(this);
        }

        

        public void ShowMe(List<MemField> fields)
        {
            fields.ForEach(PreShowMe);
        }

        private void PreShowMe(MemField field)
        {
            
            field.Visible = true;
            field.BackgroundImage = Image.FromFile("../../MemoryImage/20.png");
        }

        public void ShowPicture(MemField memField)
        {
            memField.BackgroundImage = Image.FromFile("../../MemoryImage/" + (memField.Sign > 0 ? memField.Sign : memField.Sign * -1) + ".png");
        }

        public void PictureBack()
        {
            BackgroundImage = Image.FromFile("../../MemoryImage/20.png");
        }

    }
}