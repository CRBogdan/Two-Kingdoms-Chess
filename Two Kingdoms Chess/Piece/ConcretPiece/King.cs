﻿using System;
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
        public override MoveNode getPossibleMoves()
        {
            MoveNode movesTree = new MoveNode(new List<MoveNode>(), null);

            if (position.y + 1 < 10)
                movesTree.moveNodes.Add(new MoveNode(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x, position.y + 1)),
                    new NormalMove(this, new Position(position.x, position.y + 1)),
                }));

            if (position.x + 1 < 10)
                movesTree.moveNodes.Add(new MoveNode(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x+1, position.y)),
                    new NormalMove(this, new Position(position.x+1, position.y)),
                }));

            if (position.x - 1 >= 0)
                movesTree.moveNodes.Add(new MoveNode(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x - 1, position.y)),
                    new NormalMove(this, new Position(position.x - 1, position.y)),
                }));

            if (position.y - 1 >= 0)
                movesTree.moveNodes.Add(new MoveNode(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x, position.y - 1)),
                    new NormalMove(this, new Position(position.x, position.y - 1)),
                }));

            if (position.x + 1 < 10 && position.y + 1 < 10)
                movesTree.moveNodes.Add(new MoveNode(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x + 1, position.y + 1)),
                    new NormalMove(this, new Position(position.x + 1, position.y + 1)),
                }));

            if (position.x - 1 >= 0 && position.y - 1 >= 0)
                movesTree.moveNodes.Add(new MoveNode(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x - 1, position.y - 1))
                }));

            if (position.x - 1 >= 0 && position.y + 1 < 10)
                movesTree.moveNodes.Add(new MoveNode(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x - 1, position.y + 1)),
                    new NormalMove(this, new Position(position.x - 1, position.y + 1)),
                }));

            if (position.x + 1 < 10 && position.y - 1 >= 0)
                movesTree.moveNodes.Add(new MoveNode(null, new List<Move>()
                {
                    new OffensiveMove(this, new Position(position.x + 1, position.y - 1)),
                    new NormalMove(this, new Position(position.x + 1, position.y - 1)),
                }));

            return movesTree;
        }
    }
}
