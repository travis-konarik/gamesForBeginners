using System;
using BallAndPaddlesGameWPF.Models;

namespace BallAndPaddlesGameWPF.Controllers
{
    class PlayAreaActions
    {
        public int BorderWidth
        {
            get { return PlayArea.BorderWidth; }
            set { PlayArea.BorderWidth = value; }
        }

        public int Width
        {
            get { return PlayArea.Width; }
            set { PlayArea.Width = value; }
        }

        public int Height
        {
            get { return PlayArea.Height; }
            set { PlayArea.Height = value; }
        }

        public PlayArea PlayArea { get; set; } = new PlayArea();

        public static void Setup(ref PlayArea playArea)
        {
            throw new NotImplementedException();
        }

        public static void ClearField(ref PlayArea playArea)
        {
            throw new NotImplementedException();
        }

        public static void Play(ref PlayArea playArea)
        {
            throw new NotImplementedException();
        }

        public static void CleanUp()
        {
            throw new NotImplementedException();
        }
    }
}