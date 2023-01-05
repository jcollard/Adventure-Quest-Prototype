using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AdventureQuest.Dice
{

    public class DieTest
    {
        public const int TRIALS = 1_000;

        [Test, Timeout(5000)]
        public void TestDieMinimumSize()
        {
            // A die must have at least 2 sides
            Assert.Throws<System.ArgumentException>(() => new Die(0));
            Assert.Throws<System.ArgumentException>(() => new Die(-1));
            Assert.Throws<System.ArgumentException>(() => new Die(1));
        }

        [Test, Timeout(5000)]
        public void TestConstruct6SidedDie()
        {
            // Construct a 6 sided die
            Die d6 = new (6);

            // Before rolling, the die should have a 1 on its face
            Assert.AreEqual(1, d6.LastRoll);

            // A 6 sided die should have 6 sides
            Assert.AreEqual(6, d6.Sides);

            // Roll this die 1,000 times and make sure it is always a value
            // between 1 and 6.
            List<int> values = new();
            for (int i = 0; i < TRIALS; i++)
            {
                int result = d6.Roll();
                Assert.AreEqual(result, d6.LastRoll);
                Assert.LessOrEqual(result, 6);
                Assert.GreaterOrEqual(result, 1);
                values.Add(result);
            }

            // Check that each result was rolled
            Assert.Contains(1, values);
            Assert.Contains(2, values);
            Assert.Contains(3, values);
            Assert.Contains(4, values);
            Assert.Contains(5, values);
            Assert.Contains(6, values);
        }

        [Test, Timeout(5000)]
        public void TestConstruct12SidedDie()
        {
            // Construct a 12 sided die
            Die d12 = new (12);

            // Before rolling, the die should have a 1 on its face
            Assert.AreEqual(1, d12.LastRoll);

            // A 6 sided die should have 6 sides
            Assert.AreEqual(12, d12.Sides);

            // Roll this die 1,000 times and make sure it is always a value
            // between 1 and 12.
            List<int> values = new();
            for (int i = 0; i < TRIALS; i++)
            {
                int result = d12.Roll();
                Assert.AreEqual(result, d12.LastRoll);
                Assert.LessOrEqual(result, 12);
                Assert.GreaterOrEqual(result, 1);
                values.Add(result);
            }

            // Check that each result was rolled
            Assert.Contains(1, values);
            Assert.Contains(2, values);
            Assert.Contains(3, values);
            Assert.Contains(4, values);
            Assert.Contains(5, values);
            Assert.Contains(6, values);
            Assert.Contains(7, values);
            Assert.Contains(8, values);
            Assert.Contains(9, values);
            Assert.Contains(10, values);
            Assert.Contains(11, values);
            Assert.Contains(12, values);
        }

        [Test, Timeout(5000)]
        public void TestIsParseable()
        {
            // We can parse a die of the format d{sides} where sides is an integer
            // 2 or greater. Casing and extra white space should be ignored. 

            Assert.True(Die.IsParseable("d2"));
            Assert.True(Die.IsParseable("D4"));
            Assert.True(Die.IsParseable("d6"));
            Assert.True(Die.IsParseable("  D8"));
            Assert.True(Die.IsParseable("d12  "));
            Assert.True(Die.IsParseable("  D20  "));
            Assert.True(Die.IsParseable("d17"));

            Assert.False(Die.IsParseable("d-6"));
            Assert.False(Die.IsParseable("d1"));
            Assert.False(Die.IsParseable("banana"));
            Assert.False(Die.IsParseable("d0"));
        }

        [Test, Timeout(5000)]
        public void TestSimpleParse()
        {
            Die d4 = Die.Parse("d4");
            Assert.AreEqual(4, d4.Sides);

            Die d6 = Die.Parse("d6");
            Assert.AreEqual(6, d6.Sides);

            Die d8 = Die.Parse("d8");
            Assert.AreEqual(8, d8.Sides);

            Die d12 = Die.Parse("d12");
            Assert.AreEqual(12, d12.Sides);

            Die d20 = Die.Parse("d20");
            Assert.AreEqual(20, d20.Sides);
        }

        [Test, Timeout(5000)]
        public void TestEdgeCaseParse()
        {
            // Test that we can parse values with extra white space at the
            // beginning and end
            Die d4 = Die.Parse("   d4");
            Assert.AreEqual(4, d4.Sides);

            Die d6 = Die.Parse("D6   ");
            Assert.AreEqual(6, d6.Sides);

            Die d8 = Die.Parse("    D8  ");
            Assert.AreEqual(8, d8.Sides);

            Die d12 = Die.Parse("   d12   ");
            Assert.AreEqual(12, d12.Sides);

            Die d20 = Die.Parse("d20  ");
            Assert.AreEqual(20, d20.Sides);
        }

        [Test, Timeout(5000)]
        public void TestParseFormatException()
        {
            // If the format is incorrect, we should throw an exception.
            Assert.Throws<System.FormatException>(() => Die.Parse("d-6"));
            Assert.Throws<System.FormatException>(() => Die.Parse("d1"));
            Assert.Throws<System.FormatException>(() => Die.Parse("d0"));
            Assert.Throws<System.FormatException>(() => Die.Parse("banana"));
        }
    }
}