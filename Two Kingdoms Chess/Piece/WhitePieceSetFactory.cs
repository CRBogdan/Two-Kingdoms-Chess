using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public class WhitePieceSetFactory
    {
        public WhitePieceSetFactory() { }

        public List<WhitePiece> createWhiteSet() 
        {
            List<WhitePiece> whitePieces = new List<WhitePiece>();

            //for (int i = 0; i < 10; i++)
            //{
            //    whitePieces.Add(new WhitePiece(new Soldier(new Position(i, 8))));
            //}

            whitePieces.Add(new WhitePiece(new Castle(new Position(0, 9))));
            whitePieces.Add(new WhitePiece(new Castle(new Position(9, 9))));

            whitePieces.Add(new WhitePiece(new Knight(new Position(1, 9))));
            whitePieces.Add(new WhitePiece(new Knight(new Position(8, 9))));

            //whitePieces.Add(new WhitePiece(new Archer(new Position(2, 9))));
            //whitePieces.Add(new WhitePiece(new Archer(new Position(7, 9))));

            whitePieces.Add(new WhitePiece(new Canon(new Position(3, 9))));
            whitePieces.Add(new WhitePiece(new Canon(new Position(6, 9))));

            whitePieces.Add(new WhitePiece(new General(new Position(4, 9))));
            
            whitePieces.Add(new WhitePiece(new King(new Position(5, 9))));

            return whitePieces;
        }
    }
}
