using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Print.PrintLogo();

            // Initializing game
            Random random = new Random();
            int numberOfDifferentColors = 0;
            int numberOfBallsOfEachColor = 0;
            int selectedBallsNumber = 0;
            Interface.InitialUserQueries(ref numberOfDifferentColors, ref numberOfBallsOfEachColor, ref selectedBallsNumber);

            // Initializing state
            State state = GameLogic.GetInitialState(numberOfDifferentColors, numberOfBallsOfEachColor, selectedBallsNumber);

            // Printing the menu
            Interface.PrintMenu(state);
        }
    }
}
