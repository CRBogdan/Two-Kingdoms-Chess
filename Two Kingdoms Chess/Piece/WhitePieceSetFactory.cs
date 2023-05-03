using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Two_Kingdoms_Chess.Piece.ConcretPiece;

namespace Two_Kingdoms_Chess
{
    public class WhitePieceSetFactory
    {
        public WhitePieceSetFactory() { }

        public List<WhitePiece> createWhiteSet() 
        {

            return new List<WhitePiece>()
            {
                new WhitePiece(new King(new Position(9, 9))),
            }; 
        }
    }
}
