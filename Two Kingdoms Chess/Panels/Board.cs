namespace Two_Kingdoms_Chess
{
    public partial class Board : UserControl
    {
        private string path = Directory.GetCurrentDirectory();
        private Button[,] board = new Button[10, 10];
        private int buttonSize = 70;
        private Game game;

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
                        board[i, j].BackColor = Color.White;
                    }

                    this.Controls.Add(board[i, j]);
                }
            }

            addPiecesToTable();
        }

        public void addPiecesToTable()
        {
            foreach(var piece in game.gameTable)
            {
                if(piece != null)
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
            Button piece;
            List<Move> moves = new List<Move>();

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (board[i,j] == sender)
                    {
                       moves = game.gameTable[i, j].piece.getPossibleMoves(game.gameTable, game.gameTable[i,j].color);
                       break;
                    }
                }
            }

            foreach(var move in moves)
            {
                if(move.color == "green")
                {
                    board[move.position.x, move.position.y].BackColor = Color.Green;
                }
                else if(move.color == "red")
                {
                    board[move.position.x, move.position.y].BackColor = Color.Red;
                }
            }
        }
    }
}
