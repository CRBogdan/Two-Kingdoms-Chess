namespace Two_Kingdoms_Chess
{
    public class BlackPieceSetFactory
    {
        public BlackPieceSetFactory() { }

        public List<BlackPiece> createBlackSet()
        {
            List<BlackPiece> blackPieces = new List<BlackPiece>();

            for (int i = 0; i < 10; i++)
            {
                blackPieces.Add(new BlackPiece(new Soldier(new Position(i, 1))));
            }

            blackPieces.Add(new BlackPiece(new Castle(new Position(0, 0))));
            blackPieces.Add(new BlackPiece(new Castle(new Position(9, 0))));

            blackPieces.Add(new BlackPiece(new Knight(new Position(1, 0))));
            blackPieces.Add(new BlackPiece(new Knight(new Position(8, 0))));

            blackPieces.Add(new BlackPiece(new Archer(new Position(2, 0))));
            blackPieces.Add(new BlackPiece(new Archer(new Position(7, 0))));

            blackPieces.Add(new BlackPiece(new Canon(new Position(3, 0))));
            blackPieces.Add(new BlackPiece(new Canon(new Position(6, 0))));

            blackPieces.Add(new BlackPiece(new General(new Position(4, 0))));

            blackPieces.Add(new BlackPiece(new King(new Position(5, 0))));

            return blackPieces;
        }
    }
}
