using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Two_Kingdoms_Chess
{
    public partial class ClientPanel : UserControl
    {
        private Form1 parent;
        public ClientPanel(Form1 parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void connect_Click(object sender, EventArgs e)
        {
            IPAddress iPAddress = IPAddress.Parse(ipAddress.Text);

            TcpClient client = new TcpClient();

            client.Connect(iPAddress, 5000);

            WhitePieceSetFactory whitePieceSetFactory = new WhitePieceSetFactory();
            BlackPieceSetFactory blackPieceSetFactory = new BlackPieceSetFactory();

            Human humanPlayer = new Human();
            Server serverPlayer = new Server();

            humanPlayer.pieces.AddRange(blackPieceSetFactory.createBlackSet());
            serverPlayer.pieces.AddRange(whitePieceSetFactory.createWhiteSet());

            Game game = new Game(serverPlayer, humanPlayer);

            BoardPanel board = new BoardPanel(game.gameTable);
            board.InitializeBoard();

            serverPlayer.setServer(client);
            humanPlayer.setBoard(board);

            humanPlayer.setGame(game);
            serverPlayer.setGame(game);

            board.subscribeForBlack(humanPlayer.onPieceSelect, humanPlayer.onPieceMove);

            serverPlayer.isMyTurn = true;
            serverPlayer.waitForPlayer();

            parent.showBoard(this, board);
        }
    }
}
