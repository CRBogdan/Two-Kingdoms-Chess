namespace Two_Kingdoms_Chess
{
    internal class Soldier : Piece
    {
        private bool wasMoved = false;

        public Soldier(Position position) : base(position, "soldier")
        {
        }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            List<Move> moves = new List<Move>();

            if (!wasMoved)
            {
                if (color == "white")
                    for (int i = 1; i <= 3; i++)
                    {
                        var temp = getMove(table, new Position(position.x, position.y - i), color);
                        if (temp != null)
                            moves.Add(temp);
                    }
                else
                    for (int i = 1; i <= 3; i++)
                    {
                        var temp = getMove(table, new Position(position.x, position.y + i), color);
                        if (temp != null)
                            moves.Add(temp);
                    }
            }
            else
            {
                if (color == "white")
                    moves.Add(getMove(table, new Position(position.x, position.y - 1), color));
                else
                    moves.Add(getMove(table, new Position(position.x, position.y + 1), color));
            }

            Move tempMove;

            //en passant
            if (color == "white")
            {
                if(position.x + 1 < 10 && position.y - 1 >=0)
                {
                    tempMove = getMove(table, new Position(position.x + 1, position.y - 1), color);
                    if (tempMove != null)
                        if (tempMove.GetType() == typeof(OffensiveMove))
                            moves.Add(tempMove);
                }

                if(position.x - 1 >= 0 && position.y - 1 >= 0)
                {
                    tempMove = getMove(table, new Position(position.x - 1, position.y - 1), color);
                    if (tempMove != null)
                        if (tempMove.GetType() == typeof(OffensiveMove))
                            moves.Add(tempMove);
                }
            }
            else
            {
                if(position.x - 1 >= 0 && position.y + 1 < 10)
                {
                    tempMove = getMove(table, new Position(position.x - 1, position.y + 1), color);
                    if (tempMove != null)
                        if (tempMove.GetType() == typeof(OffensiveMove))
                            moves.Add(tempMove);
                }

                if(position.x + 1 < 10 && position.y + 1 < 10)
                {
                    tempMove = getMove(table, new Position(position.x + 1, position.y + 1), color);
                    if (tempMove != null)
                        if (tempMove.GetType() == typeof(OffensiveMove))
                            moves.Add(tempMove);
                }
            }

            moves.RemoveAll(x => x == null);

            return moves;
        }
    }
}
