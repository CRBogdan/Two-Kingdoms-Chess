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

        public Soldier(Position position) : base(position, "soldier")
        {
        }
        public override List<Move> getPossibleMoves(ColoredPiece[,] table)
        {
            MoveNode movesTree = new MoveNode(new List<MoveNode>(), null);

            if (position.y + 1 < 10)
            {
                var tempMove = new MoveNode(null, new List<Move>
                {
                    new OffensiveMove(this, new Position(this.position.x, this.position.y + 1))
                });

                MoveNode currentNode = tempMove;

                movesTree.moveNodes.Add(tempMove);

                for (int i = 0; i < 3; i++)
                {

                }
            }

            return null;
        }

        //private MoveNode nextMove()
    }
}
