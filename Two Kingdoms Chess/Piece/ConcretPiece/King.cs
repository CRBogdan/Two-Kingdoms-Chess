using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    internal class King : Piece
    {
        public King(Position position) : base(position, "king")
        {
        }
        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            List<Move> moves = new List<Move>();

            if (position.y + 1 < 10)
                moves.Add(getMove(table, new Position(position.x, position.y+1), color));

            if (position.x + 1 < 10)
                moves.Add(getMove(table, new Position(position.x + 1, position.y), color));

            if (position.x - 1 >= 0)
                moves.Add(getMove(table, new Position(position.x - 1, position.y), color));

            if (position.y - 1 >= 0)
                moves.Add(getMove(table, new Position(position.x, position.y - 1), color));

            if (position.x + 1 < 10 && position.y + 1 < 10)
                moves.Add(getMove(table, new Position(position.x + 1, position.y + 1), color));

            if (position.x - 1 >= 0 && position.y - 1 >= 0)
                moves.Add(getMove(table, new Position(position.x - 1, position.y - 1), color));

            if (position.x - 1 >= 0 && position.y + 1 < 10)
                moves.Add(getMove(table, new Position(position.x - 1, position.y + 1), color));

            if (position.x + 1 < 10 && position.y - 1 >= 0)
                moves.Add(getMove(table, new Position(position.x + 1, position.y - 1), color));

            return moves;
        }
    }
}
