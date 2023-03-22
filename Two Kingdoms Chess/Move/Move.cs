using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Piece;

namespace Two_Kingdoms_Chess.Move
{
    public abstract class Move
    {
        public Piece.Piece piece;
        public Position position;
        public string color;

        public Move(Piece.Piece piece, Position position)
        {
            this.piece = piece;
            this.position = position;
        }
    }
}
