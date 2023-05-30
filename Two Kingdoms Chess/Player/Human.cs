using static Two_Kingdoms_Chess.BoardPanel;

namespace Two_Kingdoms_Chess
{
    public class Human : Player
    {
        private BoardPanel board;

        public void setBoard(BoardPanel board)
        {
            this.board = board;
        }

        public override void onPlayerMove(Move move)
        {
            isMyTurn = true;

            if (game.gameTable[move.piece.position.x, move.piece.position.y] != null)
            {
                board.unselectPeace();
                board.clearSquare(move.position);
                board.placePeace(game.gameTable[move.piece.position.x, move.piece.position.y]);
            }
        }

        public void onPieceSelect(ColoredPiece piece)
        {
            if (isMyTurn)
            {
                this.board.selectedPiece = piece;
                this.board.selectPiece(piece.piece.getPossibleMoves(this.game.gameTable, piece.color));
                this.selectedPiece = piece;
            }
        }

        public void onPieceMove(Position position)
        {
            Move move;

            if (isMyTurn)
            {
                board.unselectPeace();
                board.clearSquare(this.selectedPiece.piece.position);
                move = this.makeMove(selectedPiece, position);
                
                

                isMyTurn = !isMyTurn;
                game.movePiece(this, move);
                board.placePeace(this.selectedPiece);
            }
        }
    }
}
