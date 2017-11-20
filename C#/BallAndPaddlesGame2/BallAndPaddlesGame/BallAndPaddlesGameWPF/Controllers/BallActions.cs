using System;
using BallAndPaddlesGameWPF.Models;

namespace BallAndPaddlesGameWPF.Controllers
{
    class BallActions
    {
        public Ball ball { get; set; } = new Ball();

        public BallDirection Direction
        {
            get { return ball.Direction; }
            set { ball.Direction = value; }
        }

        // coordinates for the balls position
        public int X
        {
            get { return ball.X; }
            set { ball.X = value; }
        }

        public int Y
        {
            get { return ball.Y; }
            set { ball.Y = value; }
        }

        public int Radius
        {
            get { return ball.Radius; }
            set { ball.Radius = value; }
        }

        public static bool Move(ref PlayArea playArea, Ball ball, Paddle leftPaddle, Paddle rightPaddle)
        {
            throw new NotImplementedException();
        }
    }
}