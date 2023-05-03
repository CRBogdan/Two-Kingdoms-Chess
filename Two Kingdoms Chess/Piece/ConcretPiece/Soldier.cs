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
        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            List<Move> moves = new List<Move>();

            if (!wasMoved)
            {
                for(int i = 0; i <= 3; i++) 
                {
                    moves.Add(getMove(table, new Position(position.x, position.y + i), color));
                }
            }
            else
            {
                moves.Add(getMove(table, new Position(position.x, position.y + 1), color));
            }

            Move tempMove;

            tempMove = getMove(table, new Position(position.x + 1, position.y + 1), color);
            if (tempMove.GetType() == typeof(OffensiveMove))
                moves.Add(tempMove);

            tempMove = getMove(table, new Position(position.x - 1, position.y + 1), color);
            if (tempMove.GetType() == typeof(OffensiveMove))
                moves.Add(tempMove);

            return null;
        }
    }
}
