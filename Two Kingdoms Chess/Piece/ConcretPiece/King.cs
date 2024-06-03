using System.Threading;

namespace Two_Kingdoms_Chess
{
    internal class King : Piece
    {
        private List<Move> attackedMoves = new List<Move>();
        private List<Thread> threads;
        private Semaphore semaphore;
        private bool inCheck = false;
        private Position lastPosition;
        private List<Move> moves = new List<Move>();
        public override bool WasMovedThreeSquares { get => false; protected set { } }
        public override bool WasMoved { get; protected set; }

        public King(Position position) : base(position, "king", 0)
        {
            lastPosition = position;
        }

        public override List<Move> getPossibleMoves(ColoredPiece[,] table, String color)
        {
            moves.Clear();

            threads = new List<Thread>();
            semaphore = new Semaphore(1, 20);

            getAttackedPositions(table, color);

            foreach (var thread in threads)
            {
                thread.Join();
            }

            checkIfInCheck(table);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        moves.Add(getNextMove(table, new Position(position.x + i, position.y + j), color));
                    }
                }
            }

            if (!WasMoved)
            {
                getLongCastlingMove(table, color);
                getShortCastlingMove(table, color);
            }

            moves.RemoveAll(x => x == null);

            semaphore.Dispose();

            return moves;
        }

        private void getAttackedPositions(ColoredPiece[,] table, string color)
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (table[i, j] != null)
                    {
                        if (table[i, j].color != color && table[i, j].piece.GetType() != typeof(King))
                        {
                            createThreads(table,i,j);
                        }
                    }
                }
            }
        }

        private bool moveNearKing(Move move, Position kingPosition, int offsetX, int offsetY = 0)
        {
            if (kingPosition.x + offsetX is < 0 or >= 10 ||
                kingPosition.y + offsetY is < 0 or >= 10)
            {
                return false;
            }

            if (move.position.x == kingPosition.x + offsetX && move.position.y == kingPosition.y + offsetY)
            {
                return true;
            }

            return false;
        }

        private Move getNextMove(ColoredPiece[,] table, Position kingNextPosition, string color)
        {
            if (kingNextPosition.x is < 0 or >= 10 ||
                kingNextPosition.y is < 0 or >= 10)
            {
                return null;
            }

            Move nextMove = getMove(table, kingNextPosition, color);

            if (attackedMoves.Any(x => x.position.x == kingNextPosition.x && x.position.y == kingNextPosition.y))
            {
                return null;
            }

            return nextMove;
        }

        private void createThreads(ColoredPiece[,] table, int x, int y)
        {
            Thread movesThread = new Thread(() =>
            {
                foreach (var move in table[x, y].getMoves(table))
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (moveNearKing(move, position, i, j))
                            {
                                semaphore.WaitOne();

                                attackedMoves.Add(move);

                                semaphore.Release();
                            }
                        }
                    }
                }
            });

            movesThread.Start();

            threads.Add(movesThread);
        }

        public void checkIfInCheck(ColoredPiece[,]table)
        {
            if (attackedMoves.Any(x => x.position == table[position.x, position.y].piece.position))
            {
                inCheck = true;
                return;
            }

            inCheck = false;
        }

        public void getLongCastlingMove(ColoredPiece[,] table, String color)
        {
            if (inCheck)
            {
                return;
            }

            if (table[0, position.y] != null)
            {
                if (table[0, position.y].piece.WasMoved)
                {
                    return;
                }
            }

            for (int i = 1; i < position.x; i++)
            {
                if (table[i,position.y] != null)
                {
                    return;
                }
            }

            ColoredPiece king = table[position.x, position.y];
            table[position.x, position.y] = null;
            table[3, position.y] = king;
            table[3, position.y].piece.position = new Position(3, 9); 

            getAttackedPositions(table, color);

            checkIfInCheck(table);

            table[position.x, position.y] = null;
            table[lastPosition.x, lastPosition.y] = king;
            table[lastPosition.x, lastPosition.y].piece.position = lastPosition;

            if (inCheck)
            {
                return;
            }

            moves.Add(new NormalMove(table[position.x, position.y].piece, new Position(3, position.y)));
        }

        public void getShortCastlingMove(ColoredPiece[,] table, String color)
        {
            if (inCheck)
            {
                return;
            }

            if (table[9, position.y] != null)
            {
                if (table[9, position.y].piece.WasMoved)
                {
                    return;
                }
            }

            for (int i = 8; i > position.x; i--)
            {
                if (table[i, position.y] != null)
                {
                    return;
                }
            }

            ColoredPiece king = table[position.x, position.y];
            table[position.x, position.y] = null;
            table[7, position.y] = king;
            table[7, position.y].piece.position = new Position(7, 9);

            getAttackedPositions(table, color);

            checkIfInCheck(table);

            table[position.x, position.y] = null;
            table[lastPosition.x, lastPosition.y] = king;
            table[lastPosition.x, lastPosition.y].piece.position = lastPosition;

            if (inCheck)
            {
                return;
            }

            moves.Add(new NormalMove(table[position.x, position.y].piece, new Position(7, position.y)));
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
