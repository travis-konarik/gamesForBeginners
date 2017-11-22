using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BallAndPaddlesGameWPF.Utilities;

namespace BallAndPaddlesGameWPF.Models
{
    internal class Paddle : INotifyPropertyChanged
    {
        /// <summary>
        ///     the length of the paddle
        /// </summary>
        public int Length
        {
            get { return _length; }
            set
            {
                _length = value;
                OnPropertyChanged(nameof(Y2));
            }
        }

        /// <summary>
        ///     Command for an outside application to give so our paddle will move down
        /// </summary>
        public ICommand MovePaddleDown
        {
            get
            {
                if (_moveDown == null)
                    _moveDown = new RelayCommand(MoveDown);
                return _moveDown;
            }
        }

        /// <summary>
        ///     Command for an outside application to give so our paddle will move up
        /// </summary>
        public ICommand MovePaddleUp
        {
            get
            {
                if (_moveUp == null)
                    _moveUp = new RelayCommand(MoveUp);
                return _moveUp;
            }
        }

        /// <summary>
        ///     the speed at which the paddle moves
        /// </summary>
        public int MoveSpeed { get; set; }

        /// <summary>
        ///     the thickness of the paddle
        /// </summary>
        public int Thickness { get; set; }

        /// <summary>
        ///     X coordinate of the paddle
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
        ///     Y coordinate of the paddle
        /// </summary>
        public int Y1
        {
            get { return _y1; }
            set
            {
                _y1 = value;
                OnPropertyChanged(nameof(Y1));
                OnPropertyChanged(nameof(Y2));
            }
        }

        /// <summary>
        ///     Y2 returns the value of _y1 plus the value of _length.
        ///     It is read only
        /// </summary>
        public int Y2 => _y1 + _length;

        /// <summary>
        ///     the paddle's location on the playArea (Left Side or Right Side)
        /// </summary>
        public PaddleLocation PaddleLocation;

        /// <summary>
        ///     Event raised when the paddle moves
        /// </summary>
        public event EventHandler PaddleMoved;

        /// <summary>
        ///     Event raised when a property changes.
        ///     Part of the INotifyPropertyChanged interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     backing field for Length property
        /// </summary>
        private int _length;

        /// <summary>
        ///     backing field for MoveDown property
        /// </summary>
        private RelayCommand _moveDown;

        /// <summary>
        ///     backing field for MoveUp property
        /// </summary>
        private RelayCommand _moveUp;

        /// <summary>
        ///     backing field for X property
        /// </summary>
        private int _x;

        /// <summary>
        ///     backing field for Y property
        /// </summary>
        private int _y1;

        /// <summary>
        ///     move the paddle down
        /// </summary>
        /// <param name="sender"></param>
        private void MoveDown(object sender)
        {
            Y1 += MoveSpeed;
            if (PaddleMoved != null) PaddleMoved(this, EventArgs.Empty);
        }

        /// <summary>
        ///     move the paddle up
        /// </summary>
        /// <param name="sender"></param>
        private void MoveUp(object sender)
        {
            Y1 -= MoveSpeed;
            if (PaddleMoved != null) PaddleMoved(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Called when a property changes to raise the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the property that changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}