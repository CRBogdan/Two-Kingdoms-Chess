using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Player humanOne = new Human();
            Player humanTwo = new Human();

            humanOne.pieces.AddRange(whitePieceSetFactory.createWhiteSet());
            humanTwo.pieces.AddRange(blackPieceSetFactory.createBlackSet());

            Game game = new Game(humanOne, humanTwo);

            parent.showVsHumanPanel(this, game);
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            Player humanOne = new Human();
            Player humanTwo = new Human();

            Game game = new Game(humanOne, humanTwo);

            parent.showBoardPanel(this, game);
        }
    }
}
