using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess.Player
{
    public class AI : Player
    {
        public override void movePiece(Move.Move move)
        {
            this.game.movePiece(this, move);
        }

        public override void onPlayerMove(Move.Move move)
        {
            
        }
    }
}
