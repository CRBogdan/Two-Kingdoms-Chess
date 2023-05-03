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


        public List<Move> getMoves(ColoredPiece[,] table)
        {
            var moveTree = piece.getPossibleMoves();

            return validateMove(table, moveTree).getMovesList();
        }

        private MoveNode validateMove(ColoredPiece[,] table, MoveNode moveTrees)
        {
            for (var i = 0; i < moveTrees.moveNodes.Count; i++)
            {
                var moveTree = moveTrees.moveNodes[i];
                if (table[moveTree.moves[0].position.x, moveTree.moves[0].position.y] == null)
                {
                    moveTree.moves = moveTree.moves.FindAll(x => x.color == "green");
                    moveTree = moveTree.moveNodes != null ? validateMove(table, moveTree) : null;
                }
                else
                {
                    var tablePiece = table[moveTree.moves[0].position.x, moveTree.moves[0].position.y];
                    if (tablePiece.GetType() == this.GetType())
                    {
                        moveTree.moves = null;
                        moveTree.moveNodes = null;
                    }
                    else if (tablePiece.GetType() != this.GetType())
                    {
                        moveTree.moveNodes = null;
                        moveTree.moves = moveTree.moves.FindAll(x=>x.color == "red");
                    }
                }
            }

            return moveTrees;
        }
    }
}
