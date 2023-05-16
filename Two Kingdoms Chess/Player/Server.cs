namespace Two_Kingdoms_Chess
{
    public class Server : Player
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
