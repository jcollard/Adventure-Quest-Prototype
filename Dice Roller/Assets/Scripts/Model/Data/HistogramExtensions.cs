using System.Collections.Generic;
using AdventureQuest.Dice;

namespace AdventureQuest.Data
{
    public static class HistogramExtensions
    {
        public static Histogram Histogram(this DicePool pool, int trials = 10_000)
        {
            if (pool == null) throw new System.ArgumentNullException("Cannot create histogram with a null DicePool.");
            if (trials < 1) throw new System.ArgumentException($"Must have at least 1 trial to construct histogram but was {trials}");
            List<int> elements = new ();
            for (int i = 0; i < trials; i++)
            {
                elements.Add(pool.Roll());
            }
            return new Histogram(elements);
        }
    }
}