using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public class BlackPiece : ColoredPiece
    {
        public BlackPiece(Piece piece)
        {
            this.piece = piece;
        }
        public override string getPieceColor()
        {
            return this.piece.pieceName + "Black.png";
        }
    }
}
