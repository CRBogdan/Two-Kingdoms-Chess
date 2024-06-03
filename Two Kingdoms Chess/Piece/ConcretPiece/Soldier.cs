namespace Two_Kingdoms_Chess
{
    public class Soldier : Piece
    {
        private Position lastPosition;
        private List<Move> moves = new List<Move>();
        public override bool WasMovedThreeSquares { get; protected set; }
        public override bool WasMoved { get; protected set; }

        public Soldier(Position position) : base(position, "soldier", 1)
        {
            lastPosition = position;
        }

        public override void checkIfMoved(ColoredPiece[,] table)
        {
            if (table[position.x, position.y] == null)
            {
                WasMoved = false;
                return;
            }

            if (table[position.x, position.y].piece.position != lastPosition)
            {
                WasMoved = true;

                if((table[position.x, position.y].piece.position.y == lastPosition.y + 3) ||
                   (table[position.x, position.y].piece.position.y == lastPosition.y - 3))
                {
                    WasMovedThreeSquares = true;
                    return;
                }

                WasMovedThreeSquares = false;
            }
        }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            moves.Clear();

            checkIfMoved(table);

            if (color == "white")
            {
                getMovesForWhite(table, color);
            }
            else
            {
                getMovesForBlack(table, color);
            }

            moves.RemoveAll(x => x == null);

            return moves;
        }

        public void getMovesForWhite(ColoredPiece[,] table, String color)
        {
            if (!WasMoved)
            {
                if(position.y - 3 >= 0)
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
            }

            for (int i = -1; i <= 1; i++)
            {
                if (position.x + i >= 0 && position.x + i < 10)
                {
                    if (table[position.x + i, position.y - 1] != null && i != 0)
                    {
                        if (table[position.x + i, position.y - 1].color != color)
                        {
                            moves.Add(new OffensiveMove(table[position.x, position.y].piece, new Position(position.x + i, position.y - 1)));
                        }
                    }
                    else if (table[position.x + i, position.y - 1] == null && i == 0)
                    {
                        var temp = getMove(table, new Position(position.x + i, position.y - 1), color);

                        if (temp != null)
                        {
                            moves.Add(temp);
                        }
                    }

                    //en passant
                    //if (table[position.x + i, position.y] != null && i != 0)
                    //{
                    //    table[position.x + i, position.y].piece.checkIfMoved(table);

                    //    if (table[position.x + i, position.y].piece.WasMovedThreeSquares && table[position.x + i, position.y].color != color)
                    //    {
                    //        moves.Add(new OffensiveMove(table[position.x, position.y].piece, new Position(position.x + i, position.y - 1)));
                    //    }
                    //}
                }
            }
        }

        public void getMovesForBlack(ColoredPiece[,] table, String color) 
        {
            if (!WasMoved)
            {
                if(position.y + 3 < 10)
                {
                    if (table[position.x, position.y + 3] == null &&
                    table[position.x, position.y + 2] == null &&
                    table[position.x, position.y + 1] == null)
                    {
                        var temp = getMove(table, new Position(position.x, position.y + 3), color);

                        moves.Add(temp);
                    }
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
                            moves.Add(new OffensiveMove(table[position.x, position.y].piece, new Position(position.x + i, position.y + 1)));
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

                    //en passant
                    //if (table[position.x + i, position.y] != null)
                    //{
                    //    table[position.x + i, position.y].piece.checkIfMoved(table);

                    //    if (table[position.x + i, position.y].piece.WasMovedThreeSquares && table[position.x + i, position.y].color != color)
                    //    {
                    //        moves.Add(new OffensiveMove(table[position.x, position.y].piece, new Position(position.x + i, position.y + 1)));
                    //    }
                    //}
                }
            }
        }
    }
}
