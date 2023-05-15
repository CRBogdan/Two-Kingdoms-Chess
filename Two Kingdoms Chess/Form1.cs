

namespace Two_Kingdoms_Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void showVsHumanPanel(UserControl menu, Game game)
        {
            menu.Hide();

            VsHuman humanOne = new VsHuman(this, game.playerOne, game.playerTwo);
            humanOne.Show();
            humanOne.Dock = DockStyle.Fill;
            this.Controls.Add(humanOne);
        }

        public void showBoardPanel(UserControl menu, Game game)
        {
            menu.Hide();

            Board board = new Board(game.gameTable);
            board.Show();
            board.Dock = DockStyle.Fill;
            //board.InitializeBoard();

            this.Controls.Add(board);
        }
    }
}