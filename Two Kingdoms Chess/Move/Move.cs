namespace Two_Kingdoms_Chess
{
    public abstract class Move
    {
        public Piece piece;
        public Position position;
        public string color;

        public Move(Piece piece, Position position)
        {
            this.piece = piece;
            this.position = position;
        }
    }
}
