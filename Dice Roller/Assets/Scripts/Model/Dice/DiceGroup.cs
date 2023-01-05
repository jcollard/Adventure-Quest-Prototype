using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.Dice
{
    public class DiceGroup : IRollable
    {
        private readonly List<Die> _dice;

        /// <summary>
        /// Instantiates a DiceSet containing <paramref name="amount"/> dice
        /// each with the specified number of <paramref name="sides"/>.
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// If amount is less than 1 or sides is less than 2.
        /// </exception>
        public DiceGroup(int amount, int sides)
        {
            if (amount < 1) throw new System.ArgumentException($"DiceSet must contain at least 1 die but was {amount}.");
            if (sides < 2) throw new System.ArgumentException($"DiceSet must have at least 2 sides but was {sides}.");
            _dice = new List<Die>();
            for (int i = 0; i < amount; i++)
            {
                _dice.Add(new Die(sides));
            }
        }

        /// <summary>
        /// The number of dice
        /// </summary>
        public int Amount => _dice.Count;
        /// <summary>
        /// The number of sides on each die.
        /// </summary>
        public int Sides => _dice[0].Sides;
        /// <summary>
        /// The minimum value that can be rolled by this <see cref="DiceGroup"/>.
        /// </summary>
        public int Min => Amount;
        /// <summary>
        /// The maximum value that can be rolled by this <see cref="DiceGroup"/>.
        /// </summary>
        public int Max => Sides * Amount;
        

        /// <summary>
        /// Rolls all of the dice and returns the sum.
        /// </summary>
        public int Roll()
        {
            int sum = 0;
            foreach (Die d in _dice)
            {
                sum += d.Roll();
            }
            return sum;
        }

        /// <summary>
        /// Returns a list containing the value of each die.
        /// </summary>
        public List<int> LastRoll()
        {
            List<int> rolls = new ();
            foreach (Die d in _dice)
            {
                rolls.Add(d.LastRoll);
            }
            return rolls;
        }
        
        public override string ToString() => $"{Amount}d{Sides}";

        /// <summary>
        /// Parses <paramref name="toParse"/> as a DiceSet. If the string is
        /// not in the correct format, a FormatException is thrown.
        /// </summary>
        public static DiceGroup Parse(string toParse)
        {
            if (!IsParseable(toParse)) throw new System.FormatException($"Could not parse \"{toParse}\" as a DiceSet. Expected format {{amount}}d{{sides}}.");
            string[] tokens = toParse.Trim().Split('d');
            return new DiceGroup(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }

        /// <summary>
        /// Checks if <paramref name="toParse"/> is parseable. A
        /// valid string is in the format {amount}d{sides} such that amount >= 1
        /// and sides >= 2.
        /// </summary>
        public static bool IsParseable(string toParse)
        {
            string[] tokens = toParse.Trim().Split('d');
            if (tokens.Length != 2) return false;
            if (!int.TryParse(tokens[0], out int amount)) return false;
            if (!int.TryParse(tokens[1], out int sides)) return false;
            if (amount < 1) return false;
            if (sides < 2) return false;
            return true;
        }
                
    }
}