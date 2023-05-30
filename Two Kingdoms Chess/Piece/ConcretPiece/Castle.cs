namespace Two_Kingdoms_Chess
{
    internal class Castle : Piece
    {
        private Position lastPosition;
        public override bool WasMovedThreeSquares { get => false; protected set { } }
        public override bool WasMoved { get; protected set; }

        public Castle(Position position) : base(position, "castle", 5)
        {
            lastPosition = position;
        }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, string color)
        {
            List<Move> moves = new List<Move>();

            //check moves right
            for (int i = position.x + 1; i < 10; i++)
            {
                if (table[i, position.y] != null)
                {
                    if (table[i, position.y].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, position.y)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, position.y)));
            }

            //check moves left
            for (int i = position.x - 1; i >= 0; i--)
            {
                if (table[i, position.y] != null)
                {
                    if (table[i, position.y].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, position.y)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, position.y)));
            }

            //check moves down
            for (int i = position.y + 1; i < 10; i++)
            {
                if (table[position.x, i] != null)
                {
                    if (table[position.x, i].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(position.x, i)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(position.x, i)));
            }

            //check moves up
            for (int i = position.y - 1; i >= 0; i--)
            {
                if (table[position.x, i] != null)
                {
                    if (table[position.x, i].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(position.x, i)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(position.x, i)));
            }

            return moves;
        }

        public override void checkIfMoved(ColoredPiece[,] table)
        {
            if (table[position.x, position.y].piece.position != lastPosition)
            {
                WasMoved = true;
            }
        }
    }
}
