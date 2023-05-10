namespace Two_Kingdoms_Chess
{
    internal class Archer : Piece
    {
        public Archer(Position position) : base(position, "archer") { }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            List<Move> moves = new List<Move>();

            if(position.y + 2 < 10)
                moves.Add(getMove(table, new Position(position.x, position.y + 2), color));

            if(position.x + 2 < 10)
                moves.Add(getMove(table, new Position(position.x + 2, position.y), color));

            if (position.x - 2 >= 0)
                moves.Add(getMove(table, new Position(position.x - 2, position.y), color));

            if (position.y - 2 >= 0)
                moves.Add(getMove(table, new Position(position.x, position.y - 2), color));
            
            if (position.x + 2 < 10 && position.y + 2 < 10)
                moves.Add(getMove(table, new Position(position.x + 2, position.y + 2), color));

            if (position.x - 2 >= 0 && position.y - 2 >= 0)
                moves.Add(getMove(table, new Position(position.x - 2, position.y - 2), color));

            if (position.x - 2 >= 0 && position.y + 2 < 10)
                moves.Add(getMove(table, new Position(position.x - 2, position.y + 2), color));

            if (position.x + 2 < 10 && position.y - 2 >= 0)
                moves.Add(getMove(table, new Position(position.x + 2, position.y - 2), color));

            moves.RemoveAll(x => x == null);

            return moves;
        }
    }
}
