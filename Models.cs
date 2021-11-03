using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsChoosing { get; set; }
        public Player(int id, string name, bool isChoosing)
        {
            ID = id;
            Name = name;
            IsChoosing = isChoosing;
        }
    }

    public class State
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<int> CorrectBallsList { get; set; }
        public List<int> TriedBallsList { get; set; }
        public int TryNumber { get; set; }
        public int MaximumNumberOfTries { get; set; }
        public int NumberOfEachColor { get; set; }
        public int NumberOfDifferentColors { get; set; }
        public State() { Players = new List<Player>(); CorrectBallsList = new List<int>(); TriedBallsList = new List<int>(); }
        public State(string name)
        {
            Name = name;
            Players = new List<Player>();
            CorrectBallsList = new List<int>();
            TriedBallsList = new List<int>();
            TryNumber = 0;
            MaximumNumberOfTries = 0;
        }
    }
}
