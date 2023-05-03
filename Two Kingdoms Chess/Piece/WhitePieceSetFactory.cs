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

            return new List<WhitePiece>()
            {
                new WhitePiece(new Knight(new Position(5, 5))),
                //new WhitePiece(new Soldier(new Position(5, 4))),
            }; 
        }
    }
}
