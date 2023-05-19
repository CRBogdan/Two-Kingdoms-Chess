namespace Two_Kingdoms_Chess
{
    public abstract class Player
    {
        public Game game;
        public List<ColoredPiece> pieces;
        public delegate void GameChangeHandle(Move move);
        public ColoredPiece selectedPiece;
        public GameChangeHandle gameChangeHandle;
        public bool isMyTurn = false;
        public Player()
        {
            this.pieces = new List<ColoredPiece>();
        }

        public void setGame(Game game)
        {
            this.game = game;
        }

        public Move makeMove(ColoredPiece piece, Position position)
        {
            if (game.gameTable[position.x, position.y] == null)
            {
                var pos = new Position(piece.piece.position.x, piece.piece.position.y);

                game.gameTable[position.x, position.y] = piece;
                game.gameTable[piece.piece.position.x, piece.piece.position.y] = null;
                piece.piece.position = position;

                return new NormalMove(piece.piece, pos);
            }
            else if (game.gameTable[position.x, position.y].color != piece.color)
            {
                var pos = new Position(piece.piece.position.x, piece.piece.position.y);

                game.gameTable[position.x, position.y] = piece;
                game.gameTable[piece.piece.position.x, piece.piece.position.y] = null;
                piece.piece.position = position;

                return new OffensiveMove(piece.piece, pos);
            }
            else
                return null;
        }

        public abstract void onPlayerMove(Move move);
    }
}
