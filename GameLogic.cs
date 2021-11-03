using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class GameLogic
    {
        /// <summary>
        /// Function that creates and returns the initial state.
        /// </summary>
        /// <param name="numberOfDifferentColors">n from the problem text</param>
        /// <param name="numberOfBallsOfEachColor">m from the problem text</param>
        /// <param name="selectedBallsNumber">k from the problem text</param>
        /// <returns></returns>
        public static State GetInitialState(int numberOfDifferentColors, int numberOfBallsOfEachColor, int selectedBallsNumber, bool computerSelectsBalls = true)
        {
            Random random = new Random();
            State initState = new State("State0");
            initState.Players.Add(new Player(1, "A", true));
            initState.Players.Add(new Player(2, "B", false));
            initState.MaximumNumberOfTries = 2 * numberOfDifferentColors;
            initState.NumberOfEachColor = numberOfBallsOfEachColor;
            initState.NumberOfDifferentColors = numberOfDifferentColors;
            if (computerSelectsBalls)
            {
                initState.CorrectBallsList = GetRandomBallsList(numberOfDifferentColors, selectedBallsNumber, random.Next());
            }
            else
            {
                Interface.GetCorrectBallsListFromUser(initState, selectedBallsNumber);
            }
            return initState;
        }

        /// <summary>
        /// Function that gets a random TRY or a list of length=selectedBallsNumber of random ints, each representing a color, the maximum value being numberOfDifferentColors - 1
        /// </summary>
        /// <param name="numberOfDifferentColors">Number of choices of colors</param>
        /// <param name="selectedBallsNumber">Size of returned list</param>
        /// <param name="seed">Seed for generating the random number</param>
        /// <returns></returns>
        public static List<int> GetRandomBallsList(int numberOfDifferentColors, int selectedBallsNumber, int seed = 0)
        {
            Random rnd = new Random(seed);
            List<int> ballsList = new List<int>();

            for (int i = 0; i < selectedBallsNumber; i++)
            {
                ballsList.Add(rnd.Next(0, numberOfDifferentColors));
            }

            return ballsList;
        }

        /// <summary>
        /// Function that checks if a given state is a final state.
        /// </summary>
        /// <param name="state">State to check</param>
        /// <returns></returns>
        public static Player IsFinalState(State state)
        {
            var guessingPlayer = state.Players.FirstOrDefault(x => x.IsChoosing == false);
            var choosingPlayer = state.Players.FirstOrDefault(x => x.IsChoosing == true);

            if (state.TriedBallsList.Any(x => x >= state.NumberOfDifferentColors))
                return null;

            var countOfEachColor = state.TriedBallsList.GroupBy(x => x);
            foreach (var color in countOfEachColor)
            {
                if (color.Count() > state.NumberOfEachColor)
                    return null;
            }

            if (state.TryNumber < state.MaximumNumberOfTries)
            {
                if (GetNumberOfMatches(state) == 4)
                    return guessingPlayer;
            }
            else
            {
                return choosingPlayer;
            }

            return null;
        }

        /// <summary>
        /// Function that compares the correct balls list from a state with the tried balls list from the state and returns the number of matches.
        /// </summary>
        /// <param name="state">The current state object</param>
        /// <returns>Number of matches between the try and the pattern to be guessed.</returns>
        public static int GetNumberOfMatches(State state)
        {
            int count = 0;

            for (int i = 0; i < state.CorrectBallsList.Count; i++)
            {
                if (state.CorrectBallsList[i] == state.TriedBallsList[i])
                    count++;
            }

            return count;
        }
    }
}
