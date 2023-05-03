using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public abstract class Move
    {
        public Piece piece;
        public Position position;
        public string color;

        public Move(Piece piece, Position position)
        {
            this.piece = piece;
            this.position = position;
        }
    }
}
