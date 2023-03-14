using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Move;

namespace Two_Kingdoms_Chess.Piece
{
    public abstract class Piece
    {
        public Position position;
        public String pieceName;

        public abstract List<Move.Move> getPossibleMoves();
        public abstract void setPosition(Position position);
    }
}
