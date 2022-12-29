using System.Collections.Generic;

namespace CaptainCoder.Dice
{
    public class DicePool
    {

        private readonly List<DiceSet> _dice;

        /// <summary>
        /// A List containing all of the <see cref="DiceSet"/>s in this <see
        /// cref="DicePool"/>. Modifying the returned list does not modify this
        /// <see cref="DicePool"/>.
        /// </summary>
        public List<DiceSet> Dice
        {
            get
            {
                List<DiceSet> dice = new();
                foreach (DiceSet set in _dice)
                {
                    dice.Add(set);
                }
                return dice;
            }
        }

        /// <summary>
        /// The minimum value that can be rolled by this <see cref="DicePool"/>.
        /// </summary>
        public int Min
        {
            get
            {
                int min = 0;
                foreach (DiceSet set in _dice)
                {
                    min += set.Min;
                }
                return min;
            }
        }

        /// <summary>
        /// The maximum value that can be rolled by this <see cref="DicePool"/>.
        /// </summary>
        public int Max
        {
            get
            {
                int max = 0;
                foreach (DiceSet set in _dice)
                {
                    max += set.Max;
                }
                return max;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dice"></param>
        public DicePool(List<DiceSet> dice)
        {
            if (dice == null) throw new System.ArgumentNullException($"DicePool must contain at least 1 dice set.");
            if (dice.Count < 1) throw new System.ArgumentException($"DicePool must have at least 1 dice set.");

            _dice = new List<DiceSet>();
            foreach (DiceSet set in dice)
            {
                _dice.Add(set);
            }
        }

        /// <summary>
        /// Rolls all of the dice and returns the sum.
        /// </summary>
        public int Roll()
        {
            int sum = 0;
            foreach (DiceSet set in _dice)
            {
                sum += set.Roll();
            }
            return sum;
        }

        /// <summary>
        /// Returns a list containing the value of each die.
        /// </summary>
        public List<int> LastRoll()
        {
            List<int> rolls = new();
            foreach (DiceSet set in _dice)
            {
                rolls.AddRange(set.LastRoll());
            }
            return rolls;
        }

        public override string ToString() => string.Join(" + ", _dice);

        /// <summary>
        /// Parses <paramref name="toParse"/> and returns a <see
        /// cref="DicePool"/> instance. If the string is not in the correct
        /// format, a FormatException is thrown.
        /// </summary>
        public static DicePool Parse(string toParse)
        {
            if (!IsParseable(toParse)) throw new System.FormatException($"Could not parse \"{toParse}\" as a DiceSet.");
            string[] tokens = toParse.Split("+");
            List<DiceSet> dice = new();
            foreach (string token in tokens)
            {
                dice.Add(DiceSet.Parse(token));
            }
            return new DicePool(dice);
        }

        /// <summary>
        /// Checks if <paramref name="toParse"/> is parseable as a DicePool.
        /// </summary>
        public static bool IsParseable(string toParse)
        {
            string[] tokens = toParse.Split("+");
            if (tokens.Length < 1) return false;
            foreach (string token in tokens)
            {
                if (!DiceSet.IsParseable(token))
                {
                    return false;
                }
            }
            return true;
        }
    }
}