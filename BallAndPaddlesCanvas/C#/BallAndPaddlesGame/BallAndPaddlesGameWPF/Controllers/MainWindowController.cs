using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using BallAndPaddlesGameWPF.Models;

namespace BallAndPaddlesGameWPF.Controllers
{
    /// <summary>
    /// Controller for the Game
    /// </summary>
    class MainWindowController
    {
        /// <summary>
        /// Play Area Game Object
        /// </summary>
        public PlayArea PlayArea { get; set; }

        /// <summary>
        /// Left Paddle Game Object
        /// </summary>
        public Paddle LeftPaddle { get; set; }

        /// <summary>
        /// Right Paddle Game Object
        /// </summary>
        public Paddle RightPaddle { get; set; }

        /// <summary>
        /// Ball Game Object
        /// </summary>
        public Ball Ball { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindowController()
        {
            int paddleDistanceFromSide = 25;

            PlayArea = new PlayArea
            {
                BorderWidth = 5,
                Width = 500,
                Height = 500
            };

            LeftPaddle = new Paddle
            {
                PaddleLocation = PaddleLocation.Left,
                X = paddleDistanceFromSide,
                Y1 = 200,
                Length = 100,
                MoveSpeed = 20,
                Thickness = 5
            };
            LeftPaddle.PaddleMoved += PaddleMoved;

            RightPaddle = new Paddle
            {
                PaddleLocation = PaddleLocation.Right,
                X = PlayArea.Width - paddleDistanceFromSide,
                Y1 = 200,
                Length = 100,
                MoveSpeed = 20,
                Thickness = 5
            };
            RightPaddle.PaddleMoved += PaddleMoved;

            Ball = new Ball
            {
                Direction = BallDirection.LeftUp,
                Diameter = 15,
                X = 250,
                Y = 250,
                MoveSpeed = 2
            };
            Ball.BallMoved += BallMoved;

            var timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(5)};
            timer.Tick += Ball.Move;
            timer.Start();
        }

        /// <summary>
        ///     Method Called if a paddle has moved
        /// </summary>
        /// <param name="sender">Can be null</param>
        /// <param name="e">Can be null</param>
        private void PaddleMoved(object sender, EventArgs e)
        {
            Paddle paddle = (Paddle) sender;
            if (paddle.Y1 < PlayArea.BorderWidth)
            {
                paddle.Y1 = PlayArea.BorderWidth;
            }
            else if (paddle.Y2 > PlayArea.Width - PlayArea.BorderWidth)
            {
                paddle.Y1 = PlayArea.Width - PlayArea.BorderWidth - paddle.Length;
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
            {
                AdjustBallDownFromTopBorder();
            }
            // if the ball is in the bottom border
            else if (Ball.Y + Ball.Diameter > PlayArea.Height - PlayArea.BorderWidth)
            {
                AdjustBallUpFromBottomBorder();
            }

            // if the ball is in the left paddle
            if (Ball.X <= LeftPaddle.X + (LeftPaddle.Thickness / 2) &&
                Ball.X >= LeftPaddle.X - (LeftPaddle.Thickness / 2))
            {
                AdjustBallOffLeftPaddle();
            }
            // if the ball is in the right paddle
            else if (Ball.X + Ball.Diameter <= RightPaddle.X + (RightPaddle.Thickness / 2) &&
                     Ball.X + Ball.Diameter >= RightPaddle.X - (RightPaddle.Thickness / 2))
            {
                AdjustBallOffRightPaddle();
            }
            // if the ball is in the left or right border
            else if (Ball.X <= PlayArea.BorderWidth || Ball.X + Ball.Diameter >= PlayArea.Width - PlayArea.BorderWidth)
            {
                EndTheGame();
            }
        }

        /// <summary>
        /// Stops the Ball movement, gives game over message, and closes the application
        /// </summary>
        private void EndTheGame()
        {
            Ball.MoveSpeed = 0;
            if (Application.Current is App)
            {
                MessageBox.Show("Game Over\nThanks for playing.");
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        ///     Move the ball off the right paddle and adjust its direction
        /// </summary>
        private void AdjustBallOffRightPaddle()
        {
            if (Ball.Y >= RightPaddle.Y1 && Ball.Y <= RightPaddle.Y2)
            {
                if (Ball.Direction == BallDirection.RightDown)
                {
                    Ball.Direction = BallDirection.LeftDown;
                }
                else if (Ball.Direction == BallDirection.RightUp)
                {
                    Ball.Direction = BallDirection.LeftUp;
                }
            }

        }

        /// <summary>
        ///     Move the ball off the left paddle and adjust its direction
        /// </summary>
        private void AdjustBallOffLeftPaddle()
        {
            if (Ball.Y >= LeftPaddle.Y1 && Ball.Y <= LeftPaddle.Y2)
            {
                if (Ball.Direction == BallDirection.LeftDown)
                {
                    Ball.Direction = BallDirection.RightDown;
                }
                else if (Ball.Direction == BallDirection.LeftUp)
                {
                    Ball.Direction = BallDirection.RightUp;
                }
            }
        }

        /// <summary>
        ///     Move the ball up from the bottom border and adjust its direction
        /// </summary>
        private void AdjustBallUpFromBottomBorder()
        {
            if (Ball.Direction == BallDirection.LeftDown)
            {
                Ball.Y -= PlayArea.BorderWidth;
                Ball.Direction = BallDirection.LeftUp;
            }
            else if (Ball.Direction == BallDirection.RightDown)
            {
                Ball.Y -= PlayArea.BorderWidth;
                Ball.Direction = BallDirection.RightUp;
            }
        }

        /// <summary>
        ///     Move the ball down from the top border and adjust its direction
        /// </summary>
        private void AdjustBallDownFromTopBorder()
        {
            if (Ball.Direction == BallDirection.LeftUp)
            {
                Ball.Y += PlayArea.BorderWidth;
                Ball.Direction = BallDirection.LeftDown;
            }
            else if (Ball.Direction == BallDirection.RightUp)
            {
                Ball.Y += PlayArea.BorderWidth;
                Ball.Direction = BallDirection.RightDown;
            }
        }
    }
}