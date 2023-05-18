namespace Two_Kingdoms_Chess
{
    public partial class BoardPanel : UserControl
    {
        private static readonly string path = Directory.GetCurrentDirectory();
        private Button[,] board = new Button[10, 10];
        private static readonly int buttonSize = 70;

        public delegate void OnPieceSelect(ColoredPiece coloredPiece);
        public event OnPieceSelect onPieceSelectWhite;
        public event OnPieceSelect onPieceSelectBlack;

        public delegate void OnMovePiece(Position position);
        public event OnMovePiece onMovePieceWhite;
        public event OnMovePiece onMovePieceBlack;

        private ColoredPiece[,] gameTable;

        public ColoredPiece selectedPiece;

        public BoardPanel(ColoredPiece[,] gameTable)
        {
            this.gameTable = gameTable;
            InitializeComponent();
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = new Button()
                    {
                        Parent = this,
                        Padding = new Padding(0, 0, 0, 0),
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(i * buttonSize, j * buttonSize),
                        BackColor = Color.SaddleBrown,
                        BackgroundImageLayout = ImageLayout.Stretch,
                    };

                    board[i, j].Click += onPieceClick;

                    if ((i + j) % 2 == 0)
                    {
                        board[i, j].BackColor = Color.NavajoWhite;
                    }

                    this.Controls.Add(board[i, j]);
                }
            }

            addPiecesToTable();
        }

        public void subscribeForWhite(OnPieceSelect onPieceSelect, OnMovePiece onMovePiece)
        {
            this.onMovePieceWhite += onMovePiece;
            this.onPieceSelectWhite += onPieceSelect;
        }

        public void subscribeForBlack(OnPieceSelect onPieceSelect, OnMovePiece onMovePiece)
        {
            this.onMovePieceBlack += onMovePiece;
            this.onPieceSelectBlack += onPieceSelect;
        }

        public void addPiecesToTable()
        {
            foreach (var piece in gameTable)
            {
                if (piece != null)
                {
                    try
                    {
                        board[piece.piece.position.x, piece.piece.position.y].BackgroundImage =
                            Image.FromFile(@$"{path}\Resources\Pieces\{piece.color}Pieces\{piece.piece.pieceName}.png");
                    }
                    catch (Exception e)
                    {
                        board[piece.piece.position.x, piece.piece.position.y].BackColor = Color.RebeccaPurple;
                    }
                }
            }
        }

        private void onPieceClick(object sender, EventArgs eventArgs)
        {
            Position buttonPosition = getButtonPosition(sender);

            if (buttonPosition != null)
            {
                if (gameTable[buttonPosition.x, buttonPosition.y].color == "white" && onPieceSelectWhite != null)
                    onPieceSelectWhite(gameTable[buttonPosition.x, buttonPosition.y]);
                else if (gameTable[buttonPosition.x,buttonPosition.y].color == "black" && onPieceSelectBlack != null)
                    onPieceSelectBlack(gameTable[buttonPosition.x, buttonPosition.y]);
            }
        }

        public void selectPiece(List<Move> moves)
        {
            refreshTable();

            foreach (var move in moves)
            {
                switch (move.color)
                {
                    case "green":
                        board[move.position.x, move.position.y].BackColor = Color.Green;
                        board[move.position.x, move.position.y].Click -= onPieceClick;
                        board[move.position.x, move.position.y].Click += movePiece;

                        break;

                    case "red":
                        board[move.position.x, move.position.y].BackColor = Color.Red;
                        board[move.position.x, move.position.y].Click -= onPieceClick;
                        board[move.position.x, move.position.y].Click += movePiece;

                        break;
                }
            }
        }

        private void refreshTable()
        {

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if ((i + j) % 2 == 0)
                        board[i, j].BackColor = Color.NavajoWhite;
                    else
                        board[i, j].BackColor = Color.SaddleBrown;

                    board[i, j].Click -= movePiece;
                }
            }
        }

        public void movePiece(object sender, EventArgs eventArgs)
        {
            Position buttonPosition = getButtonPosition(sender);

            if(selectedPiece.color == "white" && onMovePieceWhite != null)
                onMovePieceWhite(buttonPosition);
            else if (selectedPiece.color == "black" && onMovePieceBlack != null)
                onMovePieceBlack(buttonPosition);
        }

        public void clearSquare(Position position)
        {
            board[position.x, position.y].BackgroundImage = null;
            board[position.x, position.y].Click -= movePiece;
            board[position.x, position.y].Click -= onPieceClick;
        }

        public void unselectPeace()
        {
            refreshTable();
        }

        public void placePeace(ColoredPiece piece)
        {
            board[piece.piece.position.x, piece.piece.position.y].BackgroundImage =
                Image.FromFile(@$"{path}\Resources\Pieces\{piece.color}Pieces\{piece.piece.pieceName}.png");

            board[piece.piece.position.x, piece.piece.position.y].Click += onPieceClick;
        }

        private Position getButtonPosition(object button)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] == button)
                    {
                        return new Position(i, j);
                    }
                }
            }

            return null;
        }
    }
}