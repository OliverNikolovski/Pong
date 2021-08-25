using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Paddle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }

        public Paddle(float x, float y, float width, float height, string name)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Name = name;
            Score = 0;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, X, Y, Width, Height);
            brush.Dispose();
        }

        public void Update(float dy)
        {
            Y += dy;
        }

        public void ChangeHeight(float newHeight)
        {
            Height = newHeight;
        }
    }
}
