using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BallAndPaddlesGameWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // initiallizing the components of the game
//            var leftPaddle = new Paddle(PaddleLocation.Left, 4);
//            var rightPaddle = new Paddle(PaddleLocation.Right, 4);
//            var ball = new Ball(13, 13);
//            // running is a boolean that we check to see if the game has ended
//            var running = true;
//
//            // setup the movement keys and length of the left paddle
//            leftPaddle.UpMovementKey = ConsoleKey.W;
//            leftPaddle.DownMovementKey = ConsoleKey.S;
//            leftPaddle.Length = 5;
//
//            // setup the movement keys and length of the right paddle
//            rightPaddle.UpMovementKey = ConsoleKey.UpArrow;
//            rightPaddle.DownMovementKey = ConsoleKey.DownArrow;
//            rightPaddle.Length = 5;
//
//            // setup the playArea
//            PlayAreaActions.Setup(ref playArea);
//
//            // as long as the game has not ended, keep running this loop
//            while (running)
//            {
//                // check and see if a key was pressed
//                if (Console.KeyAvailable)
//                    // multiple key presses will queue
//                    // using this will process all queued key presses for the cycle
//                    while (Console.KeyAvailable)
//                    {
//                        // get the next key in from the queue
//                        ConsoleKey? key = Console.ReadKey(true).Key;
//                        // move the left paddle
//                        PaddleActions.Move(ref playArea, leftPaddle, key);
//                        // move the right paddle
//                        PaddleActions.Move(ref playArea, rightPaddle, key);
//                    }
//
//                // clear the play area
//                PlayAreaActions.ClearField(ref playArea);
//
//                // moving the paddle without a key press, "null", will correct the paddle's position in the play area
//                PaddleActions.Move(ref playArea, leftPaddle, null);
//                PaddleActions.Move(ref playArea, rightPaddle, null);
//
//                // move the ball. if the ball goes out of bounds, this will return false and end the game
//                running = BallActions.Move(ref playArea, ball, leftPaddle, rightPaddle);
//
//                // draw the play area including the paddles and the ball
//                PlayAreaActions.Play(ref playArea);
//            }
//
//            // remove the playArea from the view and 
//            PlayAreaActions.CleanUp();
        }
    }
}
