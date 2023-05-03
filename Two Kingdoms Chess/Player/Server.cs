﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public class Server : Player
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
