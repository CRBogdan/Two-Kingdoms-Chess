namespace Two_Kingdoms_Chess
{
    public class AI : Player
    {
        private BoardPanel board;
        private Move bestMove;
        private ColoredPiece bestPiece;
        private Semaphore semaphore;

        public void setBoard(BoardPanel board)
        {
            this.board = board;
        }

        public void onPieceSelect(ColoredPiece piece)
        {
        }

        public override void onPlayerMove(Move move)
        {
            isMyTurn = true;

            if (game.gameTable[move.piece.position.x, move.piece.position.y] != null)
            {
                board.unselectPeace();
                board.clearSquare(move.position);
                board.placePeace(game.gameTable[move.piece.position.x, move.piece.position.y]);
            }
        }

        public void onPieceMove(Position position)
        {
            Move move;
            Random random = new Random();
            int pieceIndex;
            ColoredPiece randomPiece;
            List<Move> moves;

            //do
            //{
            //    pieceIndex = random.Next(pieces.Count);
            //    randomPiece = pieces[pieceIndex];
            //    moves = randomPiece.piece.getPossibleMoves(this.game.gameTable, randomPiece.color);
            //} while (moves.Count == 0);

            //Position randomMove = moves[random.Next(moves.Count)].position;           //random AI

            if (isMyTurn)
            {
                bestMove = getBestMove();
                bestPiece = game.gameTable[bestMove.piece.position.x, bestMove.piece.position.y];

                this.board.selectedPiece = bestPiece;
                this.board.selectPiece(bestPiece.piece.getPossibleMoves(this.game.gameTable, bestPiece.color));

                board.unselectPeace();
                board.clearSquare(bestMove.piece.position);
                move = this.makeMove(bestPiece, bestMove.position);
                game.movePiece(this, move);
                board.placePeace(bestPiece);
                isMyTurn = !isMyTurn;
            }
        }

        private Move getBestMove()
        {
            Tree root = new Tree(0, null, new Game(game), null);
            int depth = 2;

            generateTree(root, depth, "black");

            return findBestValue(root,"black").parent.move;
        }

        private void generateTree(Tree root, int depth, string color)
        {
            List<Thread> threads = new List<Thread>();
            semaphore = new Semaphore(1, 20);

            if (depth == 0)
            {
                return;
            }

            List<ColoredPiece> pieces;

            if (color == "white")
            {
                pieces = root.newGame.playerOne.pieces;
            }
            else
            {
                pieces = root.newGame.playerTwo.pieces;
            }

            foreach (ColoredPiece piece in pieces)
            {
                if (piece.color == color)
                {
                    List<Move> moves = piece.piece.getPossibleMoves(root.newGame.gameTable, piece.color);
                    threads.Clear();

                    foreach (Move move in moves)
                    {
                        Thread thread = new Thread(() =>
                        {
                            Tree child = new Tree(0, root, new Game(game), move);
                            child.newGame.movePiece(this, move);

                            if (color == "white")
                            {
                                child.newGame.playerOne.calculatePoints();
                                
                                child.value = child.newGame.playerOne.points;
                            }
                            else
                            {
                                child.newGame.playerTwo.calculatePoints();
                                child.value = child.newGame.playerTwo.points;
                            }

                            if (move.color == "red")
                            {
                                child.value += child.newGame.gameTable[move.position.x, move.position.y].piece.value;
                            }

                            semaphore.WaitOne();

                            root.children.Add(child);

                            semaphore.Release();
                        });

                        thread.Start();
                        threads.Add(thread);
                    }

                    foreach (Thread thread in threads)
                    {
                        thread.Join();
                    }
                }
            }

            foreach (Tree child in root.children)
            {
                generateTree(child, depth - 1, color == "black" ? "white" : "black");
            }
        }

        
        private Tree findBestValue(Tree root, string color)
        {
            if (root.children.Count == 0)
            {
                return root;
            }

            Tree bestChild = root.children[0];

            foreach (Tree child in root.children)
            {
                if (color == "white")
                {
                    if (bestChild.value > child.value)
                    {
                        bestChild = child;
                    }
                }
                else
                {
                    if (bestChild.value < child.value)
                    {
                        bestChild = child;
                    }
                }
            }
            
            return findBestValue(bestChild, color == "black" ? "white" : "black");
        }
    }

    class Tree
    {
        public int value;
        public Tree parent;
        public List<Tree> children;
        public Game newGame;
        public Move move;

        public Tree(int value, Tree parent, Game newGame, Move move)
        {
            this.value = value;
            this.parent = parent;
            this.children = new List<Tree>();
            this.newGame = newGame;
            this.move = move;
        }
    }
}
