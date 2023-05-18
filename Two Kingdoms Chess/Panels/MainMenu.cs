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

            Human humanOne = new Human();
            Human humanTwo = new Human();

            humanOne.pieces.AddRange(whitePieceSetFactory.createWhiteSet());
            humanTwo.pieces.AddRange(blackPieceSetFactory.createBlackSet());


            Game game = new Game(humanOne, humanTwo);

            BoardPanel board = new BoardPanel(game.gameTable);
            board.InitializeBoard();

            humanOne.setBoard(board);
            humanTwo.setBoard(board);

            humanOne.setGame(game);
            humanTwo.setGame(game);

            board.subscribeForWhite(humanOne.onPieceSelect, humanOne.onPieceMove);
            board.subscribeForBlack(humanTwo.onPieceSelect, humanTwo.onPieceMove);

            humanOne.isMyTurn = true;

            parent.showBoard(this, board);
        }

        private void server_Click(object sender, EventArgs e)
        {
            parent.showServer(this);
        }
    }
}
