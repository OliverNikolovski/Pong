using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Sounds
    {
        private static readonly SoundPlayer WALL_HIT = new SoundPlayer(Properties.Resources.wallHit);
        private static readonly SoundPlayer PADDLE_HIT = new SoundPlayer(Properties.Resources.paddleHit);
        private static readonly SoundPlayer LEFT_SCORES = new SoundPlayer(Properties.Resources.leftScores);
        private static readonly SoundPlayer RIGHT_SCORES = new SoundPlayer(Properties.Resources.rightScores);

        public static void PlayWallHit()
        {
            WALL_HIT.Play();
        }

        public static void PlayPaddleHit()
        {
            PADDLE_HIT.Play();
        }

        public static void PlayLeftScores()
        {
            LEFT_SCORES.Play();
        }

        public static void PlayRightScores()
        {
            RIGHT_SCORES.Play();
        }
    }
}
