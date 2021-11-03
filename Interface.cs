using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class Interface
    {
        #region Initial Input
        
        /// <summary>
        /// Function that gets from the user input the number of different colors
        /// </summary>
        /// <param name="numberOfDifferentColors"></param>
        public static void GetNumberOfDifferentColors(ref int numberOfDifferentColors)
        {
            try
            {
                Console.Clear();
                Print.PrintLogo();
                Console.WriteLine("Insert number of different colors:");
                var input = Console.ReadLine();

                if (!Int32.TryParse(input, out numberOfDifferentColors)) throw new Exception("Incorrect value for numberOfDifferentColors");
            }
            catch (Exception e)
            {
                GetNumberOfDifferentColors(ref numberOfDifferentColors);
            }
        }

        /// <summary>
        /// Function that gets from the user input the number of balls of each color
        /// </summary>
        /// <param name="numberOfBallsOfEachColor"></param>
        public static void GetNumberOfBallsOfEachColor(ref int numberOfBallsOfEachColor)
        {
            try
            {
                Console.Clear();
                Print.PrintLogo();
                Console.WriteLine("Insert number of balls of each color:");
                var input = Console.ReadLine();

                if (!Int32.TryParse(input, out numberOfBallsOfEachColor)) throw new Exception("Incorrect value for numberOfBallsOfEachColor");
            }
            catch (Exception e)
            {
                GetNumberOfBallsOfEachColor(ref numberOfBallsOfEachColor);
            }
        }

        /// <summary>
        /// Function that gets from the user input the number of selected balls
        /// </summary>
        /// <param name="selectedBallsNumber"></param>
        public static void GetNumberOfSelectedBalls(ref int selectedBallsNumber)
        {
            try
            {
                Console.Clear();
                Print.PrintLogo();
                Console.WriteLine("Insert number of selected balls:");
                var input = Console.ReadLine();

                if (!Int32.TryParse(input, out selectedBallsNumber)) throw new Exception("Incorrect value for selectedBallsNumber");
            }
            catch (Exception e)
            {
                GetNumberOfSelectedBalls(ref selectedBallsNumber);
            }
        }

        /// <summary>
        /// Get user input for the number of different colors, number of balls of each color and number of selected balls
        /// </summary>
        /// <param name="numberOfDifferentColors">n from the problem text</param>
        /// <param name="numberOfBallsOfEachColor">m from the problem text</param>
        /// <param name="selectedBallsNumber">k from the problem text</param>
        public static void InitialUserQueries(ref int numberOfDifferentColors, ref int numberOfBallsOfEachColor, ref int selectedBallsNumber)
        {
            GetNumberOfDifferentColors(ref numberOfDifferentColors);
            GetNumberOfBallsOfEachColor(ref numberOfBallsOfEachColor);
            GetNumberOfSelectedBalls(ref selectedBallsNumber);
        }

        #endregion

        #region Menu + Input Methods

        /// <summary>
        /// Function that prints the menu of the game.
        /// </summary>
        public static void PrintMenu(State state)
        {
            Console.Clear();
            Print.PrintLogo();
            Console.WriteLine("1. Random guess");
            Console.WriteLine("2. Play vs Computer Selected Balls");
            Console.WriteLine("3. Play vs Human Selected Balls");
            Console.WriteLine("4. Help");

            var input = Console.ReadLine();
            ProcessCommand(state, input);
        }

        /// <summary>
        /// Function that processes commands for menu
        /// </summary>
        /// <param name="state">Current state</param>
        /// <param name="input">Slected choice input</param>
        public static void ProcessCommand(State state, string input)
        {
            Random random = new Random();
            if (CheckForExitCommand(input))
            {
                Environment.Exit(-1);
            }

            switch (input)
            {
                case "1":
                    state.TriedBallsList = GameLogic.GetRandomBallsList(state.NumberOfDifferentColors, state.CorrectBallsList.Count, random.Next());
                    Print.PrintState(state);
                    if (GameLogic.IsFinalState(state) != null) Print.PrintWinner(state);
                    Console.Write("Press any key to go back to main menu."); Console.ReadKey();
                    PrintMenu(state);
                    break;
                case "2":
                    while (state.TryNumber < state.MaximumNumberOfTries)
                    {
                        Interface.GetInputFromUser(state);
                        Print.PrintStateForTwoPlayers(state);
                        state.TryNumber++;
                        if (GameLogic.IsFinalState(state) != null)
                        {
                            break;
                        }
                    }
                    Print.PrintWinner(state);
                    break;
                case "3":
                    state = GameLogic.GetInitialState(state.NumberOfDifferentColors, state.NumberOfEachColor, state.CorrectBallsList.Count, false);
                    Console.Clear();
                    Print.PrintLogo();
                    while (state.TryNumber < state.MaximumNumberOfTries)
                    {
                        Interface.GetInputFromUser(state);
                        Print.PrintStateForTwoPlayers(state);
                        state.TryNumber++;
                        if (GameLogic.IsFinalState(state) != null)
                        {
                            break;
                        }
                    }
                    Print.PrintWinner(state);
                    break;
                case "4":
                    Print.PrintHelpMenu(state);
                    break;
                default:
                    ProcessCommand(state, input);
                    break;
            }
        }

        /// <summary>
        /// Function that takes the input guess from user.
        /// </summary>
        /// <param name="state">Current state</param>
        public static void GetInputFromUser(State state)
        {
            try
            {
                state.TriedBallsList.Clear();
                Console.WriteLine("Insert try #" + state.TryNumber + " : (e.g. '0,1,2,3')");
                var input = Console.ReadLine();
                Console.WriteLine("--------------------");
                if (CheckForExitCommand(input))
                {
                    PrintMenu(state);
                    return;
                }
                var values = input.Split(',');

                for (int i = 0; i < state.CorrectBallsList.Count; i++)
                {
                    int ball = 0;
                    if (!Int32.TryParse(values[i].Trim(), out ball)) throw new Exception("Incorrect value");
                    if (ball >= state.NumberOfDifferentColors) throw new Exception("Incorrect color value");
                    state.TriedBallsList.Add(ball);
                }
            }
            catch (Exception e)
            {
                state.TriedBallsList.Clear();
                GetInputFromUser(state);
            }
        }

        /// <summary>
        /// Function that from the user input the correct list of balls
        /// </summary>
        /// <param name="state">Current state</param>
        /// <param name="selectedBallsNumber">Number of balls / try</param>
        public static void GetCorrectBallsListFromUser(State state, int selectedBallsNumber)
        {
            try
            {
                Console.WriteLine("Insert Correct Numbers : (e.g. '0,1,2,3')");
                var input = Console.ReadLine();
                Console.WriteLine("--------------------");
                if (CheckForExitCommand(input))
                {
                    PrintMenu(state);
                    return;
                }
                var values = input.Split(',');

                for (int i = 0; i < selectedBallsNumber; i++)
                {
                    int ball = 0;
                    if (!Int32.TryParse(values[i].Trim(), out ball)) throw new Exception("Incorrect value");
                    if (ball >= state.NumberOfDifferentColors) throw new Exception("Incorrect color value");
                    state.CorrectBallsList.Add(ball);
                }
            }
            catch (Exception e)
            {
                state.CorrectBallsList.Clear();
                GetInputFromUser(state);
            }
        }

        /// <summary>
        /// Function that checks if the input is "exit" in order to allow the user to exit the app
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns></returns>
        public static bool CheckForExitCommand(string input)
        {
            if (input.ToLower().Trim() == "exit")
                return true;
            return false;
        }
        
        #endregion
    }
}
