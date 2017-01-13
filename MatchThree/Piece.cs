using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchThree
{
    public enum PieceType
    {
        Blue = 1,
        Green,
        Purple,
        Red,
        Yellow
    }

    class Piece
    {
        static readonly string[] _pieceTextures = { "blue_gem", "green_gem", "purple_gem", "red_gem", "yellow_gem" };

        PieceType _type;
        public PieceType Type
        {
            get { return _type; }
            set { _type = value;  }
        }

        public string Texture
        {
            get
            {
                return _pieceTextures[(int)this.Type];
            }
        }

        public Piece(PieceType type)
        {
            this.Type = type;
        }
    }
}
