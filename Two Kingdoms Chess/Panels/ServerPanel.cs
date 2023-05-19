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
    public partial class ServerPanel : UserControl
    {
        private Form1 parent;
        public ServerPanel(Form1 parent)
        {
            InitializeComponent();

            string hostName = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

            string ip = "";

            foreach (IPAddress ipAddress in hostEntry.AddressList)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = ipAddress.ToString();
                }
            }

            IP.Text = "IP: " + ip;
            this.parent = parent;

            waitForConnection(ip);
        }

        public async void waitForConnection(string ip)
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            int port = 5000;

            TcpListener listener = new TcpListener(IPAddress.Any, port);

            listener.Start();

            TcpClient client = await listener.AcceptTcpClientAsync();

            listener.Stop();

            WhitePieceSetFactory whitePieceSetFactory = new WhitePieceSetFactory();
            BlackPieceSetFactory blackPieceSetFactory = new BlackPieceSetFactory();

            Human humanPlayer = new Human();
            Client clientPlayer = new Client();

            humanPlayer.pieces.AddRange(whitePieceSetFactory.createWhiteSet());
            clientPlayer.pieces.AddRange(blackPieceSetFactory.createBlackSet());


            Game game = new Game(humanPlayer, clientPlayer);

            BoardPanel board = new BoardPanel(game.gameTable);
            board.InitializeBoard();

            humanPlayer.setBoard(board);
            clientPlayer.setClient(client);

            humanPlayer.setGame(game);
            clientPlayer.setGame(game);

            board.subscribeForWhite(humanPlayer.onPieceSelect, humanPlayer.onPieceMove);

            humanPlayer.isMyTurn = true;

            parent.showBoard(this, board);
        }
    }
}
