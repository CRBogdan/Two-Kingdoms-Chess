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
        public override MoveNode getPossibleMoves()
        {
            MoveNode movesTree = new MoveNode(new List<MoveNode>(), null);

            if(position.y + 1 < 10) 
            {
                for(int i = position.y; i < 10; i++)
                {

                }
            }

            return movesTree;
        }
    }
}
