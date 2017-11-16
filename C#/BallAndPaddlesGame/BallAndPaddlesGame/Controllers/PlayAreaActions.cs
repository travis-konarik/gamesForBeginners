using System;
using System.Threading;
using BallAndPaddlesGame.Models;

namespace BallAndPaddlesGame.Controllers
{
    /// <summary>
    ///     Actions made by or made on the playarea
    /// </summary>
    internal static class PlayAreaActions
    {
        /// <summary>
        ///     Setup the playArea
        /// </summary>
        /// <param name="playArea"></param>
        public static void Setup(ref PlayArea playArea)
        {
            // run the playArea initializer
            InitializePlayField(ref playArea);
        }

        /// <summary>
        ///     Initialize the play area's border and field
        /// </summary>
        /// <param name="playArea">the playArea</param>
        private static void InitializePlayField(ref PlayArea playArea)
        {
            // iterate through all the rows in the play area
            for (var row = 0; row < playArea.Height; row++)
                // iterate through all the columns in the row
            for (var column = 0; column < playArea.Width; column++)
                // if the cell is on the very top, left, bottom, or right of the play area
                if (row == 0 || column == 0 || row == playArea.Height - 1 || column == playArea.Width - 1)
                    playArea.PlayField[row, column] = '#';
                // otherwise
                else
                    playArea.PlayField[row, column] = ' ';
        }

        /// <summary>
        ///     Draw the field and controll the speed of play
        /// </summary>
        /// <param name="playArea">the playArea</param>
        public static void Play(ref PlayArea playArea)
        {
            // draw the field
            DrawField(ref playArea);
            // wait 200 miliseconds before continuing again
            Thread.Sleep(200);
        }

        /// <summary>
        ///     Draw the field on the console
        /// </summary>
        /// <param name="playArea"></param>
        private static void DrawField(ref PlayArea playArea)
        {
            // iterate through the rows in the play area
            for (var row = 0; row < playArea.Height; row++)
            {
                // start a blank string
                var output = "";

                // iterate through the columns in the play area
                for (var column = 0; column < playArea.Width; column++)
                    // add the character to the output string
                    output += (char) playArea.PlayField[row, column];
                // write the string to the console
                Console.WriteLine(output);
            }
        }

        /// <summary>
        ///     Clean up the console and post the ending message
        /// </summary>
        public static void CleanUp()
        {
            // remove the contents of the console
            Console.Clear();
            // write lines to the console
            Console.WriteLine("Thanks For Playing.");
            Console.WriteLine("Press any key to close.");
            // wait for the user to press and key before closing the program
            Console.ReadKey();
        }

        /// <summary>
        ///     Remove the contents of the console and place a new blank playArea
        /// </summary>
        /// <param name="playArea"></param>
        public static void ClearField(ref PlayArea playArea)
        {
            // remove the contents of the console
            Console.Clear();
            // run the playArea initializer
            InitializePlayField(ref playArea);
        }
    }
}