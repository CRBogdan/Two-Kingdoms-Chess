using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public abstract class Piece
    {
        public Position position;
        public String pieceName;
        public Piece(Position position, string pieceName)
        {
            this.position = position;
            this.pieceName = pieceName;
        }

        public abstract List<Move> getPossibleMoves(ColoredPiece[,] table, String color);
        public void setPosition(Position position)
        {
            this.position = position;
        }

        protected Move getMove(ColoredPiece[,] table, Position position, String color)
        {
            if (table[position.x, position.y] != null)
            {
                if(color != table[position.x, position.y].color)
                    return new OffensiveMove(this, new Position(position.x, position.y));
            }
            else
            {
                return new NormalMove(this, new Position(position.x, position.y));
            }

            return null;
        }
    }
}
