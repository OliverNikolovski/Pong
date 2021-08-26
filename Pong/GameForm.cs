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
    public partial class GameForm : Form
    {
        private Game game;
        private Graphics graphics;
        // Chetka za boenje na kanvasot so crna boja
        private Brush brush;
        // dictionary za chuvanje koi kopcinja od tastaturata se pritisnati
        // za dvizenje na reketite (W, S, Arrow Up, Arrow Down)
        private Dictionary<Keys, bool> pressedKeys;
        private bool isAgainstComputer;
        private int targetScore;
        private Difficulty difficulty;
        private string leftPlayerName;
        private string rightPlayerName;
        private Size window;
        private bool paused;

        public GameForm(bool isAgainstComputer, int targetScore, Difficulty difficulty, string leftPlayerName, string rightPlayerName)
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
            this.isAgainstComputer = isAgainstComputer;
            this.window = new Size(ClientSize.Width, ClientSize.Height);
            this.targetScore = targetScore;
            this.difficulty = difficulty;
            this.leftPlayerName = leftPlayerName;
            this.rightPlayerName = rightPlayerName;
            game = new Game(window, targetScore, isAgainstComputer, difficulty, leftPlayerName, rightPlayerName);
            DoubleBuffered = true;
            graphics = CreateGraphics();
            brush = new SolidBrush(Color.Black);
            // na pochetok site kopchinja za dvizenje na reketite se postavuvaat na false
            pressedKeys = new Dictionary<Keys, bool>
            {
                [Keys.W] = false,
                [Keys.S] = false,
                [Keys.Up] = false,
                [Keys.Down] = false
            };
            paused = false;
            gameTimer.Enabled = true;
        }

        private void ClearCanvas()
        {
            graphics.FillRectangle(brush, 0, 0, Size.Width, Size.Height);
        }

        // Koga ke bide oslobodeno nekoe kopche, postavi go soodvetnoto entry na toa kopche vo dictionary na false
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys[e.KeyCode] = true;
        }

        // Koga ke bide pritisnato nekoe kopche, postavi go soodvetnoto entry na toa kopche vo dictionary na true
        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys[e.KeyCode] = false;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameForm_Paint(sender, null);
            game.UpdatePlayers(pressedKeys[Keys.W], pressedKeys[Keys.S], pressedKeys[Keys.Up], pressedKeys[Keys.Down]);
            game.UpdateBall();
            if (game.IsGameOver())
            {
                // mora soodvetnite kopchinja da se setiraat na false
                // inache ima chuden bug kade shto koga ke se pochne nova igra
                // inputite od prethodnata igra koi bile vneseni pred igrata da zavrshi
                // se obrabotuvaat i ne moze da se kontroliraat reketite dodeka ne se isprocesiraat starite inputi
                pressedKeys[Keys.W] = false;
                pressedKeys[Keys.S] = false;
                pressedKeys[Keys.Up] = false;
                pressedKeys[Keys.Down] = false;

                gameTimer.Enabled = false;
                Paddle winner = game.GetWinner();
                DialogResult result = MessageBox.Show(winner.Name.ToString() + 
                    (winner.Name.Equals("You") ? " win" : " wins") + "! Do you want to play again?",
                    "Game Over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    game.Dispose();
                    game = new Game(window, targetScore, isAgainstComputer, difficulty, leftPlayerName, rightPlayerName);
                    gameTimer.Enabled = true;
                }
                else
                {
                    Close();
                }
            }
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            ClearCanvas();
            game.Render(graphics);
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'p' || e.KeyChar == 'P')
            {
                if (paused)
                {
                    paused = false;
                    gameTimer.Enabled = true;
                }
                else
                {
                    paused = true;
                    gameTimer.Enabled = false;
                    Font font = new Font("Arial", 50);
                    Brush whiteBrush = new SolidBrush(Color.White);
                    graphics.DrawString("PAUSED", font, whiteBrush, window.Width / 2 - 150, window.Height / 2 - 25);
                    font.Dispose();
                    whiteBrush.Dispose();
                }
            }
        }
    }
}
