using UnityEngine;

namespace CaptainCoder.Dice
{
    [System.Serializable]
    public class Die
    {
        /// <summary>
        /// The number of sides on this <see cref="Die"/>
        /// </summary>
        public int Sides { get; private set; }

        /// <summary>
        /// The last value that was rolled on this die. If this <see cref="Die"/>
        /// has not been rolled, the last rolled value is 1.
        /// </summary>
        public int LastRoll { get; private set; } = 1;

        /// <summary>
        /// Instantiate a "fair" <see cref="Die"/> with the specified number of sides. Sides must be
        /// a value greater than 1.
        /// </summary>
        public Die(int sides)
        {
            if (sides < 2) throw new System.ArgumentException("A die must have at least 2 sides.");
            this.Sides = sides;
        }

        /// <summary>
        /// Rolls this Die and selects a side uniformly at random.
        /// </summary>
        public int Roll()
        {
            LastRoll = Random.Range(1, Sides + 1);
            return LastRoll;
        }

        public override string ToString()
        {
            return $"d{Sides}";
        }

        /// <summary>
        /// Parses a string of the format "d{int}" into a Die. For example,
        /// Die.Parse("d6") results in a 6 sided die and Die.Parse("d2") results
        /// in a 2 sided Die. If the string is not in the correct format, throws
        /// an ArgumentException
        /// </summary>
        public static Die Parse(string toParse)
        {
            string clean = toParse.Trim().ToLower();
            if (!IsParseable(toParse)) throw new System.FormatException($"Could not parse \"{toParse}\" as a die.");
            int sides = int.Parse(clean[1..]);
            return new Die(sides);
        }

        /// <summary>
        /// Checks if <paramref name="toParse"/> is in a die format.
        /// </summary>
        public static bool IsParseable(string toParse)
        {
            string clean = toParse.Trim().ToLower();
            if (clean == string.Empty || clean[0] != 'd') return false;
            clean = clean[1..];
            if (!int.TryParse(clean, out int sides)) return false;
            if (sides < 2) return false;
            return true;
        }

    }
}