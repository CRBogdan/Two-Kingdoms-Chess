namespace Two_Kingdoms_Chess
{
    public class Server : Player
    {
        public override void onPlayerMove(Move move)
        {
            this.gameChangeHandle(move);
        }
    }
}
