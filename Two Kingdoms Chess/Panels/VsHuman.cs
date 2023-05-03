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
    public partial class VsHuman : UserControl
    {
        Player player;

        public VsHuman(Form1 form, Player player)
        {
            this.player = player;
            this.player.gameChangeHandle += onGameChange;

            //var sd = dataGridView1

            InitializeComponent();

            dataGridView1.Rows.Clear();

            var moves = player.pieces[0].getMoves(player.game.gameTable);

            foreach (var move in moves)
            {
                dataGridView1.Rows.Add(move.color, move.position.x, move.position.y);
            }
        }

        private void onGameChange(Move move)
        {
        }
    }
}
