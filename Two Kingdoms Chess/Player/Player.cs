namespace Two_Kingdoms_Chess
{
    public abstract class Player
    {

        public Game game;
        public List<ColoredPiece> pieces;
        public delegate void GameChangeHandle(Move move);
        public ColoredPiece selectedPiece;
        public GameChangeHandle gameChangeHandle;
        public Player()
        {
            this.pieces = new List<ColoredPiece>();
        }

        public Move makeMove(Position position)
        {
            if (game.gameTable[position.x, position.y] == null)
            {
                game.gameTable[position.x, position.y] = selectedPiece;
                game.gameTable[selectedPiece.piece.position.x, selectedPiece.piece.position.y] = null;
                selectedPiece.piece.position = position;

                return new NormalMove(selectedPiece.piece, position);
            }
            else if (game.gameTable[position.x, position.y].color != selectedPiece.color)
            {
                game.gameTable[position.x, position.y] = selectedPiece;
                game.gameTable[selectedPiece.piece.position.x, selectedPiece.piece.position.y] = null;
                selectedPiece.piece.position = position;

                return new OffensiveMove(selectedPiece.piece, position);
            }
            else
                return null;
        }

        public abstract void onPlayerMove(Move move);
        public abstract void movePiece(Move move);
    }
}
