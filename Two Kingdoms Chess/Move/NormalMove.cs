using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Piece;

namespace Two_Kingdoms_Chess.Move
{
    public class NormalMove : Move
    {
        public NormalMove(Piece.Piece piece, Position position) : base(piece, position)
        {
            this.color = "green";
        }
    }
}
