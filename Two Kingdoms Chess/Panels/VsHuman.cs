using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Two_Kingdoms_Chess
{
    public partial class VsHuman : UserControl
    {
        private readonly Board board;
        Player playerOne;
        Player playerTwo;

        private bool playerOneTurn = true;

        public VsHuman(Form1 form, Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;

            InitializeComponent();

            this.board = new Board(playerOne.game.gameTable);
            board.Show();
            board.Dock = DockStyle.Fill;
            this.Controls.Add(board);

            board.InitializeBoard();

            //board.onPieceSelect += onPieceSelect;
            //board.onMovePiece += onPieceMove;
        }

        private void onPieceSelect(ColoredPiece piece)
        {
            if(playerOneTurn && piece.color == "white")
            {
                board.selectPiece(piece.piece.getPossibleMoves(playerOne.game.gameTable, piece.color));
                playerOne.selectedPiece = piece;
            }
            else if(!playerOneTurn && piece.color == "black")
            {
                board.selectPiece(piece.piece.getPossibleMoves(playerOne.game.gameTable, piece.color));
                playerTwo.selectedPiece = piece;
            }

        }

        private void onPieceMove(Position position)
        {
            Move move;

            board.unselectPeace();

            if(playerOneTurn)
            {
                board.clearSquare(playerOne.selectedPiece.piece.position);
                move = playerOne.makeMove(position);
                board.placePeace(playerOne.selectedPiece);
            }
            else
            {
                board.clearSquare(playerTwo.selectedPiece.piece.position);
                move = playerTwo.makeMove(position);
                board.placePeace(playerTwo.selectedPiece);
            }

            playerOneTurn = !playerOneTurn;
        }
    }
}
