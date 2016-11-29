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
            Click += Clicker;
        }

        private void Clicker(object sender, EventArgs e)
        {
            var helpField = (MemField) sender;
            if (helpField.Clicked) return;

            
        }

        public void ShowMe(List<MemField> fields)
        {
            fields.ForEach(field => field.Visible = true);
        }

        public void PictureShow(List<MemField> fields , MemBoard memBoard)
        {
            //fields.ForEach(field => field.BackgroundImage = true);
        }

    }
}