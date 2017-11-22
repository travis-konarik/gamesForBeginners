using System;

namespace BallAndPaddlesGame.Models
{
    internal class Ball
    {
        /// <summary>
        ///     Current direction of the Ball
        /// </summary>
        public BallDirection Direction { get; set; }

        /// <summary>
        ///     How fast the ball is moving
        /// </summary>
        public int MoveSpeed { set; get; }

        /// <summary>
        ///     X Coordinate of the Ball
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Y Coordinate of the Ball
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Event raised when the ball moves
        /// </summary>
        public event EventHandler BallMoved;

        /// <summary>
        ///     Move the ball
        /// </summary>
        public void Move()
        {
            // find which direction the ball is moving
            switch (Direction)
            {
                // if left and down
                case BallDirection.LeftDown:
                {
                    X -= MoveSpeed;
                    Y += MoveSpeed;
                    break;
                }
                // if left and up
                case BallDirection.LeftUp:
                {
                    X -= MoveSpeed;
                    Y -= MoveSpeed;
                    break;
                }
                // if right and down
                case BallDirection.RightDown:
                {
                    X += MoveSpeed;
                    Y += MoveSpeed;
                    break;
                }
                // if right and up
                case BallDirection.RightUp:
                {
                    X += MoveSpeed;
                    Y -= MoveSpeed;
                    break;
                }
            }

            // if some method has been attached to BallMoved. call raise BallMoved event.
            if (BallMoved != null) BallMoved(this, EventArgs.Empty);
        }
    }
}