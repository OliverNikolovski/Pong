using System;
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

        // mora da povikam Dispose() koga ke se zatvori formata bidejki kaj modalnite formi ne se povikuva
        // avtomatski Dispose() koga se zatvora formata.
        private void TwoPlayersSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
