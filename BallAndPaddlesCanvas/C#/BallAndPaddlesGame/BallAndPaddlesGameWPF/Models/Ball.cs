using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BallAndPaddlesGameWPF.Models
{
    internal class Ball : INotifyPropertyChanged
    {
        /// <summary>
        ///     The Ball's Diameter
        /// </summary>
        public int Diameter { get; set; }

        /// <summary>
        ///     Current direction of the Ball
        /// </summary>
        public BallDirection Direction { get; set; }

        /// <summary>
        ///     How fast the ball is moving
        /// </summary>
        public int MoveSpeed { set; get; }

        /// <summary>
        ///     X Coordinate of the Ball
        /// </summary>
        public int X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        /// <summary>
        ///     Y Coordinate of the Ball
        /// </summary>
        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        /// <summary>
        ///     Event raised when the ball moves
        /// </summary>
        public event EventHandler BallMoved;

        /// <summary>
        ///     Event raised when a property changes.
        ///     Part of the INotifyPropertyChanged interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Move the ball
        /// </summary>
        /// <param name="sender">needed to make the method attachable to an event. can be null</param>
        /// <param name="e">needed to make the method attachable to an event. can be null</param>
        public void Move(object sender, EventArgs e)
        {
            // find which direction the ball is moving
            switch (Direction)
            {
                // if left and down
                case BallDirection.LeftDown:
                {
                    X -= MoveSpeed;
                    Y += MoveSpeed;
                    break;
                }
                // if left and up
                case BallDirection.LeftUp:
                {
                    X -= MoveSpeed;
                    Y -= MoveSpeed;
                    break;
                }
                // if right and down
                case BallDirection.RightDown:
                {
                    X += MoveSpeed;
                    Y += MoveSpeed;
                    break;
                }
                // if right and up
                case BallDirection.RightUp:
                {
                    X += MoveSpeed;
                    Y -= MoveSpeed;
                    break;
                }
            }

            // if some method has been attached to BallMoved. call raise BallMoved event.
            if (BallMoved != null) BallMoved(this, EventArgs.Empty);
        }

        /// <summary>
        ///     backing field for X property
        /// </summary>
        private int _x;

        /// <summary>
        ///     backing field for Y property
        /// </summary>
        private int _y;

        /// <summary>
        ///     Called when a property changes to raise the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the property that changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // if PropertyChanged is not null, Invoke (run) the method with "this" as the sender and new event arguements from the given property name
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}