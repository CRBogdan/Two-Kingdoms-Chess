using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Two_Kingdoms_Chess.Move;
using Two_Kingdoms_Chess.Player;

namespace Two_Kingdoms_Chess
{
    public partial class VsHuman : UserControl
    {
        Player.Player player;

        public VsHuman(Form1 form, Player.Player player)
        {
            this.player = player;
            this.player.gameChangeHandle += onGameChange;
            InitializeComponent();

            pieces.Items.Clear();

            foreach(var piece in player.pieces)
            {
                pieces.Items.Add($"{piece.piece.position.X} {piece.piece.position.Y}");
            }
        }

        private void onGameChange(Move.Move move)
        {
        }
    }
}
