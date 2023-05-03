using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public class BlackPieceSetFactory
    {
        public BlackPieceSetFactory() { }

        public List<BlackPiece> createBlackSet()
        {
            return new List<BlackPiece>()
        {
                new BlackPiece(new Soldier(new Position(8, 9)))
        };
        }
    }
}
