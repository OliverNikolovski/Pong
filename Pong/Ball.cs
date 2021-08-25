using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Ball
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float Radius { get; set; }
        public float Speed { get; set; }

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

        public void Update()
        {
            X += VelocityX;
            Y += VelocityY;
        }

        public void ChangeVelocity(int direction, float angle)
        {
            VelocityX = direction * (float)Math.Cos(angle) * Speed;
            VelocityY = (float)Math.Sin(angle) * Speed;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, X - Radius, Y - Radius, diameter, diameter);
            brush.Dispose();
        }

        public bool HitsWall(int height)
        {
            if (Y + Radius >= height || Y - Radius <= 0)
            {
                return true;
            }
            return false;
        }

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
