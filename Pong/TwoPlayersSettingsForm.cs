using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class TwoPlayersSettingsForm : Form
    {
        public TwoPlayersSettingsForm()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int targetScore = (int)nudTargetScore.Value;
            GameForm gameForm = new GameForm(false, targetScore, Difficulty.EASY, "Player 1", "Player 2");
            gameForm.ShowDialog();
            Close();
        }

        private void TwoPlayersSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
