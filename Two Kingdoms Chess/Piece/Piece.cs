using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public abstract class Piece
    {
        public Position position;
        public String pieceName;
        public Piece(Position position, string pieceName)
        {
            this.position = position;
            this.pieceName = pieceName;
        }

        public abstract MoveNode getPossibleMoves();
        public void setPosition(Position position)
        {
            this.position = position;
        }
    }
}
