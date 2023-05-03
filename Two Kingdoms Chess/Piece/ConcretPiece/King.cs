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
        public override MoveTree getPossibleMoves()
        {
            MoveTree moves = new MoveTree(new List<MoveTree>(), null);

            if (position.y + 1 <= 10)
                moves.moveTrees.Add(new MoveTree(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x, position.y+1))
                }));

            if (position.x + 1 <= 10)
                moves.moveTrees.Add(new MoveTree(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x+1, position.y))
                }));

            if (position.x - 1 >= 0)
                moves.moveTrees.Add(new MoveTree(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x-1, position.y))
                }));

            if (position.y - 1 >= 0)
                moves.moveTrees.Add(new MoveTree(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x, position.y - 1))
                }));

            if (position.x + 1 <= 10 && position.y + 1 <= 10)
                moves.moveTrees.Add(new MoveTree(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x + 1, position.y + 1))
                }));

            if (position.x - 1 >= 0 && position.y - 1 >= 0)
                moves.moveTrees.Add(new MoveTree(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x - 1, position.y - 1))
                }));

            if (position.x - 1 >= 0 && position.y + 1 <= 10)
                moves.moveTrees.Add(new MoveTree(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x - 1, position.y + 1))
                }));

            if (position.x + 1 <= 10 && position.y - 1 >= 0)
                moves.moveTrees.Add(new MoveTree(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x + 1, position.y - 1))
                }));

            return moves;
        }
    }
}
