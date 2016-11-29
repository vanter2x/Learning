using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nauka.TicTacToe.Classes
{
    public class TicFields
    {
        
        public Field[,] GameBoardTable = new Field[3,3];

        public List<Field> GameBoard;

        public TicFields(Form form,int size)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoardTable[i, j] = new Field
                    {
                        Sign = 0,
                        BackColor = Color.DarkCyan,
                        Font = new Font("Arial",(float)size/5, FontStyle.Bold),
                        Size = new Size(size,size),
                        Parent = form,
                        Top= i * size,
                        Left = j * size,
                        Visible = true
                    };
                }
            }
            GameBoard = GameBoardTable.OfType<Field>().ToList();
        }


    }
}