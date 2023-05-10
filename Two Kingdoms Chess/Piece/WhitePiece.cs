namespace Two_Kingdoms_Chess
{
    public class WhitePiece : ColoredPiece
    {
        public WhitePiece(Piece piece)
        {
            this.piece = piece;
            this.color = "white";
        }

        public override string getPieceColor()
        {
            return this.piece.pieceName + "White.png";
        }
    }
}
