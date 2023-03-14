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

        public VsHuman(Player.Player player)
        {
            this.player = player;
            this.player.gameChangeHandle += onGameChange;
            InitializeComponent();
        }

        private void onGameChange(Move.Move move)
        {
            label1.Text = move.getMoveColor();
        }
    }
}
