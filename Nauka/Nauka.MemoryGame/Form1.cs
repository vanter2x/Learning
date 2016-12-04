
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
            _gameBoard = new MemBoard(MemBoard.Level.Hard, this);
            _gameBoard.Board.ForEach(mm => mm.Click += ClickMe);
            _game = new MemGame();
            _game.ShufleFields(_gameBoard);
            SetGameSize(_gameBoard, _gameBoard.Board[0]);


            //gameBoard.Board.ForEach(mm=>mm.PictureShow(Image.FromFile("../../MemoryImage/"+(mm.Sign > 0 ? mm.Sign : mm.Sign*-1)+".png"))); 
            
        }

        private void ClickMe(object sender, EventArgs e)
        {
            MemField field = sender as MemField;
            _game.Clicker(field,_gameBoard.Board.Where(fld =>fld.Visible).ToList());
            
        }
    }
}
