namespace Two_Kingdoms_Chess
{
    public class Client : Player
    {
        public override void onPieceMove(Position position)
        {
            throw new NotImplementedException();
        }

        public override void onPlayerMove(Move move)
        {
            this.gameChangeHandle(move);
        }
    }
}
