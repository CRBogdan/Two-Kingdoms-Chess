using static Two_Kingdoms_Chess.Board;

namespace Two_Kingdoms_Chess
{
    public class Human : Player
    {
        private Board board;

        public void setBoard(Board board)
        {
            this.board = board;
        }

        public override void onPlayerMove(Move move)
        {
            isMyTurn = true;
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

        public override void onPieceMove(Position position)
        {
            Move move;

            if (isMyTurn)
            {
                board.unselectPeace();
                board.clearSquare(this.selectedPiece.piece.position);
                move = this.makeMove(position);
                board.placePeace(this.selectedPiece);
                isMyTurn = !isMyTurn;
                game.movePiece(this, move);
            }

        }
    }
}
