using System;

namespace Nauka.TicTacToe.Classes
{
    public class TicDelegate
    {
        public Func<int,int,int,bool> CheckFunc { get; set; }
       
    }
}