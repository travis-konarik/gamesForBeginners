using System;
using BallAndPaddlesGame.Models;

namespace BallAndPaddlesGame.Controllers
{
    /// <summary>
    ///     Controller for the Game
    /// </summary>
    internal class Controller
    {
        /// <summary>
        ///     Array that contains char representations of the game objects for display
        /// </summary>
        public char[,] PlayField { get; set; }

        /// <summary>
        ///     The Height of the playfield
        /// </summary>
        public int PlayFieldHeight => PlayArea.Height;

        /// <summary>
        ///     The Width of the playfield
        /// </summary>
        public int PlayFieldWidth => PlayArea.Width;

        /// <summary>
        ///     is the game still running
        /// </summary>
        public bool Running { get; set; } = true;

        /// <summary>
        ///     Default Constructor
        /// </summary>
        public Controller()
        {
            paddleDistanceFromSide = 2;

            PlayArea = new PlayArea
            {
                BorderWidth = 1,
                Width = 26,
                Height = 26
            };

            PlayField = new char[PlayFieldHeight, PlayFieldWidth];

            LeftPaddle = new Paddle
            {
                PaddleLocation = PaddleLocation.Left,
                X = paddleDistanceFromSide,
                Y1 = 13,
                Length = 5,
                MoveSpeed = 1
            };
            LeftPaddle.PaddleMoved += PaddleMoved;

            RightPaddle = new Paddle
            {
                PaddleLocation = PaddleLocation.Right,
                X = PlayArea.Width - paddleDistanceFromSide,
                Y1 = 13,
                Length = 5,
                MoveSpeed = 1
            };
            RightPaddle.PaddleMoved += PaddleMoved;

            Ball = new Ball
            {
                Direction = BallDirection.LeftUp,
                X = 13,
                Y = 13,
                MoveSpeed = 1
            };
            Ball.BallMoved += BallMoved;
        }

        /// <summary>
        ///     update the playfield array to match the current status of game objects
        /// </summary>
        public void DrawPlayField()
        {
            InitializePlayField();
            DrawPaddle(LeftPaddle);
            DrawPaddle(RightPaddle);
            DrawBall();
        }

        /// <summary>
        ///     Function to advance the ball's position
        /// </summary>
        public void MoveBall()
        {
            Ball.Move();
        }

        /// <summary>
        ///     Function to advance the paddle's position based on key presses
        /// </summary>
        /// <param name="key">which key was pressed</param>
        public void MovePaddle(ConsoleKey? key)
        {
            // given a key press
            switch (key)
            {
                // action if key was 'W'
                case ConsoleKey.W:
                {
                    LeftPaddle.MoveUp();
                    break;
                }
                // action if key was 'S'
                case ConsoleKey.S:
                {
                    LeftPaddle.MoveDown();
                    break;
                }
                // action if key was 'UpArrow'
                case ConsoleKey.UpArrow:
                {
                    RightPaddle.MoveUp();
                    break;
                }
                // action if key was 'DownArrow'
                case ConsoleKey.DownArrow:
                {
                    RightPaddle.MoveDown();
                    break;
                }
            }
        }

        /// <summary>
        ///     Ball Game Object
        /// </summary>
        private Ball Ball { get; }

        /// <summary>
        ///     Left Paddle Game Object
        /// </summary>
        private Paddle LeftPaddle { get; }

        /// <summary>
        ///     Play Area Game Object
        /// </summary>
        private PlayArea PlayArea { get; }

        /// <summary>
        ///     Left Paddle Game Object
        /// </summary>
        private Paddle RightPaddle { get; }

        /// <summary>
        ///     variable stating how far a paddle should be from the side of the play area
        /// </summary>
        private readonly int paddleDistanceFromSide;

        /// <summary>
        ///     Move the ball down from the top border and adjust its direction
        /// </summary>
        private void AdjustBallDownFromTopBorder()
        {
            if (Ball.Direction == BallDirection.LeftUp)
            {
                Ball.Y += PlayArea.BorderWidth + 1;
                Ball.Direction = BallDirection.LeftDown;
            }
            else if (Ball.Direction == BallDirection.RightUp)
            {
                Ball.Y += PlayArea.BorderWidth + 1;
                Ball.Direction = BallDirection.RightDown;
            }
        }

        /// <summary>
        ///     Move the ball off the left paddle and adjust its direction
        /// </summary>
        private void AdjustBallOffLeftPaddle()
        {
            // if the ball is on the paddle
            if (Ball.Y >= LeftPaddle.Y1 && Ball.Y < LeftPaddle.Y2)
                if (Ball.Direction == BallDirection.LeftDown)
                    Ball.Direction = BallDirection.RightDown;
                else if (Ball.Direction == BallDirection.LeftUp)
                    Ball.Direction = BallDirection.RightUp;
        }

        /// <summary>
        ///     Move the ball off the right paddle and adjust its direction
        /// </summary>
        private void AdjustBallOffRightPaddle()
        {
            // if the ball is on the paddle
            if (Ball.Y >= RightPaddle.Y1 && Ball.Y < RightPaddle.Y2)
                if (Ball.Direction == BallDirection.RightDown)
                    Ball.Direction = BallDirection.LeftDown;
                else if (Ball.Direction == BallDirection.RightUp)
                    Ball.Direction = BallDirection.LeftUp;
        }

        /// <summary>
        ///     Move the ball up from the bottom border and adjust its direction
        /// </summary>
        private void AdjustBallUpFromBottomBorder()
        {
            if (Ball.Direction == BallDirection.LeftDown)
            {
                Ball.Y -= PlayArea.BorderWidth + 1;
                Ball.Direction = BallDirection.LeftUp;
            }
            else if (Ball.Direction == BallDirection.RightDown)
            {
                Ball.Y -= PlayArea.BorderWidth + 1;
                Ball.Direction = BallDirection.RightUp;
            }
        }

        /// <summary>
        ///     Method Called if the ball has moved
        /// </summary>
        /// <param name="sender">Can be null</param>
        /// <param name="e">Can be null</param>
        private void BallMoved(object sender, EventArgs e)
        {
            // if the ball is in the top border
            if (Ball.Y < PlayArea.BorderWidth)
                AdjustBallDownFromTopBorder();
            // if the ball is in the bottom border
            else if (Ball.Y > PlayArea.Height - PlayArea.BorderWidth - 1)
                AdjustBallUpFromBottomBorder();
 
            // if the ball is in the left paddle
            if (Ball.X <= LeftPaddle.X + 1 && Ball.X >= LeftPaddle.X + 1)
                AdjustBallOffLeftPaddle();
            // if the ball is in the right paddle
            else if (Ball.X <= RightPaddle.X - 2 && Ball.X >= RightPaddle.X - 2)
                AdjustBallOffRightPaddle();
            // if the ball is in the left or right border
            else if (Ball.X <= PlayArea.BorderWidth || Ball.X >= PlayArea.Width - PlayArea.BorderWidth)
                Running = false;
        }

        /// <summary>
        ///     Place the ball on the play field
        /// </summary>
        private void DrawBall()
        {
            PlayField[Ball.Y, Ball.X] = 'O';
        }

        /// <summary>
        ///     place the paddle on the play field
        /// </summary>
        /// <param name="paddle"></param>
        private void DrawPaddle(Paddle paddle)
        {
            int x;

            if (paddle.PaddleLocation == PaddleLocation.Left)
                x = paddleDistanceFromSide;
            else
                x = PlayArea.Width - paddleDistanceFromSide - 1;

            for (var i = paddle.Y1; i < paddle.Y2; i++)
                PlayField[i, x] = '|';
        }

        /// <summary>
        ///     prep the play field and draw the border
        /// </summary>
        private void InitializePlayField()
        {
            // iterate through all the rows in the play area
            for (var row = 0; row < PlayArea.Height; row++)
                // iterate through all the columns in the row
            for (var column = 0; column < PlayArea.Width; column++)
                // if the cell is on the very top, left, bottom, or right of the play area
                if (row == 0 || column == 0 || row == PlayArea.Height - 1 || column == PlayArea.Width - 1)
                    PlayField[row, column] = '#';
                // otherwise
                else
                    PlayField[row, column] = ' ';
        }

        /// <summary>
        ///     Method Called if a paddle has moved
        /// </summary>
        /// <param name="sender">Can be null</param>
        /// <param name="e">Can be null</param>
        private void PaddleMoved(object sender, EventArgs e)
        {
            var paddle = (Paddle) sender;
            if (paddle.Y1 < PlayArea.BorderWidth)
                paddle.Y1 = PlayArea.BorderWidth;
            else if (paddle.Y2 > PlayArea.Width - PlayArea.BorderWidth)
                paddle.Y1 = PlayArea.Width - PlayArea.BorderWidth - paddle.Length;
        }
    }
}