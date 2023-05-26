namespace Two_Kingdoms_Chess
{
    public class Soldier : Piece
    {
        private bool wasMoved = false;
        private bool wasMovedThreeSquares = false;
        private Position lastPosition;


        public Soldier(Position position) : base(position, "soldier")
        {
            lastPosition = position;
        }

        public void checkIfMoved(ColoredPiece[,] table)
        {
            if (table[position.x, position.y].piece.position != lastPosition)
            {
                wasMoved = true;

                if((table[position.x, position.y].piece.position.y == lastPosition.y + 3) ||
                   (table[position.x, position.y].piece.position.y == lastPosition.y - 3))
                {
                    wasMovedThreeSquares = true;                
                }
            }
        }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            List<Move> moves = new List<Move>();

            checkIfMoved(table);

            if (color == "white")
            {
                if (!wasMoved)
                {
                    if (table[position.x, position.y - 3] == null && 
                        table[position.x, position.y - 2] == null && 
                        table[position.x, position.y - 1] == null)
                    {
                        var temp = getMove(table, new Position(position.x, position.y - 3), color);

                        if (temp != null)
                        {
                            moves.Add(temp);
                        }
                    }
                }

                for (int i = -1; i <= 1; i++)
                {
                    if (position.x + i >= 0 && position.x + i < 10)
                    {
                        if (table[position.x + i, position.y - 1] != null && i != 0)
                        {
                            if (table[position.x + i, position.y - 1].color != color)
                            {
                                var temp = getMove(table, new Position(position.x + i, position.y - 1), color);

                                if (temp.color == "red")
                                {
                                    moves.Add(temp);
                                }
                            }
                        }
                        else if (table[position.x + i, position.y - 1] == null && i == 0)
                        {
                            var temp = getMove(table, new Position(position.x + i, position.y - 1), color);

                            if(temp != null)
                            {
                                moves.Add(temp);
                            }
                        }
                    }
                }
            }
            else
            {
                if (!wasMoved)
                {
                    if (table[position.x, position.y + 3] == null && 
                        table[position.x, position.y + 2] == null && 
                        table[position.x, position.y + 1] == null)
                    {
                        var temp = getMove(table, new Position(position.x, position.y + 3), color);

                        moves.Add(temp);
                    }
                }

                for (int i = -1; i <= 1; i++)
                {
                    if (position.x + i >= 0 && position.x + i < 10)
                    {
                        if (table[position.x + i, position.y + 1] != null && i != 0)
                        {
                            if (table[position.x + i, position.y + 1].color != color)
                            {
                                var temp = getMove(table, new Position(position.x + i, position.y + 1), color);

                                if (temp.color == "red")
                                {
                                    moves.Add(temp);
                                }
                            }
                        }
                        else if (table[position.x + i, position.y + 1] == null && i == 0)
                        {
                            var temp = getMove(table, new Position(position.x + i, position.y + 1), color);

                            if (temp != null)
                            {
                                moves.Add(temp);
                            }
                        }
                    }
                }
            }

            Move tempMove;

            //en passant

            moves.RemoveAll(x => x == null);

            return moves;
        }
    }
}
