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

            if (game.gameTable[move.position.x, move.position.y] != null)
            {
                board.unselectPeace();
                board.clearSquare(move.position);
                var moveTemp = this.makeMove(game.gameTable[move.position.x, move.position.y], move.piece.position);
                board.placePeace(game.gameTable[moveTemp.piece.position.x, moveTemp.piece.position.y]);
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

        public override void onPieceMove(Position position)
        {
            Move move;

            if (isMyTurn)
            {
                board.unselectPeace();
                board.clearSquare(this.selectedPiece.piece.position);
                move = this.makeMove(selectedPiece, position);
                game.movePiece(this, move);
                board.placePeace(this.selectedPiece);
                isMyTurn = !isMyTurn;
            }

        }
    }
}
