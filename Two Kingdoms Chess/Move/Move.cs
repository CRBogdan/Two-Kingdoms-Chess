﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Piece;

namespace Two_Kingdoms_Chess.Move
{
    public abstract class Move
    {
        public Piece.Piece ColoredPiece;
        public Position position;
        public string color;

        public abstract string getMoveColor();
    }
}
