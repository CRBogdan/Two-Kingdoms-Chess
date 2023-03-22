using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Move;
using Two_Kingdoms_Chess.Piece;
using Two_Kingdoms_Chess.Player;

namespace Two_Kingdoms_Chess.Game
{
    public class Game
    {
        private Piece.ColoredPiece[][] gameTable;

        public Player.Player playerOne;
        public Player.Player playerTwo;

        public Game(Player.Player playerOne, Player.Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;

            playerOne.game = this;
            playerTwo.game = this;

            addPiecesToTable(playerOne.pieces);
            addPiecesToTable(playerTwo.pieces);
        }

        public void movePiece(Player.Player player, Move.Move move)
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
