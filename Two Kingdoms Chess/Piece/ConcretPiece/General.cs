namespace Two_Kingdoms_Chess
{
    internal class General : Piece
    {
        public override bool WasMovedThreeSquares { get => false; protected set { } }
        public override bool WasMoved { get => false; protected set { } }

        public General(Position position) : base(position, "general", 9)
        {
        }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            List<Move> moves = new List<Move>();

            //check moves right
            for(int i = position.x + 1; i < 10; i++)
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
            for(int i = position.x - 1; i >= 0; i--)
            {
                if (table[i, position.y] != null)
                {
                    if(table[i, position.y].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, position.y)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, position.y)));
            }

            //check moves down
            for(int i = position.y + 1; i < 10; i++)
            {
                if (table[position.x, i] != null)
                {
                    if(table[position.x, i].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(position.x, i)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(position.x, i)));
            }

            //check moves up
            for(int i = position.y - 1; i >= 0; i--)
            {
                if (table[position.x, i] != null)
                {
                    if(table[position.x, i].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(position.x, i)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(position.x, i)));
            }

            //check moves up right
            for(int i = position.x + 1, j = position.y - 1; i < 10 && j >= 0; i++, j--)
            {
                if (table[i, j] != null)
                {
                    if(table[i, j].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, j)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, j)));
            }

            //check moves up left
            for(int i = position.x - 1, j = position.y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (table[i, j] != null)
                {
                    if(table[i, j].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, j)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, j)));
            }

            //check moves down left
            for(int i = position.x - 1, j = position.y + 1; i >= 0 && j < 10; i--, j++)
            {
                if (table[i, j] != null)
                {
                    if(table[i, j].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, j)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, j)));
            }

            //check moves down right
            for(int i = position.x + 1, j = position.y + 1; i < 10 && j < 10; i++, j++)
            {
                if (table[i, j] != null)
                {
                    if(table[i, j].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, j)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, j)));
            }

            return moves;
        }

        public override void checkIfMoved(ColoredPiece[,] table)
        {
        }
    }
}
