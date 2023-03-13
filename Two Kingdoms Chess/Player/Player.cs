using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Game;
using Two_Kingdoms_Chess.Move;
using Two_Kingdoms_Chess.Piece;

namespace Two_Kingdoms_Chess.Player
{
    public abstract class Player
    {
        protected Game.Game game;
        protected List<ColoredPiece> pieces;
        protected delegate void GameChangeHandle(Move.Move move);
        protected GameChangeHandle gameChangeHandle;

        public abstract void onPlayerMove(Move.Move move);
        public abstract void movePiece(Move.Move move);
        public List<ColoredPiece> getPieces()
        {
            return pieces;
        }
    }
}
