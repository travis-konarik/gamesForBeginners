namespace BallAndPaddlesGameWPF.Models
{
    internal class Ball
    {
        // the direction the ball is moving
        public BallDirection Direction;

        // coordinates for the balls position
        public int X, Y, Radius;

        /// <summary>
        ///     initialize the ball object
        /// </summary>
        /// <param name="leftUp"></param>
        /// <param name="x">horizontal position</param>
        /// <param name="y">vertical posiion</param>
        public Ball()
        {
            Direction = BallDirection.LeftUp;
        }
    }
}