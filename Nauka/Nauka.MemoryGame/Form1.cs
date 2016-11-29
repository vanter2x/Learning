
using System.Linq;
using System.Windows.Forms;
using Nauka.MemoryGame.MemoryClass;

namespace Nauka.MemoryGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MemBoard GameBoard = new MemBoard(MemBoard.Level.Normal, this);
            
            MemGame Game = new MemGame();
            Game.ShufleFields(GameBoard);
            SetGameSize(GameBoard, GameBoard.Board[0]);
        }
    }
}
