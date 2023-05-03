using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public abstract class Player
    {

        public Game game;
        public List<ColoredPiece> pieces;
        public delegate void GameChangeHandle(Move move);
        public GameChangeHandle gameChangeHandle;
        public Player()
        {
            this.pieces = new List<ColoredPiece>();
        }

        public abstract void onPlayerMove(Move move);
        public abstract void movePiece(Move move);
    }
}
