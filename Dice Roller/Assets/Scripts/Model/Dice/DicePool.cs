using System.Collections.Generic;

namespace AdventureQuest.Dice
{
    public class DicePool : IRollable
    {

        private readonly List<DiceGroup> _dice;

        /// <summary>
        /// A List containing all of the <see cref="DiceGroup"/>s in this <see
        /// cref="DicePool"/>. Modifying the returned list does not modify this
        /// <see cref="DicePool"/>.
        /// </summary>
        public List<DiceGroup> Dice
        {
            get
            {
                List<DiceGroup> dice = new();
                foreach (DiceGroup set in _dice)
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
                foreach (DiceGroup group in _dice)
                {
                    min += group.Min;
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
                foreach (DiceGroup set in _dice)
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
        public DicePool(List<DiceGroup> dice)
        {
            if (dice == null) throw new System.ArgumentNullException($"DicePool must contain at least 1 dice set.");
            if (dice.Count < 1) throw new System.ArgumentException($"DicePool must have at least 1 dice set.");

            _dice = new List<DiceGroup>();
            foreach (DiceGroup set in dice)
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
            foreach (DiceGroup set in _dice)
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
            foreach (DiceGroup set in _dice)
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
            List<DiceGroup> dice = new();
            foreach (string token in tokens)
            {
                dice.Add(DiceGroup.Parse(token));
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
                if (!DiceGroup.IsParseable(token))
                {
                    return false;
                }
            }
            return true;
        }
    }
}