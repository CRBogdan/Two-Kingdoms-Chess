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
            //Human humanTwo = new Human();

            AI ai = new AI();

            humanOne.pieces.AddRange(whitePieceSetFactory.createWhiteSet());
            ai.pieces.AddRange(blackPieceSetFactory.createBlackSet());


            Game game = new Game(humanOne, ai);

            BoardPanel board = new BoardPanel(game.gameTable);
            board.InitializeBoard();

            humanOne.setBoard(board);
            ai.setBoard(board);

            humanOne.setGame(game);
            ai.setGame(game);

            board.subscribeForWhite(humanOne.onPieceSelect, humanOne.onPieceMove);
            board.subscribeForBlack(ai.onPieceSelect, ai.onPieceMove);

            humanOne.isMyTurn = true;

            parent.showBoard(this, board);
        }

        private void server_Click(object sender, EventArgs e)
        {
            parent.showServer(this);
        }

        private void client_Click(object sender, EventArgs e)
        {
            parent.showClient(this);
        }
    }
}
