using System;

namespace BallAndPaddlesGame.Models
{
    internal class Paddle
    {
        /// <summary>
        ///     the length of the paddle
        /// </summary>
        public int Length
        {
            get;
            set
            ;
        }

        /// <summary>
        ///     the speed at which the paddle moves
        /// </summary>
        public int MoveSpeed { get; set; }

        /// <summary>
        ///     X coordinate of the paddle
        /// </summary>
        public int X
        {
            get;
            set
            ;
        }

        /// <summary>
        ///     Y coordinate of the paddle
        /// </summary>
        public int Y1
        {
            get;
            set
            ;
        }

        /// <summary>
        ///     Y2 returns the value of Y1 plus the value of Length.
        ///     It is read only
        /// </summary>
        public int Y2 => Y1 + Length;

        /// <summary>
        ///     the paddle's location on the playArea (Left Side or Right Side)
        /// </summary>
        public PaddleLocation PaddleLocation;

        /// <summary>
        ///     Event raised when the paddle moves
        /// </summary>
        public event EventHandler PaddleMoved;

        /// <summary>
        ///     move the paddle down
        /// </summary>
        /// <param name="sender"></param>
        public void MoveDown()
        {
            Y1 += MoveSpeed;
            if (PaddleMoved != null) PaddleMoved(this, EventArgs.Empty);
        }

        /// <summary>
        ///     move the paddle up
        /// </summary>
        /// <param name="sender"></param>
        public void MoveUp()
        {
            Y1 -= MoveSpeed;
            if (PaddleMoved != null) PaddleMoved(this, EventArgs.Empty);
        }
    }
}