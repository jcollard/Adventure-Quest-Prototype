using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

namespace CaptainCoder.Dice
{

    public class DicePoolTest
    {
        public const int TRIALS = 10_000;

        [Test, Timeout(5000)]
        public void TestParse2D4Plus1D6()
        {
            DicePool pool = DicePool.Parse("2d4 + 1d6");
            Assert.AreEqual(2, pool.Dice.Count);
            Assert.AreEqual("2d4 + 1d6", pool.ToString());
            Assert.AreEqual(3, pool.Min);
            Assert.AreEqual(14, pool.Max);

            // Roll the die pool 1000 times ensuring the bounds
            HashSet<int> values = new();
            for (int i = 0; i < TRIALS; i++)
            {
                int result = pool.Roll();
                Assert.LessOrEqual(result, pool.Max);
                Assert.GreaterOrEqual(result, pool.Min);
                values.Add(result);
            }

            // Result should contain all values in the range
            for (int i = pool.Min; i <= pool.Max; i++)
            {
                Assert.True(values.Contains(i));
            }
        }

        [Test, Timeout(5000)]
        public void TestParse1D20()
        {
            DicePool pool = DicePool.Parse("1d20");
            Assert.AreEqual(1, pool.Dice.Count);
            Assert.AreEqual("1d20", pool.ToString());
            Assert.AreEqual(1, pool.Min);
            Assert.AreEqual(20, pool.Max);

            // Roll the die pool 1000 times ensuring the bounds
            HashSet<int> values = new();
            for (int i = 0; i < TRIALS; i++)
            {
                int result = pool.Roll();
                Assert.LessOrEqual(result, pool.Max);
                Assert.GreaterOrEqual(result, pool.Min);
                values.Add(result);
            }

            // Result should contain all values from 3 to 18
            for (int i = pool.Min; i <= pool.Max; i++)
            {
                Assert.True(values.Contains(i));
            }
        }

        [Test, Timeout(5000)]
        public void TestParse3D6Plus1D4Plus3D8()
        {
            DicePool pool = DicePool.Parse("1d6 + 1d4 + 1d8");
            Assert.AreEqual(3, pool.Dice.Count);
            Assert.AreEqual("1d6 + 1d4 + 1d8", pool.ToString());
            Assert.AreEqual(3, pool.Min);
            Assert.AreEqual(18, pool.Max);

            // Roll the die pool 1000 times ensuring the bounds
            HashSet<int> values = new();
            for (int i = 0; i < TRIALS; i++)
            {
                int result = pool.Roll();
                Assert.LessOrEqual(result, pool.Max);
                Assert.GreaterOrEqual(result, pool.Min);
                values.Add(result);
            }

            // Result should contain all values from 3 to 14
            for (int i = pool.Min; i <= pool.Max; i++)
            {
                Assert.True(values.Contains(i));
            }
        }

        [Test, Timeout(5000)]
        public void TestIsParseable()
        {
            Assert.True(DicePool.IsParseable("1d4"));
            Assert.True(DicePool.IsParseable("3d6"));
            Assert.True(DicePool.IsParseable("20d8"));
            Assert.True(DicePool.IsParseable("2d12"));
            Assert.True(DicePool.IsParseable("7d20"));
            Assert.True(DicePool.IsParseable("1d17"));

            Assert.True(DicePool.IsParseable("1d4 + 5d6"));
            Assert.True(DicePool.IsParseable("3d6 + 2d9 + 7d8"));
            Assert.True(DicePool.IsParseable("20d8+1d4+3d9     +    7d5"));
            Assert.True(DicePool.IsParseable("    2d12 + 4d9      "));
            Assert.True(DicePool.IsParseable("7d20  + 1d6 + 2d3"));


            Assert.False(DicePool.IsParseable("d4"));
            Assert.False(DicePool.IsParseable("d6"));
            Assert.False(DicePool.IsParseable("d8"));

            Assert.False(DicePool.IsParseable("1d-6"));
            Assert.False(DicePool.IsParseable("0d1"));
            Assert.False(DicePool.IsParseable("-1d5"));
            Assert.False(DicePool.IsParseable("banana"));
            Assert.False(DicePool.IsParseable("d5"));
        }

    }
}