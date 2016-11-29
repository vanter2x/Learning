using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Nauka.TicTacToe.Classes;

namespace Nauka.TicTacToe
{
    public partial class Form1 : Form
    {
        private readonly TicFields _board;
        private bool _player; // false=X , true = O
        private Label whoNext;
        const int SizeOfButton = 200;

        public Form1()
        {
            InitializeComponent();
            _board = new TicFields(this,SizeOfButton);

            _board.GameBoard.ForEach(olek => olek.Click += Clicker);

            foreach (var button in _board.GameBoard)
            {
                button.Click += Clicker;
            }



            Size = new Size(SizeOfButton*3+20,SizeOfButton*3+80);
            whoNext = new Label { Top = Height - 70, Parent = this, Text = @"Teraz kolej: " + (_player ? "O" : "X") };

        }

        private void Clicker(object sender, EventArgs e)
        {
            Field button = (Field) sender;
            if(button.Sign != 0) return;
            button.Text = _player ? "O" : "X";
            button.Sign = _player ? 1 : -1;
            CheckWhoWin();
            _player = !_player;
            whoNext.Text = @"Teraz kolej: " + (_player ? "O" : "X");
        }

        private void CheckWhoWin()
        {
            
            TicDelegate delegat = new TicDelegate { CheckFunc = (f1,f2,f3) => f1 == f2 && f2 == f3 && f1!=0};
            List<bool> checker = new List<bool>();
            checker.Add(delegat.CheckFunc(_board.GameBoardTable[0, 0].Sign, _board.GameBoardTable[0, 1].Sign, _board.GameBoardTable[0, 2].Sign));
            checker.Add(delegat.CheckFunc(_board.GameBoardTable[1, 0].Sign, _board.GameBoardTable[1, 1].Sign, _board.GameBoardTable[1, 2].Sign));
            checker.Add(delegat.CheckFunc(_board.GameBoardTable[2, 0].Sign, _board.GameBoardTable[2, 1].Sign, _board.GameBoardTable[2, 2].Sign));
            checker.Add(delegat.CheckFunc(_board.GameBoardTable[0, 0].Sign, _board.GameBoardTable[1, 0].Sign, _board.GameBoardTable[2, 0].Sign));
            checker.Add(delegat.CheckFunc(_board.GameBoardTable[0, 1].Sign, _board.GameBoardTable[1, 1].Sign, _board.GameBoardTable[2, 1].Sign));
            checker.Add(delegat.CheckFunc(_board.GameBoardTable[0, 2].Sign, _board.GameBoardTable[1, 2].Sign, _board.GameBoardTable[2, 2].Sign));
            checker.Add(delegat.CheckFunc(_board.GameBoardTable[0, 0].Sign, _board.GameBoardTable[1, 1].Sign, _board.GameBoardTable[2, 2].Sign));
            checker.Add(delegat.CheckFunc(_board.GameBoardTable[0, 2].Sign, _board.GameBoardTable[1, 1].Sign, _board.GameBoardTable[2, 0].Sign));
            if (checker.Any(mm => mm)) NewGame(true);
            if(_board.GameBoardTable.OfType<Field>().All(field => field.Sign != 0)) NewGame(false);

        }

        private void NewGame(bool win)

        {
            if(win) MessageBox.Show(@"Wygrywa " + (_player ? "kółko" : "krzyżyk"));
            _board.GameBoardTable.OfType<Field>().ToList().ForEach(field => field.Sign = 0);
            _board.GameBoardTable.OfType<Field>().ToList().ForEach(field => field.Text = "");
        }
    }
}
