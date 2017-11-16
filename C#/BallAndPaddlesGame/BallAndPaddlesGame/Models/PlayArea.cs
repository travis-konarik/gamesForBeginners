namespace BallAndPaddlesGame.Models
{
    internal class PlayArea
    {
        // height of the playArea
        public readonly int Height;

        // width of the playArea
        public readonly int Width;

        // the playField array
        public object[,] PlayField;

        public PlayArea(int height, int width)
        {
            Height = height;
            Width = width;
            PlayField = new object[height, width];
        }
    }
}