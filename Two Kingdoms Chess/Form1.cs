using Two_Kingdoms_Chess.Game;
using Two_Kingdoms_Chess.Move;
using Two_Kingdoms_Chess.Player;

namespace Two_Kingdoms_Chess
{
    public partial class Form1 : Form
    {
        Human humanOne = new Human();
        Human humanTwo = new Human();

        Game.Game game;

        public Form1()
        {
            InitializeComponent();
        }

        private void vsHuman_Click(object sender, EventArgs e)
        {
            Game.Game game = new Game.Game(humanOne, humanTwo);
            humanOne.movePiece(new NormalMove());

            VsHuman human = new VsHuman(humanOne);

            this.Controls.Add(human);

            Thread.Sleep(1000);

            humanTwo.movePiece(new NormalMove());

        }
    }
}