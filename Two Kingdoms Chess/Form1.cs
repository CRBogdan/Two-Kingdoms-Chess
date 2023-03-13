using Two_Kingdoms_Chess.Game;
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

            Game.Game game = new Game.Game(humanOne, humanTwo);
        }
    }
}