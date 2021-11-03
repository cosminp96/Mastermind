using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class Print
    {
        /// <summary>
        /// Function that prints a list of ints that represent colors of balls
        /// </summary>
        /// <param name="balls">The list to be printed</param>
        public static void PrintBallList(List<int> balls)
        {
            Console.Write("[");
            for (int i = 0; i < balls.Count; i++)
            {
                if (i != balls.Count - 1)
                    Console.Write(balls[i] + ", ");
                else
                    Console.Write(balls[i]);
            }
            Console.Write("]\n");
        }

        /// <summary>
        /// Function that prints a given state
        /// </summary>
        /// <param name="state">State to be printed</param>
        public static void PrintState(State state, bool isInitialState = false)
        {
            if (isInitialState)
            {
                Console.Clear();
                Print.PrintLogo();
                Console.WriteLine("--------------------");
            }
                
            Console.WriteLine("Try #" + state.TryNumber + " / " + state.Name);
            Console.WriteLine("Is Choosing: " + state.Players.FirstOrDefault(x => x.IsChoosing == true).Name);
            Console.WriteLine("Is Guessing: " + state.Players.FirstOrDefault(x => x.IsChoosing == false).Name);
            Console.WriteLine("Correct Balls List: ");
            PrintBallList(state.CorrectBallsList);
            if (!isInitialState)
            {
                Console.WriteLine("Tried Balls List: ");
                PrintBallList(state.TriedBallsList);
            }
            Console.WriteLine("--------------------");
        }

        /// <summary>
        /// Function that prints the logo of the game.
        /// </summary>
        public static void PrintLogo()
        {
            Console.WriteLine("##########################################################");
            Console.WriteLine("#  __  __           _                      _           _ #");
            Console.WriteLine("# |  \\/  | __ _ ___| |_ ___ _ __ _ __ ___ (_)_ __   __| |#");
            Console.WriteLine("# | |\\/| |/ _` / __| __/ _ \\ '__| '_ ` _ \\| | '_ \\ / _` |#");
            Console.WriteLine("# | |  | | (_| \\__ \\ ||  __/ |  | | | | | | | | | | (_| |#");
            Console.WriteLine("# |_|  |_|\\__,_|___/\\__\\___|_|  |_| |_| |_|_|_| |_|\\__,_|#");
            Console.WriteLine("##########################################################");
        }

        /// <summary>
        /// Function that prints current state for a 2 player game (does not show the correct list)
        /// </summary>
        /// <param name="state">Current state</param>
        public static void PrintStateForTwoPlayers(State state)
        {
            Console.WriteLine("Try #" + state.TryNumber + " / " + state.Name);
            Console.WriteLine("Tried Balls List: ");
            PrintBallList(state.TriedBallsList);
            Console.WriteLine("Matches: " + GameLogic.GetNumberOfMatches(state));
            Console.WriteLine("--------------------");
        }

        /// <summary>
        /// Function that prints the winner player's name
        /// </summary>
        /// <param name="state">Current state</param>
        public static void PrintWinner(State state)
        {
            Player winner = GameLogic.IsFinalState(state);

            if (winner != null)
            {
                Console.WriteLine("The winner is: " + winner.Name);
                Console.WriteLine("Correct sequence:");
                Print.PrintBallList(state.CorrectBallsList);
            }
            else
            {
                Console.WriteLine("No one won yet!");
            }
        }

        /// <summary>
        /// Function that prints the help menu
        /// </summary>
        /// <param name="state">Current state</param>
        public static void PrintHelpMenu(State state)
        {
            Console.Clear();
            Print.PrintLogo();
            Console.WriteLine("This app is an assignment for the Artificial Intelligence class.");
            Console.WriteLine("Read carefully the options as they are self descriptive.");
            Console.Write("Press any key to go back to the menu..."); Console.ReadKey();
            Interface.PrintMenu(state);
        }
    }
}
