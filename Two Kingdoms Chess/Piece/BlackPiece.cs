namespace Two_Kingdoms_Chess
{
    public class BlackPiece : ColoredPiece
    {
        public BlackPiece(Piece piece)
        {
            this.piece = piece;
            this.color = "black";
        }
        public override string getPieceColor()
        {
            return this.piece.pieceName + "Black.png";
        }
    }
}
