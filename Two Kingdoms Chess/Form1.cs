namespace Two_Kingdoms_Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void showBoard(UserControl mainMenu, UserControl board)
        {
            mainMenu.Hide();

            board.Show();
            board.Dock = DockStyle.Fill;
            this.Controls.Add(board);
        }

        public void showServer(UserControl mainMenu) 
        {
            mainMenu.Hide();

            ServerPanel server = new ServerPanel(this);
            server.Show();
            server.Dock = DockStyle.Fill;
            this.Controls.Add(server);
        }
    }
}