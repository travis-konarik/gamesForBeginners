using System;
using System.ComponentModel;
using BallAndPaddlesGameWPF.Models;

namespace BallAndPaddlesGameWPF.Controllers
{
    class PaddleActions
    {
        public Paddle Paddle { get; set; } = new Paddle();

        public PaddleLocation Location
        {
            get { return Paddle.PaddleLocation; }
            set { Paddle.PaddleLocation = value; }
        }

        public int Y1
        {
            get { return Paddle.Y; }
            set { Paddle.Y = value; }
        }

        public int Y2
        {
            get { return Y1 + Length; }
        }

        public int Length
        {
            get { return Paddle.Length; }
            set { Paddle.Length = value; }
        }

        // coordinates for the balls position
        public int X
        {
            get
            {
                if (Location == PaddleLocation.Left)
                {
                    return DistanceFromSide;
                }
                else
                {
                    return PlayAreaWidth - DistanceFromSide;
                }
            }
        }

        public int DistanceFromSide
        {
            get { return Paddle.DistanceFromSide; }
            set { Paddle.DistanceFromSide = value; }
        }

        public int PlayAreaWidth { get; set; }

        public static bool Move(ref PlayArea playArea, Paddle paddle, ConsoleKey? key)
        {
            throw new NotImplementedException();
        }
    }
}