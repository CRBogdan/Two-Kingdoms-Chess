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

            dataGridView1.Rows.Clear();

            var moves = player.pieces[0].piece.getPossibleMoves().getMovesList();

            foreach (var move in moves)
            {
                dataGridView1.Rows.Add(move.color, move.position.x, move.position.y);
            }
        }

        private void onGameChange(Move.Move move)
        {
        }
    }
}
