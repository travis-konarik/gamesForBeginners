using System;

namespace BallAndPaddlesGameWPF.Models
{
    internal class Paddle
    {
        // the paddle's location on the playArea
        public PaddleLocation PaddleLocation;
        // the length of the paddle
        public int Length;

        public int Y;

        public int DistanceFromSide;

        /// <summary>
        ///     initialize the paddle object
        /// </summary>
        /// <param name="location">the paddle's location on the playArea</param>
        /// <param name="startingY">the paddle's starting position</param>
        public Paddle()
        {
        }

        // the key for moving the paddle up
        public ConsoleKey UpMovementKey { get; set; }

        // the key for moving the paddle down
        public ConsoleKey DownMovementKey { get; set; }
    }
}