using System.Drawing;


namespace Pong
{
    /// <summary>
    /// Klasa shto ke go pretstavuva reketot shto ke bide upravuvan od igrach vo igrata.
    /// Ima oblik na pravoagolnik.
    /// </summary>
    public class Paddle
    {
        /// <summary>
        /// X koordinatata na gorniot lev agol na reketot
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Y koordinatata na gorniot lev agol na reketot
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// Debelinata na reketot
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// Dolzhinata na reketot
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// Brojot na golovi shto gi ima postignato igrachot shto go upravuva ovoj reket
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Imeto na reketot.
        /// 4 mozhni opcii: "You", "Computer", "Player 1" i "Player 2".
        /// Koga igrate vie protiv kompjuterot, vashiot reket se vika "You", a reketot na kompjuterot "Computer",
        /// Koga igraat dvajca lugje, iminjata na reketite ke bidat "Player 1" i "Player 2".
        /// </summary>
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

        /// <summary>
        ///     Iscrtuvanje na reketot.
        /// </summary>
        /// <param name="g">Povrshinata za crtanje na koja ke bide iscrtan reketot.</param>
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, X, Y, Width, Height);
            brush.Dispose();
        }

        /// <summary>
        /// Menuvanje na vertikalnata lokacija na reketot so shto se ovozmozhuva dvizenje nagore ili nadole.
        /// </summary>
        /// <param name="dy">
        /// Za kolku pikseli da se pridvizi reketot i vo koja nasoka.
        /// Ako dy > 0, reketot se dvizi nadole, ako dy < 0, reketot se dvizi nagore.
        /// </param>
        public void Update(float dy)
        {
            Y += dy;
        }
    }
}
