

namespace Two_Kingdoms_Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void showVsHumanPanel(UserControl mainMenu, UserControl board)
        {
            mainMenu.Hide();

            board.Show();
            board.Dock = DockStyle.Fill;
            this.Controls.Add(board);
        }


    }
}