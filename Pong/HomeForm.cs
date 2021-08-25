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
