using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace CaptainCoder.Dice
{

    public class DiceSetTest
    {
        public const int TRIALS = 1_000;

        [Test, Timeout(5000)]
        public void TestParse3D6()
        {
            DiceSet dice = DiceSet.Parse("3d6");
            Assert.AreEqual(3, dice.Amount);
            Assert.AreEqual(6, dice.Sides);
            Assert.AreEqual(3, dice.Min);
            Assert.AreEqual(18, dice.Max);

            // Roll the die pool 1000 times ensuring the bounds
            List<int> values = new();
            for (int i = 0; i < TRIALS; i++)
            {
                int result = dice.Roll();
                Assert.LessOrEqual(result, dice.Max);
                Assert.GreaterOrEqual(result, dice.Min);
                values.Add(result);
            }

            // Result should contain all values from 3 to 18
            for (int i = dice.Min; i <= dice.Max; i++)
            {
                Assert.Contains(i, values);
            }
        }

        [Test, Timeout(5000)]
        public void TestParse1D20()
        {
            DiceSet dice = DiceSet.Parse("1d20");
            Assert.AreEqual(1, dice.Amount);
            Assert.AreEqual(20, dice.Sides);
            Assert.AreEqual(1, dice.Min);
            Assert.AreEqual(20, dice.Max);

            // Roll the die pool 1000 times ensuring the bounds
            List<int> values = new();
            for (int i = 0; i < TRIALS; i++)
            {
                int result = dice.Roll();
                Assert.LessOrEqual(result, dice.Max);
                Assert.GreaterOrEqual(result, dice.Min);
                values.Add(result);
            }

            // Result should contain all values from 3 to 18
            for (int i = dice.Min; i <= dice.Max; i++)
            {
                Assert.Contains(i, values);
            }
        }

        [Test, Timeout(5000)]
        public void TestIsParseable()
        {
            Assert.True(DiceSet.IsParseable("1d4"));
            Assert.True(DiceSet.IsParseable("3d6"));
            Assert.True(DiceSet.IsParseable("20d8"));
            Assert.True(DiceSet.IsParseable("2d12"));
            Assert.True(DiceSet.IsParseable("7d20"));
            Assert.True(DiceSet.IsParseable("1d17"));

            Assert.False(DiceSet.IsParseable("d4"));
            Assert.False(DiceSet.IsParseable("d6"));
            Assert.False(DiceSet.IsParseable("d8"));

            Assert.False(DiceSet.IsParseable("1d-6"));
            Assert.False(DiceSet.IsParseable("0d1"));
            Assert.False(DiceSet.IsParseable("-1d5"));
            Assert.False(DiceSet.IsParseable("banana"));
            Assert.False(DiceSet.IsParseable("d5"));
        }

    }
}