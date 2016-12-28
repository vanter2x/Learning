
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Nauka.MemoryGame.MemoryClass;

namespace Nauka.MemoryGame
{
    public partial class Form1 : Form
    {
        private  MemGame _game;
        private  MemBoard _gameBoard;
        public Form1()
        {
            InitializeComponent();
            _game = new MemGame();
            StartGame(16);
        }

        //Start new game method
        private void StartGame(int lvl)
        {
            Controls.OfType<MemField>().ToList().ForEach(field=>field.Dispose());
            
            _gameBoard = null;
            _gameBoard = new MemBoard((MemBoard.Level)lvl, this);
            _gameBoard.Board.ForEach(mm => mm.Click += ClickMe);
           
            _game.ShufleFields(_gameBoard);
            SetGameSize(_gameBoard, _gameBoard.Board[0]);
        }
        //------------------------------------------------------------------------------------------------------------------

       //Click field method
        private void ClickMe(object sender, EventArgs e)
        {
            MemField field = sender as MemField;
            _game.Clicker(field,_gameBoard.Board.Where(fld =>fld.Visible).ToList());
        }
        // ------------------------------------------------------------------------------------------------------------------


        private void mnuStart_Click(object sender, EventArgs e)
        {
            var x = mnuLevel.DropDownItems.OfType<ToolStripMenuItem>().ToList().Find(mnu => mnu.Checked);
            StartGame(int.Parse(x.Tag.ToString()));
        }

        private void mnuLevelChange_Click(object sender, EventArgs e)
        {
            var mnuButton = (ToolStripMenuItem)sender;
            mnuLevel.DropDownItems.OfType<ToolStripMenuItem>().ToList().ForEach(mnu=>mnu.Checked = false);
            mnuButton.Checked = true;
        }
    }
}
