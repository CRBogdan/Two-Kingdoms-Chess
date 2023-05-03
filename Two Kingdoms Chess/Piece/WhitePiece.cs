using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public class WhitePiece : ColoredPiece
    {
        public WhitePiece(Piece piece)
        {
            this.piece = piece;
        }
        public override string getPieceColor()
        {
            return this.piece.pieceName + "White.png";
        }
    }
}
