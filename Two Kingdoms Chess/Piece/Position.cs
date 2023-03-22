using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess.Piece
{
    public class Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.y = y;
            this.x = x;
        }
    }
}
