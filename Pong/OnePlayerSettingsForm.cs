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
    public partial class OnePlayerSettingsForm : Form
    {
        public OnePlayerSettingsForm()
        {
            InitializeComponent();
            cbDifficulty.SelectedIndex = 0;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Difficulty difficulty = GetDifficulty(cbDifficulty.SelectedIndex);
            int targetScore = (int)nudTargetScore.Value;
            GameForm gameForm = new GameForm(true, targetScore, difficulty, "You");
            gameForm.ShowDialog();
            Close();
        }

        private Difficulty GetDifficulty(int index)
        {
            if (index == 0)
                return Difficulty.EASY;
            else if (index == 1)
                return Difficulty.NORMAL;
            else if (index == 2)
                return Difficulty.HARD;
            else
                return Difficulty.IMPOSSIBLE;
        }

        private void OnePlayerSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
