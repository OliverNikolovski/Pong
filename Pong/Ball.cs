using System;
using System.Drawing;


namespace Pong
{
    /// <summary>
    ///     Klasa shto ke ja pretstavuva topkata vo igrata
    /// </summary>
    public class Ball
    {
        /// <summary>
        ///     X koordinatata na centarot na topkata
        /// </summary>
        public float X { get; set; }
        /// <summary>
        ///     Y koordinatata na centarot na topkata
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        ///     Brzina i nasoka na dvizenje na topkata (horizontalna nasoka).
        ///     Ako VelocityX e negativno, topkata se dvizi na levo, ako e pozitivno se dvizi na desno
        /// </summary>
        public float VelocityX { get; set; }
        /// <summary>
        ///     Brzina i nasoka na dvizenje na topkata (vertikalna nasoka).
        ///     Ako VelocityY e negativno, topkata se dvizi nagore, ako e pozitivno se dvizi nadole
        /// </summary>
        public float VelocityY { get; set; }
        /// <summary>
        ///     Radiusot na topkata
        /// </summary>
        public float Radius { get; set; }
        /// <summary>
        ///     Speed e pozitivna vrednost i pretstavuva kolku brzo ke se dvizi topkata.
        ///     So sekoe udiranje na topkata so reket (paddle), Speed ke se zgolemuva,
        ///     a so toa i brzinata na topkata ke se zgolemuva
        /// </summary>
        public float Speed { get; set; }
        /// <summary>
        ///     Dijametarot na topkata.
        ///     Za pri sekoe iscrtuvanje da ne go presmetuvam kako 2 * Radius, 
        ///     ednash go presmetuvam vo konstruktorot.
        /// </summary>
        private float diameter;


        public Ball(float x, float y, float speed, float velocityX, float velocityY, float radius)
        {
            X = x;
            Y = y;
            Speed = speed;
            VelocityX = velocityX;
            VelocityY = velocityY;
            Radius = radius;
            diameter = radius + radius;
        }

        /// <summary>
        ///     Ja menuva lokacijata na topkata, so shto se pravi iluzija na dvizenje.
        /// </summary>
        public void Update()
        {
            X += VelocityX;
            Y += VelocityY;
        }

        /// <summary>
        ///     Ovoj metod se povikuva koga topkata ke udri reket.
        ///     Topkata se odbiva od reketot vo nasokata i pod agolot proprateni kako argumenti.
        /// </summary>
        /// <param name="direction">Nasokata vo koja ke se odbie topkata</param>
        /// <param name="angle">Agolot pod koj ke se odbie topkata</param>
        public void ChangeVelocity(int direction, float angle)
        {
            VelocityX = direction * (float)Math.Cos(angle) * Speed;
            VelocityY = (float)Math.Sin(angle) * Speed;
        }

        /// <summary>
        ///     Iscrtuvanje na topkata so centar vo (X, Y) i soodvetniot radius na povrshinata propratena kako argument.
        /// </summary>
        /// <param name="g">Povrshinata za crtanje na koja ke bide iscrtana topkata.</param>
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, X - Radius, Y - Radius, diameter, diameter);
            brush.Dispose();
        }

        /// <summary>
        ///     Metod koj proveruva dali topkata se udira vo gorniot ili dolniot rab na prozorecot na igrata.
        /// </summary>
        /// <param name="height">Visinata na prozorecot na igrata</param>
        /// <returns>
        ///     True, ako topkata se udira vo gorniot ili dolniot rab na prozorecot na igrata,
        ///     false otherwise. 
        /// </returns>
        public bool HitsWall(int height)
        {
            if (Y + Radius >= height || Y - Radius <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Metod koj proveruva dali topkata udira vo reketot prosleden kako argument.
        /// </summary>
        /// <param name="paddle">Reketot za koj se proveruva dali se sudira so topkata</param>
        /// <returns>True, ako topkata i reketot se sudiraat, false otherwise.</returns>
        public bool HitsPaddle(Paddle paddle)
        {
            float ball_top = Y - Radius;
            float ball_bottom = Y + Radius;
            float ball_left = X - Radius;
            float ball_right = X + Radius;

            float paddle_top = paddle.Y;
            float paddle_bottom = paddle.Y + paddle.Height;
            float paddle_left = paddle.X;
            float paddle_right = paddle.X + paddle.Width;

            if (ball_bottom > paddle_top && ball_top < paddle_bottom &&
                ball_left <= paddle_right && ball_right >= paddle_left)
            {
                return true;
            }
            return false;
        }
    }
}
