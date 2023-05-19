namespace Two_Kingdoms_Chess
{
    public class AI : Player
    {
        private BoardPanel board;

        public void setBoard(BoardPanel board)
        {
            this.board = board;
        }

        public void onPieceSelect(ColoredPiece piece)
        {
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

        public void onPieceMove(Position position)
        {
            Move move;
            Random random = new Random();

            int pieceIndex = random.Next(pieces.Count);

            ColoredPiece randomPiece = pieces[pieceIndex];

            List<Move> moves = randomPiece.piece.getPossibleMoves(this.game.gameTable, randomPiece.color);

            Position randomMove = moves[random.Next(moves.Count)].position;

            if (isMyTurn)
            {
                board.unselectPeace();
                board.clearSquare(randomPiece.piece.position);
                move = this.makeMove(randomPiece, randomMove);
                game.movePiece(this, move);
                board.placePeace(randomPiece);
                isMyTurn = !isMyTurn;
            }
        }
    }
}
