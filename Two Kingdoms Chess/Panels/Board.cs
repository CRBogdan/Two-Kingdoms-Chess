namespace Two_Kingdoms_Chess
{
    public partial class Board : UserControl
    {
        private static readonly string path = Directory.GetCurrentDirectory();
        private Button[,] board = new Button[10, 10];
        private static readonly int buttonSize = 70;
        private readonly Game game;
        private ColoredPiece selectedPiece;

        public Board(Game game)
        {
            InitializeComponent();
            this.game = game ?? throw new ArgumentNullException(nameof(game));
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

                    board[i, j].Click += showMoves;

                    if ((i + j) % 2 == 0)
                    {
                        board[i, j].BackColor = Color.NavajoWhite;
                    }

                    this.Controls.Add(board[i, j]);
                }
            }

            addPiecesToTable();
        }

        public void addPiecesToTable()
        {
            foreach (var piece in game.gameTable)
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

        public void showMoves(object sender, EventArgs eventArgs)
        {
            List<Move> moves = new List<Move>();
            Position buttonPosition = getButtonPosition(sender);

            refreshTable();

            if (game.gameTable[buttonPosition.x, buttonPosition.y] == null)
            {
                return;
            }

            selectedPiece = game.gameTable[buttonPosition.x, buttonPosition.y];

            moves = game.gameTable[buttonPosition.x, buttonPosition.y]
                .piece.getPossibleMoves(game.gameTable, game.gameTable[buttonPosition.x, buttonPosition.y].color);

            foreach (var move in moves)
            {
                switch (move.color)
                {
                    case "green":
                        board[move.position.x, move.position.y].BackColor = Color.Green;
                        board[move.position.x, move.position.y].Click += movePiece;

                        break;

                    case "red":
                        board[move.position.x, move.position.y].BackColor = Color.Red;
                        board[move.position.x, move.position.y].Click -= showMoves;
                        board[move.position.x, move.position.y].Click += movePiece;
                        board[move.position.x, move.position.y].Click += takePiece;

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
                        board[i,j].BackColor = Color.SaddleBrown;

                    board[i, j].Click -= movePiece;
                    board[i, j].Click -= takePiece;
                }
            }
        }

        public void movePiece(object sender, EventArgs eventArgs)
        {
            Position buttonPosition = getButtonPosition(sender);

            removePiece(selectedPiece);

            board[buttonPosition.x, buttonPosition.y].BackgroundImage =
                Image.FromFile(@$"{path}\Resources\Pieces\{selectedPiece.color}Pieces\{selectedPiece.piece.pieceName}.png");

            game.gameTable[buttonPosition.x, buttonPosition.y] = selectedPiece;
            game.gameTable[buttonPosition.x, buttonPosition.y].piece.position = new Position(buttonPosition.x, buttonPosition.y);

            refreshTable();
        }

        public void removePiece(ColoredPiece piece)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == selectedPiece.piece.position.x && j == selectedPiece.piece.position.y)
                    {
                        game.gameTable[i, j] = null;
                        board[i, j].BackgroundImage = null;

                        return;
                    }
                }
            }
        }

        public void takePiece(object sender, EventArgs eventArgs)
        {
            Position buttonPosition = getButtonPosition(sender);

            removePiece(game.gameTable[buttonPosition.x, buttonPosition.y]);

            board[buttonPosition.x, buttonPosition.y].Click += showMoves;

            movePiece(sender, new EventArgs());
        }

        public Position getButtonPosition(object button)
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
