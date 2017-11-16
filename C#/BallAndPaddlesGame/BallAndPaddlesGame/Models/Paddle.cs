using System;

namespace BallAndPaddlesGame.Models
{
    internal class Paddle
    {
        // the paddle's location on the playArea
        public readonly PaddleLocation PaddleLocation;

        // the length of the paddle
        public int Length;

        // coordinates for the balls position
        public int X, Y;

        /// <summary>
        ///     initialize the paddle object
        /// </summary>
        /// <param name="location">the paddle's location on the playArea</param>
        /// <param name="startingY">the paddle's starting position</param>
        public Paddle(PaddleLocation location, int startingY)
        {
            PaddleLocation = location;
            Y = startingY;
        }

        // the key for moving the paddle up
        public ConsoleKey UpMovementKey { get; set; }

        // the key for moving the paddle down
        public ConsoleKey DownMovementKey { get; set; }
    }
}