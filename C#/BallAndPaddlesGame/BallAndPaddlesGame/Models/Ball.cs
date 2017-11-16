namespace BallAndPaddlesGame.Models
{
    internal class Ball
    {
        // the direction the ball is moving
        public BallDirection Direction = BallDirection.LeftUp;

        // coordinates for the balls position
        public int X, Y;

        /// <summary>
        ///     initialize the ball object
        /// </summary>
        /// <param name="x">horizontal position</param>
        /// <param name="y">vertical posiion</param>
        public Ball(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}