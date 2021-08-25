using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Game
    {
        private Paddle leftPlayer;
        private Paddle rightPlayer;
        private Ball ball;
        private bool isAgainstComputer;
        private float computerLevel;
        private int targetScore;
        public Size Window { get; set; }
        private float paddleSpeed;
        private readonly Font textFont = new Font("Arial", 40);
        private readonly Brush textBrush = new SolidBrush(Color.White);
        private static readonly float ballStartingSpeed = 15;
        private static readonly float ballStartVelocityX = 7;
        private static readonly float ballStartVelocityY = 7;
        private static readonly float RADIUS = 15;
        private static readonly float PADDLE_WIDTH = 20;
        private static readonly float PADDLE_HEIGHT = 120;
        private static readonly Random rand = new Random();

        public Game(Size window, int targetScore, bool isAgainstComputer, Difficulty difficulty, string leftPlayerName, string rightPlayerName = null)
        {
            Window = new Size(window.Width, window.Height);
            this.targetScore = targetScore;
            float velocityX = rand.Next(10) <= 4 ? ballStartVelocityX : -ballStartVelocityX;
            float velocityY = rand.Next(10) <= 4 ? ballStartVelocityY : -ballStartVelocityY;
            ball = new Ball(Window.Width / 2, Window.Height / 2, ballStartingSpeed, velocityX, velocityY, RADIUS);
            leftPlayer = new Paddle(PADDLE_WIDTH, (Window.Height - PADDLE_HEIGHT) / 2, PADDLE_WIDTH, PADDLE_HEIGHT, leftPlayerName);
            rightPlayer = new Paddle(Window.Width - PADDLE_WIDTH * 2, (Window.Height - PADDLE_HEIGHT) / 2, PADDLE_WIDTH, PADDLE_HEIGHT, isAgainstComputer ? "Computer" : rightPlayerName);
            this.isAgainstComputer = isAgainstComputer;
            if (isAgainstComputer)
                SetDifficulty(difficulty);
            paddleSpeed = 20;
        }

        private void SetDifficulty(Difficulty difficulty)
        {
            if (difficulty == Difficulty.EASY)
                computerLevel = 0.1f;
            else if (difficulty == Difficulty.NORMAL)
                computerLevel = 0.3f;
            else if (difficulty == Difficulty.HARD)
                computerLevel = 0.5f;
            else
                computerLevel = 1;
        }

        public void UpdatePlayers(bool leftGoUp, bool leftGoDown, bool rightGoUp, bool rightGoDown)
        {
            UpdateLeftPlayer(leftGoUp, leftGoDown);
            UpdateRightPlayer(rightGoUp, rightGoDown);
        }

        private void UpdateLeftPlayer(bool goUp, bool goDown)
        {
            if (goUp && leftPlayer.Y > 0)
            {
                leftPlayer.Update(-paddleSpeed);
            }
            if (goDown && (leftPlayer.Y + leftPlayer.Height < Window.Height))
            {
                leftPlayer.Update(paddleSpeed);
            }
        }

        private void UpdateRightPlayer(bool goUp, bool goDown)
        {
            if (isAgainstComputer)
            {
                rightPlayer.Y += ((ball.Y - (rightPlayer.Y + rightPlayer.Height / 2))) * computerLevel;
            }
            else
            {
                if (goUp && rightPlayer.Y > 0)
                {
                    rightPlayer.Update(-paddleSpeed);
                }
                if (goDown && (rightPlayer.Y + rightPlayer.Height < Window.Height))
                {
                    rightPlayer.Update(paddleSpeed);
                }
            }
        }

        public void UpdateBall()
        {
            ball.Update();          
            if (ball.HitsWall(Window.Height))
            {
                Sounds.PlayWallHit();
                ball.VelocityY = -ball.VelocityY;
                return;
            }
            Paddle paddle = ball.X < Window.Width / 2 ? leftPlayer : rightPlayer;
            if (ball.HitsPaddle(paddle))
            {
                Sounds.PlayPaddleHit();
                float relativeIntersectY = ball.Y - (paddle.Y + paddle.Height / 2);
                float normalizedRelativeIntersectionY = relativeIntersectY / (paddle.Height / 2);
                float bounceAngle = (float)Math.PI / 4 * normalizedRelativeIntersectionY;
                int direction = ball.X > Window.Width / 2 ? -1 : 1;
                ball.ChangeVelocity(direction, bounceAngle);
                ball.Speed += 2f;
                return;
            }
            CheckIfGoalScored();
        }

        private void CheckIfGoalScored()
        {
            if (ball.X - ball.Radius >= Window.Width)
            {
                Sounds.PlayLeftScores();
                leftPlayer.Score++;
                ResetBall();
            }
            else if (ball.X + ball.Radius <= 0)
            {
                Sounds.PlayRightScores();
                rightPlayer.Score++;
                ResetBall();
            }
        }

        private void ResetBall()
        {
            ball.X = Window.Width / 2;
            ball.Y = Window.Height / 2;
            ball.VelocityX = rand.Next(10) <= 4 ? ballStartVelocityX : -ballStartVelocityX;
            ball.VelocityY = rand.Next(10) <= 4 ? ballStartVelocityY : -ballStartVelocityY;
            ball.Speed = ballStartingSpeed;
        }

        public void DisplayScore(Graphics g)
        {
            string leftScore = leftPlayer.Score.ToString();
            string rightScore = rightPlayer.Score.ToString();
            g.DrawString(leftScore, textFont, textBrush, Window.Width / 4, 50);
            g.DrawString(rightScore, textFont, textBrush, 3 * Window.Width / 4, 50);
        }

        public void Render(Graphics g)
        {
            leftPlayer.Draw(g);
            rightPlayer.Draw(g);
            ball.Draw(g);
            DisplayScore(g);
        }

        public bool IsGameOver()
        {
            if (leftPlayer.Score == targetScore || rightPlayer.Score == targetScore)
                return true;
            return false;
        }

        public Paddle GetWinner()
        {
            if (leftPlayer.Score == targetScore)
                return leftPlayer;
            else
                return rightPlayer;
        }

        public void Dispose()
        {
            textFont.Dispose();
            textBrush.Dispose();
        }
    }
}
