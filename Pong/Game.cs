using System;
using System.Drawing;

namespace Pong
{
    /// <summary>
    /// Klasa shto ja pretstavuva igrata.
    /// </summary>
    public class Game
    {
        private Paddle leftPlayer; // leviot reket
        private Paddle rightPlayer; // desniot reket
        private Ball ball;
        private bool isAgainstComputer;  // dali igrata e singleplayer (chovek vs computer) ili multiplayer (chovek vs chovek)
        private float computerLevel;  // kolku ke bide teshko da se pobedi kompjuterot
        private int targetScore;   // koj prv stigne do targetScore toj e pobednik
        public Size Window { get; set; }  // goleminata (width i height) na prozorecot na igrata
        
        // fontot i chetkata za iscrtuvanje na rezultatot
        // za da ne gi kreiram i unishtuvam celo vreme koga ke go iscrtuvam rezultatot
        // gi kreiram ednash tuka i gi unishtuvam koga ke se zatvori formava (t.e koga ke zavrshi igrata)
        private readonly Font textFont = new Font("Arial", 40);
        private readonly Brush textBrush = new SolidBrush(Color.White);

        // pochetnite brzini na topkata gi chuvam vo promenlivi
        // bidejki ke mi trebaat koga ke se postigne gol i ke treba da se resetira topkata
        private static readonly float BALL_STARTING_SPEED = 18;
        private static readonly float BALL_STARTING_VELOCITY_X = 15;
        private static readonly float BALL_STARTING_VELOCITY_Y = 15;

        private static readonly float RADIUS = 15; // radiusot na topkata

        private static readonly float PADDLE_SPEED = 25; // brzinata na reketite
        private static readonly float PADDLE_WIDTH = 20; // debelinata na reketite
        private static readonly float PADDLE_HEIGHT = 120; // dolzhinata na reketite

        // ovoj random ke mi treba za topkata da pochnuva da odi vo random nasoka pri sekoe resetiranje
        // otkako ke se postigne gol. (da ne odi celo vreme vo ista nasoka)
        private static readonly Random RAND = new Random();

        public Game(Size window, int targetScore, bool isAgainstComputer, Difficulty difficulty, string leftPlayerName, string rightPlayerName)
        {
            Window = new Size(window.Width, window.Height);
            this.targetScore = targetScore;
            // se izbira random horizontalna nasoka (levo ili desno) za topkata
            float velocityX = RAND.Next(10) <= 4 ? BALL_STARTING_VELOCITY_X : -BALL_STARTING_VELOCITY_X;
            // se izbira random vertikalna nasoka (gore ili dole) za topkata
            float velocityY = RAND.Next(10) <= 4 ? BALL_STARTING_VELOCITY_Y : -BALL_STARTING_VELOCITY_Y;
            ball = new Ball(Window.Width / 2, Window.Height / 2, BALL_STARTING_SPEED, velocityX, velocityY, RADIUS);
            leftPlayer = new Paddle(PADDLE_WIDTH, (Window.Height - PADDLE_HEIGHT) / 2, PADDLE_WIDTH, PADDLE_HEIGHT, leftPlayerName);
            rightPlayer = new Paddle(Window.Width - PADDLE_WIDTH * 2, (Window.Height - PADDLE_HEIGHT) / 2, PADDLE_WIDTH, PADDLE_HEIGHT, rightPlayerName);
            this.isAgainstComputer = isAgainstComputer;
            // ako igra chovek protiv kompjuter podesi go izbraniot level na kompjuterot
            if (isAgainstComputer)
                SetDifficulty(difficulty);
        }

        /// <summary>
        /// Podesuvanje na soodveniot level na kompjuterot.
        /// </summary>
        /// <param name="difficulty">Kompetentnosta na kompjuterot vo igrata.</param>
        private void SetDifficulty(Difficulty difficulty)
        {
            if (difficulty == Difficulty.EASY)
                computerLevel = 0.3f;
            else if (difficulty == Difficulty.NORMAL)
                computerLevel = 0.4f;
            else if (difficulty == Difficulty.HARD)
                computerLevel = 0.5f;
            else
                computerLevel = 1;
        }

        /// <summary>
        /// Gi pridvizhuva reketite gore/dole spored parametrite.
        /// </summary>
        /// <param name="leftGoUp">Leviot reket da odi gore</param>
        /// <param name="leftGoDown">Leviot reket da odi dole</param>
        /// <param name="rightGoUp">Desniot reket da odi gore</param>
        /// <param name="rightGoDown">Desniot reket da odi dole</param>
        public void UpdatePlayers(bool leftGoUp, bool leftGoDown, bool rightGoUp, bool rightGoDown)
        {
            UpdateLeftPlayer(leftGoUp, leftGoDown);
            UpdateRightPlayer(rightGoUp, rightGoDown);
        }

        /// <summary>
        /// Pridvizuvanje na leviot reket.
        /// Smee da se dvizi nagore i nadole se dodeka ne izleguva nadvor od prozorecot na igrata.
        /// </summary>
        /// <param name="goUp">Dali da odi gore</param>
        /// <param name="goDown">Dali da odi dole</param>
        private void UpdateLeftPlayer(bool goUp, bool goDown)
        {
            if (goUp && leftPlayer.Y > 0)
            {
                leftPlayer.Update(-PADDLE_SPEED);
            }
            if (goDown && (leftPlayer.Y + leftPlayer.Height < Window.Height))
            {
                leftPlayer.Update(PADDLE_SPEED);
            }
        }

        /// <summary>
        /// Pridvizuvanje na desniot reket.
        /// Smee da se dvizi nagore i nadole se dodeka ne izleguva nadvor od prozorecot na igrata.
        /// Ako igrata e singleplayer (chovek vs computer) togash parametrite nemaat nikakvo znachenje i 
        /// dvizenjeto na kompjuterot se presmetuva spored formula.
        /// </summary>
        /// <param name="goUp">Dali da odi gore</param>
        /// <param name="goDown">Dali da odi dole</param>
        private void UpdateRightPlayer(bool goUp, bool goDown)
        {
            if (isAgainstComputer)
            {
                // reketot se pomestuva nadole ili nagore za razlikata megju Y koordinatata na centarot
                // na topkata i Y koordinatata na centarot na reketot, pomnozheno so levelot na kompjuterot
                rightPlayer.Y += ((ball.Y - (rightPlayer.Y + rightPlayer.Height / 2))) * computerLevel;
            }
            else
            {
                if (goUp && rightPlayer.Y > 0)
                {
                    rightPlayer.Update(-PADDLE_SPEED);
                }
                if (goDown && (rightPlayer.Y + rightPlayer.Height < Window.Height))
                {
                    rightPlayer.Update(PADDLE_SPEED);
                }
            }
        }

        /// <summary>
        /// So povikuvanje na ovoj metod se pridvizhuva topkata i se proveruva dali udira vo 
        /// gorniot ili dolniot rab na prozorecot ili dali udira nekoj reket ili dali e postignat gol
        /// i se prezemaat soodvetnite akcii.
        /// </summary>
        public void UpdateBall()
        {
            ball.Update(); // move ball
            if (ball.HitsWall(Window.Height)) // dali udira gore ili dole vo prozorecot
            {
                Sounds.PlayWallHit();  // play sound for wall hit
                ball.VelocityY = -ball.VelocityY; // smeni ja vertikalnata nasoka
                return;
            }
            // nema potreba da proveruvam za dvata reketi
            Paddle paddle = ball.X < Window.Width / 2 ? leftPlayer : rightPlayer;
            if (ball.HitsPaddle(paddle)) // dali topkata udira vo reketot
            {
                Sounds.PlayPaddleHit();
                float relativeIntersectY = ball.Y - (paddle.Y + paddle.Height / 2);
                float normalizedRelativeIntersectionY = relativeIntersectY / (paddle.Height / 2);
                float bounceAngle = (float)Math.PI / 4 * normalizedRelativeIntersectionY;
                int direction = ball.X > Window.Width / 2 ? -1 : 1;
                ball.ChangeVelocity(direction, bounceAngle);
                ball.Speed += 1f;
                return;
            }
            CheckIfGoalScored();
        }

        /// <summary>
        /// Ako e postignat gol azhuriraj go rezultatot i resetiraj ja topkata.
        /// </summary>
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

        /// <summary>
        /// Po postignuvanje na gol topkata povtorno pochuva od sredinata na prozorecot so pochetnata brzina
        /// i odi vo random nasoka.
        /// </summary>
        private void ResetBall()
        {
            ball.X = Window.Width / 2;
            ball.Y = Window.Height / 2;
            ball.VelocityX = RAND.Next(10) <= 4 ? BALL_STARTING_VELOCITY_X : -BALL_STARTING_VELOCITY_X;
            ball.VelocityY = RAND.Next(10) <= 4 ? BALL_STARTING_VELOCITY_Y : -BALL_STARTING_VELOCITY_Y;
            ball.Speed = BALL_STARTING_SPEED;
        }

        /// <summary>
        /// Iscrtuvanje na rezultatot.
        /// </summary>
        /// <param name="g">Povrshinata za crtanje na koja ke bide iscrtan rezultatot.</param>
        public void DisplayScore(Graphics g)
        {
            string leftScore = leftPlayer.Score.ToString();
            string rightScore = rightPlayer.Score.ToString();
            g.DrawString(leftScore, textFont, textBrush, Window.Width / 4, 50);
            g.DrawString(rightScore, textFont, textBrush, 3 * Window.Width / 4, 50);
        }

        /// <summary>
        /// Iscrtuvanje na site komponenti vo igrata.
        /// </summary>
        /// <param name="g">Povrshinata na koja ke se iscraat komponentite na igrata.</param>
        public void Render(Graphics g)
        {
            leftPlayer.Draw(g);
            rightPlayer.Draw(g);
            ball.Draw(g);
            DisplayScore(g);
        }

        /// <summary>
        /// Dali e igrata zavrshena.
        /// </summary>
        /// <returns>True, ako nekoj stignal do targetScore, false otherwise.</returns>
        public bool IsGameOver()
        {
            if (leftPlayer.Score == targetScore || rightPlayer.Score == targetScore)
                return true;
            return false;
        }

        /// <summary>
        /// Go vrakja pobednikot na igrata.
        /// Igrata mora da e zavrshena.
        /// </summary>
        /// <returns>Pobednikot na igrata.</returns>
        public Paddle GetWinner()
        {
            if (leftPlayer.Score == targetScore)
                return leftPlayer;
            else
                return rightPlayer;
        }

        /// <summary>
        /// Gi osloboduva resursite na igrata.
        /// </summary>
        public void Dispose()
        {
            textFont.Dispose();
            textBrush.Dispose();
        }
    }
}
