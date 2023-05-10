namespace Two_Kingdoms_Chess
{
    public class Client : Player
    {
        public override void movePiece(Move move)
        {
            this.game.movePiece(this, move);
        }

        public override void onPlayerMove(Move move)
        {
            this.gameChangeHandle(move);
        }
    }
}
