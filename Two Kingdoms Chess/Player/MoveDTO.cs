using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public class MoveDTO
    {
        public int oldPositionX;
        public int oldPositionY;

        public int newPositionX;
        public int newPositionY;

        public MoveDTO() { }

        public MoveDTO(Move move) 
        {
            this.newPositionX = move.piece.position.x;
            this.newPositionY = move.piece.position.y;

            this.oldPositionX = move.position.x;
            this.oldPositionY = move.position.y;
        }
    }
}
