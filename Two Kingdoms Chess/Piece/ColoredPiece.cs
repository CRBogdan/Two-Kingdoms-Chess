using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public abstract class ColoredPiece
    {
        public Piece piece;

        public abstract String getPieceColor();

        public List<Move> getMoves(ColoredPiece[,] table)
        {
            return piece.getPossibleMoves(table);
        }
    }
}
