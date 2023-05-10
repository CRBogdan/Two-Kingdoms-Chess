namespace Two_Kingdoms_Chess
{
    internal class Canon : Piece
    {
        public Canon(Position position) : base (position, "canon") { }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            List<Move> moves = new List<Move>();

            //check moves diagonal up right
            for(int i = position.x + 1, j = position.y - 1; i < 10 && j > 0; i++, j--)
            {
                if (table[i, j] != null)
                {
                    if (table[i, position.y].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, j)));
                    }
                    break;
                }
                moves.Add(new NormalMove(this, new Position(i, j)));
            }

            //check moves diagonally up left
            for (int i = position.x - 1, j = position.y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (table[i, j] != null)
                {
                    if (table[i, position.y].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, j)));

                    }
                    break;
                }
                moves.Add(new NormalMove(this, new Position(i, j)));
            }

            //check moves diagonally down left
            for (int i = position.x - 1, j = position.y + 1; i >= 0 && j < 10; i--, j++)
            {
                if (table[i, j] != null)
                {
                    if (table[i, position.y].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, j)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, j)));
            }

            //check moves diagonally down right
            for (int i = position.x + 1, j = position.y + 1; i < 10 && j < 10; i++, j++)
            {
                if (table[i, j] != null)
                {
                    if (table[i, position.y].color != color)
                    {
                        moves.Add(new OffensiveMove(this, new Position(i, j)));
                    }
                    break;
                }

                moves.Add(new NormalMove(this, new Position(i, j)));
            }

            return moves;
        }
    }
}
