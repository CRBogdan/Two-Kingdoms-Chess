namespace Two_Kingdoms_Chess
{
    public class NormalMove : Move
    {
        public NormalMove(Piece piece, Position position) : base(piece, position)
        {
            this.color = "green";
        }
    }
}
