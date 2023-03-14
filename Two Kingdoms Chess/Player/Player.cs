﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Game;
using Two_Kingdoms_Chess.Move;
using Two_Kingdoms_Chess.Piece;

namespace Two_Kingdoms_Chess.Player
{
    public abstract class Player
    {

        public Game.Game game;
        public List<ColoredPiece> pieces;
        public delegate void GameChangeHandle(Move.Move move);
        public GameChangeHandle gameChangeHandle;
        public Player()
        {
            this.pieces = new List<Piece.ColoredPiece>();
        }

        public abstract void onPlayerMove(Move.Move move);
        public abstract void movePiece(Move.Move move);
    }
}
