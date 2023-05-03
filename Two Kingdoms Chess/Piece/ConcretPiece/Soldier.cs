using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    internal class Soldier : Piece
    {
        private bool wasMoved = false;

        public Soldier(Position position): base(position, "soldier") 
        {
        }
        public override MoveTree getPossibleMoves()
        {
            MoveTree moves = new MoveTree(new List<MoveTree>(), null);

            if(position.y + 1 <= 9) 
            {
                //moves.moveTrees.Add(null, );
            }

            return moves;
        }
    }
}
