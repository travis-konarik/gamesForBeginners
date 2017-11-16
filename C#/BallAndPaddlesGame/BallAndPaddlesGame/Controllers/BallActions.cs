using BallAndPaddlesGame.Models;

namespace BallAndPaddlesGame.Controllers
{
    /// <summary>
    ///     Actions made by or made on the ball
    /// </summary>
    internal class BallActions
    {
        /// <summary>
        ///     moves the ball
        /// </summary>
        /// <param name="playArea">the playArea the ball will reside on</param>
        /// <param name="ball">the ball</param>
        /// <param name="leftPaddle">the left paddle on the playArea</param>
        /// <param name="rightPaddle">the right paddle on the playArea</param>
        /// <returns>true if the ball is still inbounds</returns>
        internal static bool Move(ref PlayArea playArea, Ball ball, Paddle leftPaddle, Paddle rightPaddle)
        {
            // advance the ball once
            SetBallLocation(ball);

            // is the ball on the outside border
            if (ball.X == 0 || ball.X == playArea.Width - 1)
                return false;

            // if the ball is on the top or bottom border
            if (ball.Y == 0 || ball.Y == playArea.Height - 1)
                BallHitBorder(ball);

            // if the ball is in verticle alignment with the left paddle
            if (ball.X == leftPaddle.X)
                BallHitPaddle(ball, leftPaddle);

            // if the ball is in verticle alignment with the right paddle
            if (ball.X == rightPaddle.X)
                BallHitPaddle(ball, rightPaddle);

            // add the ball to the playArea
            DrawBall(playArea, ball);

            // continue the game
            return true;
        }

        /// <summary>
        ///     place the ball on the playArea
        /// </summary>
        /// <param name="playArea">playArea to place the ball on</param>
        /// <param name="ball">the ball to place on the playArea</param>
        private static void DrawBall(PlayArea playArea, Ball ball)
        {
            // put an "O" on the play field to represent the ball
            playArea.PlayField[ball.Y, ball.X] = 'O';
        }

        /// <summary>
        ///     calculate the ball's position when it hits a paddle
        /// </summary>
        /// <param name="ball">the ball</param>
        /// <param name="paddle">the paddle it hit</param>
        private static void BallHitPaddle(Ball ball, Paddle paddle)
        {
            // if the paddle is on the left
            if (paddle.PaddleLocation == PaddleLocation.Left)
            {
                // is the paddle on the ball
                if (ball.Y >= paddle.Y && ball.Y < paddle.Y + paddle.Length)
                    if (ball.Direction == BallDirection.LeftDown)
                    {
                        // change the direction
                        ball.Direction = BallDirection.RightDown;
                        // move the ball to where it would be if it bounced off the paddle
                        ball.X += 2;
                    }
                    // is the ball moving leftup
                    else if (ball.Direction == BallDirection.LeftUp)
                    {
                        // change the direction
                        ball.Direction = BallDirection.RightUp;
                        // move the ball to where it would be if it bounced off the paddle
                        ball.X += 2;
                    }
            }
            // if the paddle is on the right
            else if (paddle.PaddleLocation == PaddleLocation.Right)
            {
                // is the paddle on the ball
                if (ball.Y >= paddle.Y && ball.Y < paddle.Y + paddle.Length)
                    if (ball.Direction == BallDirection.RightDown)
                    {
                        // change the direction
                        ball.Direction = BallDirection.LeftDown;
                        // move the ball to where it would be if it bounced off the paddle
                        ball.X -= 2;
                    }
                    // is the ball moving rightup
                    else if (ball.Direction == BallDirection.RightUp)
                    {
                        // change the direction
                        ball.Direction = BallDirection.LeftUp;
                        // move the ball to where it would be if it bounced off the paddle
                        ball.X -= 2;
                    }
            }
        }

        /// <summary>
        ///     calculate the ball's position if it hits the top or bottom border
        /// </summary>
        /// <param name="ball">the ball</param>
        private static void BallHitBorder(Ball ball)
        {
            // switch the application on the ball's current direction
            switch (ball.Direction)
            {
                case BallDirection.LeftUp:
                {
                    // change the ball's direction
                    ball.Direction = BallDirection.LeftDown;
                    // move the ball to where it would be if it bounced off the border
                    ball.Y += 2;
                    // exit the case
                    break;
                }
                case BallDirection.LeftDown:
                {
                    // change the ball's direction
                    ball.Direction = BallDirection.LeftUp;
                    // move the ball to where it would be if it bounced off the border
                    ball.Y -= 2;
                    // exit the case
                    break;
                }
                case BallDirection.RightUp:
                {
                    // change the ball's direction
                    ball.Direction = BallDirection.RightDown;
                    // move the ball to where it would be if it bounced off the border
                    ball.Y += 2;
                    // exit the case
                    break;
                }
                case BallDirection.RightDown:
                {
                    // change the ball's direction
                    ball.Direction = BallDirection.RightUp;
                    // move the ball to where it would be if it bounced off the border
                    ball.Y -= 2;
                    // exit the case
                    break;
                }
            }
        }

        /// <summary>
        ///     Set the ball's new location based on it's current direction
        /// </summary>
        /// <param name="ball">the ball</param>
        private static void SetBallLocation(Ball ball)
        {
            // switch the application on the ball's current direction
            switch (ball.Direction)
            {
                case BallDirection.LeftUp:
                {
                    // move the ball left
                    ball.X--;
                    // move the ball up
                    ball.Y--;
                    // exit the case
                    break;
                }
                case BallDirection.LeftDown:
                {
                    // move the ball left
                    ball.X--;
                    // move the ball down
                    ball.Y++;
                    // exit the case
                    break;
                }
                case BallDirection.RightUp:
                {
                    // move the ball right
                    ball.X++;
                    // move the ball up
                    ball.Y--;
                    // exit the case
                    break;
                }
                case BallDirection.RightDown:
                {
                    // move the ball right
                    ball.X++;
                    // move the ball down
                    ball.Y++;
                    // exit the case
                    break;
                }
            }
        }
    }
}