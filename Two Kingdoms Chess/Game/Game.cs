﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public class Game
    {
        private ColoredPiece[][] gameTable;

        public Player playerOne;
        public Player playerTwo;

        public Game(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;

            playerOne.game = this;
            playerTwo.game = this;

            addPiecesToTable(playerOne.pieces);
            addPiecesToTable(playerTwo.pieces);
        }

        public void movePiece(Player player, Move move)
        {
            if(player == playerOne)
            {
                playerTwo.onPlayerMove(move);
            }else
            {
                playerOne.onPlayerMove(move);
            }
        }

        private void addPiecesToTable(List<ColoredPiece> pieces)
        {
            foreach(ColoredPiece piece in pieces)
            {
                gameTable[piece.piece.position.x][piece.piece.position.y] = piece;
            }
        }
    }                            
}
