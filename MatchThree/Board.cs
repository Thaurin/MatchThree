using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchThree
{
    class Board
    {
        PieceType[,] _level = new PieceType[7, 7];
        public PieceType[,] Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public Board()
        {
            for (var i = 0; i < 7; i++)
                for (var j = 0; j < 7; j++)
                    Level[i, j] = (PieceType)(i % 5);
        }
    }
}
