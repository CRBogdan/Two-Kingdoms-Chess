using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Two_Kingdoms_Chess.Piece;

namespace Two_Kingdoms_Chess
{
    public partial class MainMenu : UserControl
    {
        private Form1 parent;
        public MainMenu(Form1 form)
        {
            this.parent = form;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WhitePieceSetFactory whitePieceSetFactory = new WhitePieceSetFactory();
            BlackPieceSetFactory blackPieceSetFactory = new BlackPieceSetFactory();

            Player.Player humanOne = new Player.Human();
            Player.Player humanTwo= new Player.Human();

            Game.Game game = new Game.Game(humanOne, humanTwo);

            humanOne.pieces.AddRange(whitePieceSetFactory.createWhiteSet());
            humanTwo.pieces.AddRange(blackPieceSetFactory.createBlackSet());


            parent.showVsHumanPanel(this, game);
        }
    }
}
