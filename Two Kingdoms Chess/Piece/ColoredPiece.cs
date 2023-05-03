using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess
{
    public abstract class ColoredPiece
    {
        public Piece piece;

        public abstract String getPieceColor();


        public List<Move> getMoves(ColoredPiece[][] table, MoveTree tree)
        {
            List<Move> moves = new List<Move>();

            return validateMove(table, moveTree).getMovesList();
        }

        private MoveTree validateMove(ColoredPiece[,] table, MoveTree moveTrees)
        {
            for (var i = 0; i < moveTrees.moveTrees.Count; i++)
            {
                var moveTree = moveTrees.moveTrees[i];
                if (table[moveTree.moves[0].position.x, moveTree.moves[0].position.y] == null)
                {
                    moveTree.moves = moveTree.moves.FindAll(x => x.color == "green");
                    moveTree = moveTree.moveTrees != null ? validateMove(table, moveTree) : null;
                }
                else
                {
                    var tablePiece = table[moveTree.moves[0].position.x, moveTree.moves[0].position.y];
                    if (tablePiece.GetType() == this.GetType())
                    {
                        moveTree.moves = null;
                        moveTree.moveTrees = null;
                    }
                    else if (tablePiece.GetType() != this.GetType())
                    {
                        moveTree.moveTrees = null;
                        moveTree.moves = moveTree.moves.FindAll(x=>x.color == "red");
                    }
                }
            }

            return moveTrees;
        }
    }
}
