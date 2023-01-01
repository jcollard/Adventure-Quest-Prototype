
using System.Collections.Generic;

namespace CaptainCoder.Data
{
    /// <summary>
    /// A <see cref="Histogram"/> represents a probability distribution over a set of elements.
    /// </summary>
    public class Histogram
    {

        private int _min = int.MaxValue;
        private int _max = int.MinValue;
        private int? _mostLikely = null;
        private readonly Dictionary<int, int> _counts;

        /// <summary>
        /// Instantiates a <see cref="Histogram"/> representing the probability distribution of the given <paramref name="elements"/>.
        /// The <paramref name="elements"/> must contain at least one element.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"/> 
        /// <exception cref="System.ArgumentException">Thrown if <paramref name="elements"/> has fewer than one element.</exception>
        public Histogram(List<int> elements)
        {
            if (elements == null) throw new System.ArgumentNullException("Cannot construct histogram with null data set.");
            if (elements.Count < 1) throw new System.ArgumentException("Histogram must have at least one data point.");
            Count = elements.Count;
            _counts = BuildHistogram(elements);
        }

        /// <summary>
        /// The minimum value found within all elements of this <see cref="Histogram"/>
        /// </summary>
        public int Min
        {
            get
            {
                if (_min == int.MaxValue)
                {
                    foreach (int value in _counts.Keys)
                    {
                        if (value < _min)
                        {
                            _min = value;
                        }
                    }
                }
                return _min;
            }
        }

        /// <summary>
        /// The maximum value found within all elements of this <see cref="Histogram"/>.
        /// </summary>
        public int Max
        {
            get
            {
                if (_max == int.MinValue)
                {
                    foreach (int value in _counts.Keys)
                    {
                        if (value > _max)
                        {
                            _max = value;
                        }
                    }
                }
                return _max;
            }
        }

        /// <summary>
        /// The most likely element to be selected at random
        /// </summary>
        public int MostLikelyElement
        {
            get
            {
                if (_mostLikely == null)
                {
                    float maxPercentage = float.MinValue;
                    foreach (int value in _counts.Keys)
                    {
                        float percentage = ChanceOf(value);
                        if (percentage > maxPercentage)
                        {
                            maxPercentage = percentage;
                            _mostLikely = value;
                        }
                    }
                    
                }
                return _mostLikely.Value;
            }
        }

        /// <summary>
        /// The total number of elements used to calculate this <see cref="Histogram"/>.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Given a <paramref name="value"/> returns the chance of randomly selecting
        /// that value from within this <see cref="Histogram"/>
        /// </summary>
        public float ChanceOf(int value)
        {
            if (!_counts.ContainsKey(value))
            {
                return 0;
            }
            return _counts[value] / (float)Count;
        }

        private static Dictionary<int, int> BuildHistogram(List<int> data)
        {
            Dictionary<int, int> counts = new();
            foreach (int value in data)
            {
                if (!counts.ContainsKey(value))
                {
                    counts[value] = 1;
                }
                else
                {
                    counts[value]++;
                }
            }
            return counts;
        }

    }
}