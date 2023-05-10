namespace Two_Kingdoms_Chess
{
    public class AI : Player
    {
        public override void movePiece(Move move)
        {
            this.game.movePiece(this, move);
        }

        public override void onPlayerMove(Move move)
        {
            
        }
    }
}
