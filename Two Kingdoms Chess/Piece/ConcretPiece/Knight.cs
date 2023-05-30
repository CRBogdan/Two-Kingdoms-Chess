namespace Two_Kingdoms_Chess
{
    internal class Knight : Piece
    {
        public override bool WasMovedThreeSquares { get => false; protected set { } }
        public override bool WasMoved { get => false; protected set { } }

        public Knight(Position position) : base(position, "knight", 3)
        {
        }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, string color)
        {
            List<Move> moves = new List<Move>();
             
            //down right
            if(position.x + 1 < 10 && position.y + 2 < 10)
            {
                if (table[position.x + 1, position.y + 2] == null) 
                {
                    moves.Add(new NormalMove(this, new Position(position.x + 1, position.y + 2)));
                }
                else if (table[position.x + 1, position.y + 2].color != color)
                {
                    moves.Add(new OffensiveMove(this, new Position(position.x + 1, position.y + 2)));
                }
            }

            //right down
            if (position.x + 2 < 10 && position.y + 1 < 10)
            {
                if (table[position.x + 2, position.y + 1] == null)
                {
                    moves.Add(new NormalMove(this, new Position(position.x + 2, position.y + 1)));
                }
                else if (table[position.x + 2, position.y + 1].color != color)
                {
                    moves.Add(new OffensiveMove(this, new Position(position.x + 2, position.y + 1)));
                }
            }

            //left down
            if (position.x - 2 >= 0 && position.y + 1 < 10)
            {
                if (table[position.x - 2, position.y + 1] == null)
                {
                    moves.Add(new NormalMove(this, new Position(position.x - 2, position.y + 1)));
                }
                else if(table[position.x - 2, position.y + 1].color != color)
                {
                    moves.Add(new OffensiveMove(this, new Position(position.x - 2, position.y + 1)));
                }
            }

            //down left
            if (position.x - 1 >= 0 && position.y + 2 < 10)
            {
                if (table[position.x - 1, position.y + 2] == null)
                {
                    moves.Add(new NormalMove(this, new Position(position.x - 1, position.y + 2)));
                }
                else if (table[position.x - 1, position.y + 2].color != color)
                {
                    moves.Add(new OffensiveMove(this, new Position(position.x - 1, position.y + 2)));
                }
            }

            //left up
            if (position.x - 2 >= 0 && position.y - 1 >= 0)
            {
                if (table[position.x - 2, position.y - 1] == null)
                {
                    moves.Add(new NormalMove(this, new Position(position.x - 2, position.y - 1)));
                }
                else if (table[position.x - 2, position.y - 1].color != color)
                {
                    moves.Add(new OffensiveMove(this, new Position(position.x - 2, position.y - 1)));
                }
            }

            //up left
            if (position.x - 1 >= 0 && position.y - 2 >= 0)
            {
                if (table[position.x - 1, position.y - 2] == null)
                {
                    moves.Add(new NormalMove(this, new Position(position.x - 1, position.y - 2)));
                }
                else if (table[position.x - 1, position.y - 2].color != color)
                {
                    moves.Add(new OffensiveMove(this, new Position(position.x - 1, position.y - 2)));
                }
            }

            //up right
            if (position.x + 1 < 10 && position.y - 2 >= 0)
            {
                if (table[position.x + 1, position.y - 2] == null)
                {
                    moves.Add(new NormalMove(this, new Position(position.x + 1, position.y - 2)));
                }
                else if (table[position.x + 1, position.y - 2].color != color)
                {
                    moves.Add(new OffensiveMove(this, new Position(position.x + 1, position.y - 2)));
                }
            }

            //right up
            if (position.x + 2 < 10 && position.y - 1 >= 0)
            {
                if (table[position.x + 2, position.y - 1] == null)
                {
                    moves.Add(new NormalMove(this, new Position(position.x + 2, position.y - 1)));
                }
                else if (table[position.x + 2, position.y - 1].color != color)
                {
                    moves.Add(new OffensiveMove(this, new Position(position.x + 2, position.y - 1)));
                }
            }

            return moves;
        }

        public override void checkIfMoved(ColoredPiece[,] table)
        {
        }
    }
}
