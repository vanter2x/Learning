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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTime = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuLevel,
            this.mnuTime});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuStart
            // 
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(43, 20);
            this.mnuStart.Text = "Start";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuLevel
            // 
            this.mnuLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEasy,
            this.mnuNormal,
            this.mnuHard});
            this.mnuLevel.Name = "mnuLevel";
            this.mnuLevel.Size = new System.Drawing.Size(59, 20);
            this.mnuLevel.Text = "Poziom";
            // 
            // mnuEasy
            // 
            this.mnuEasy.Checked = true;
            this.mnuEasy.CheckOnClick = true;
            this.mnuEasy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuEasy.Name = "mnuEasy";
            this.mnuEasy.Size = new System.Drawing.Size(152, 22);
            this.mnuEasy.Tag = "16";
            this.mnuEasy.Text = "Łatwy";
            this.mnuEasy.Click += new System.EventHandler(this.mnuLevelChange_Click);
            // 
            // mnuNormal
            // 
            this.mnuNormal.CheckOnClick = true;
            this.mnuNormal.Name = "mnuNormal";
            this.mnuNormal.Size = new System.Drawing.Size(152, 22);
            this.mnuNormal.Tag = "24";
            this.mnuNormal.Text = "Średni";
            this.mnuNormal.Click += new System.EventHandler(this.mnuLevelChange_Click);
            // 
            // mnuHard
            // 
            this.mnuHard.CheckOnClick = true;
            this.mnuHard.Name = "mnuHard";
            this.mnuHard.Size = new System.Drawing.Size(152, 22);
            this.mnuHard.Tag = "36";
            this.mnuHard.Text = "Trudny";
            this.mnuHard.Click += new System.EventHandler(this.mnuLevelChange_Click);
            // 
            // mnuTime
            // 
            this.mnuTime.Name = "mnuTime";
            this.mnuTime.Size = new System.Drawing.Size(46, 20);
            this.mnuTime.Text = "Czas:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemGame";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected void SetGameSize(MemBoard memBoard, MemField memField)
        {
            
            var level = (int)memBoard.GetType().GetField("_gameLevel", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(memBoard);
            var size = (Size) memField.GetType().GetField("_fSize", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(memField);
            
              Height = 4*size.Height + 50+25;
              Width = (level/4)*size.Width + 17;

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuTime;
        private System.Windows.Forms.ToolStripMenuItem mnuEasy;
        private System.Windows.Forms.ToolStripMenuItem mnuNormal;
        private System.Windows.Forms.ToolStripMenuItem mnuHard;
    }
}

