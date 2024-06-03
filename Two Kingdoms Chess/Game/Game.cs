namespace Two_Kingdoms_Chess
{
    public class Game
    {
        public ColoredPiece[,] gameTable = new ColoredPiece[10,10];

        public Player playerOne;
        public Player playerTwo;

        public Game(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;

            addPiecesToTable(playerOne.pieces);
            addPiecesToTable(playerTwo.pieces);
        }

        public Game(Game game)
        {
            this.gameTable = game.gameTable;
            this.playerOne = game.playerOne;
            this.playerTwo = game.playerTwo;
        }

        public void movePiece(Player player, Move move)
        {
            if(player == playerOne)
            {
                playerTwo.onPlayerMove(move);
            }
            else
            {
                playerOne.onPlayerMove(move);
            }
        }

        private void addPiecesToTable(List<ColoredPiece> pieces)
        {
            foreach(ColoredPiece piece in pieces)
            {
                gameTable[piece.piece.position.x,piece.piece.position.y] = piece;
            }
        }
    }                            
}
