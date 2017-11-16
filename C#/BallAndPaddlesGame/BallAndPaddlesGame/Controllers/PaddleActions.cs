using System;
using BallAndPaddlesGame.Models;

namespace BallAndPaddlesGame.Controllers
{
    /// <summary>
    ///     Actions made by or on the ball
    /// </summary>
    internal class PaddleActions
    {
        /// <summary>
        ///     moves the paddle
        /// </summary>
        /// <param name="playArea">the playArea the paddle will reside on</param>
        /// <param name="paddle">the paddle</param>
        /// <param name="key">keyboard key pressed</param>
        public static void Move(ref PlayArea playArea, Paddle paddle, ConsoleKey? key)
        {
            // set the paddle's x coordinate
            SetPaddleX(playArea, paddle);
            // set the paddle's y coordinate
            SetPaddleY(playArea, paddle, key);
            // draw the paddle on the play area
            DrawPaddle(playArea, paddle);
        }

        /// <summary>
        ///     draw the paddle on the play area
        /// </summary>
        /// <param name="playArea">the playArea</param>
        /// <param name="paddle">the paddle</param>
        private static void DrawPaddle(PlayArea playArea, Paddle paddle)
        {
            // start at the top of the paddle and move to the bottom based on the length supplied
            for (var start = paddle.Y; start < paddle.Y + paddle.Length; start++)
                // draw a "|" to represent the paddle
                playArea.PlayField[start, paddle.X] = '|';
        }

        /// <summary>
        ///     set the paddle's y coodinate
        /// </summary>
        /// <param name="playArea">the playArea</param>
        /// <param name="paddle">the paddle</param>
        /// <param name="key">the key pressed</param>
        private static void SetPaddleY(PlayArea playArea, Paddle paddle, ConsoleKey? key)
        {
            // if a key has been pressed
            if (key != null)
                if (key == paddle.UpMovementKey)
                {
                    // if the paddle is not at the top
                    if (paddle.Y > 1)
                        paddle.Y--;
                }
                // if the key pressed is the key set to move the paddle down
                else if (key == paddle.DownMovementKey)
                {
                    // if the paddle is not at the bottom
                    if (paddle.Y + paddle.Length < playArea.Height - 1)
                        paddle.Y++;
                }
        }

        /// <summary>
        ///     set the paddle's x coodinate
        /// </summary>
        /// <param name="playArea">the playArea</param>
        /// <param name="paddle">the paddle</param>
        private static void SetPaddleX(PlayArea playArea, Paddle paddle)
        {
            // if the paddle is located on the left
            if (paddle.PaddleLocation == PaddleLocation.Left)
                paddle.X = 2;
            // if the paddle is located on the right
            else
                paddle.X = playArea.Width - 3;
        }
    }
}