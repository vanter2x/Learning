using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Nauka.MemoryGame.MemoryClass;

namespace Nauka.MemoryGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }

        #endregion

        protected void SetGameSize(MemBoard memBoard, MemField memField)
        {
            
            var level = (int)memBoard.GetType().GetField("_gameLevel", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(memBoard);
            var size = (Size) memField.GetType().GetField("_fSize", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(memField);
            
              Height = 4*size.Height + 50;
              Width = (level/4)*size.Width + 17;

        }
    }
}

