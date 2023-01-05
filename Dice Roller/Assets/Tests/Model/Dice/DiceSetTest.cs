using System.Collections.Generic;
using NUnit.Framework;

namespace AdventureQuest.Dice
{

    public class DiceGroupTest
    {
        public const int TRIALS = 1_000;

        [Test, Timeout(5000)]
        public void TestParse3D6()
        {
            DiceGroup dice = DiceGroup.Parse("3d6");
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
            DiceGroup dice = DiceGroup.Parse("1d20");
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
            Assert.True(DiceGroup.IsParseable("1d4"));
            Assert.True(DiceGroup.IsParseable("3d6"));
            Assert.True(DiceGroup.IsParseable("20d8"));
            Assert.True(DiceGroup.IsParseable("2d12"));
            Assert.True(DiceGroup.IsParseable("7d20"));
            Assert.True(DiceGroup.IsParseable("1d17"));

            Assert.False(DiceGroup.IsParseable("d4"));
            Assert.False(DiceGroup.IsParseable("d6"));
            Assert.False(DiceGroup.IsParseable("d8"));

            Assert.False(DiceGroup.IsParseable("1d-6"));
            Assert.False(DiceGroup.IsParseable("0d1"));
            Assert.False(DiceGroup.IsParseable("-1d5"));
            Assert.False(DiceGroup.IsParseable("banana"));
            Assert.False(DiceGroup.IsParseable("d5"));
        }

    }
}