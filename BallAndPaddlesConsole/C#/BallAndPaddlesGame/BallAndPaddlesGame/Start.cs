using System;
using System.Threading;
using BallAndPaddlesGame.Controllers;

namespace BallAndPaddlesGame
{
    /// <summary>
    ///     Start is the beginning of the project
    /// </summary>
    internal class Start
    {
        /// <summary>
        ///     Main is the method that is called automatically upon executing the application.
        /// </summary>
        /// <param name="args">Not needed for this project</param>
        private static void Main(string[] args)
        {
            var ctrl = new Controller();

            // as long as the game has not ended, keep running this loop
            while (ctrl.Running)
            {
                ctrl.DrawPlayField();
                Console.Clear();
                PrintPlayFieldToScreen(ctrl);
                Thread.Sleep(200);
                MovePaddles(ctrl);
                ctrl.MoveBall();
            }

            // remove the contents of the console
            Console.Clear();
            // write lines to the console
            Console.WriteLine("Thanks For Playing.");
            Console.WriteLine("Press any key to close.");
            // wait for the user to press and key before closing the program
            Console.ReadKey();
        }

        /// <summary>
        ///     Check for key presses and move the padddles
        /// </summary>
        /// <param name="ctrl">Application Controller</param>
        private static void MovePaddles(Controller ctrl)
        {
            // check and see if a key was pressed
            if (Console.KeyAvailable)
                // multiple key presses will queue
                // using this will process all queued key presses for the cycle
                while (Console.KeyAvailable)
                {
                    // get the next key in from the queue
                    ConsoleKey? key = Console.ReadKey(true).Key;
                    ctrl.MovePaddle(key);
                }
        }

        /// <summary>
        ///     Print the Game to the Console
        /// </summary>
        /// <param name="ctrl">Application Controller</param>
        private static void PrintPlayFieldToScreen(Controller ctrl)
        {
            for (var row = 0; row < ctrl.PlayFieldHeight; row++)
            {
                // start a blank string
                var output = "";

                // iterate through the columns in the play area
                for (var column = 0; column < ctrl.PlayFieldWidth; column++)
                    // add the character to the output string
                    output += ctrl.PlayField[row, column];
                // write the string to the console
                Console.WriteLine(output);
            }
        }
    }
}