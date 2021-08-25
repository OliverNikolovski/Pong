using System;
using System.Windows.Forms;

namespace Pong
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void btnOnePlayer_Click(object sender, EventArgs e)
        {
            OnePlayerSettingsForm form = new OnePlayerSettingsForm();
            form.ShowDialog();
        }

        private void btnTwoPlayers_Click(object sender, EventArgs e)
        {
            TwoPlayersSettingsForm form = new TwoPlayersSettingsForm();
            form.ShowDialog();
        }
    }
}
