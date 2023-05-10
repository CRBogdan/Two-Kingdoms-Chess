namespace Two_Kingdoms_Chess
{
    public class Human : Player
    {
        public override void movePiece(Move move)
        {
            this.game.movePiece(this, move);
        }

        public override void onPlayerMove(Move move)
        {
            if(this.gameChangeHandle != null)
                this.gameChangeHandle(move);
        }
    }
}
