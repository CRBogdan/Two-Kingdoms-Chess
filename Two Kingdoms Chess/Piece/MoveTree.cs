﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess.Piece
{
    public class MoveTree
    {
        public List<MoveTree> moveTrees;
        public List<Move.Move> moves;

        public MoveTree(List<MoveTree> moveTrees, List<Move.Move> moves)
        {
            this.moveTrees = moveTrees;
            this.moves = moves;
        }

        public List<Move.Move> getMovesList()
        {
            List<Move.Move> movesToReturn = new List<Move.Move>();
            if (moves != null)
                movesToReturn.AddRange(moves);

            if (moveTrees == null)
                return movesToReturn;

            foreach (var m in moveTrees)
            {
                var mo = m.getMovesList();
                movesToReturn.AddRange(mo);
            }

            return movesToReturn;
        }
    }
}