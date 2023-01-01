using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

namespace CaptainCoder.Data
{

    public class HistogramTest
    {
        public const int TRIALS = 10_000;

        [Test, Timeout(5000), Description("Test the Histogram.Max property")]
        public void TestMax()
        {
            List<int> elements = new () { 1, 2, 3, 4, 5, 6 };
            Histogram histogram = new (elements);
            Assert.AreEqual(6, histogram.Max);

            elements = new () { -1, -2, -3, -4, -5, -6 };
            histogram = new (elements);
            Assert.AreEqual(-1, histogram.Max);

            elements = new () { 5, 10, 15, 20 };
            histogram = new (elements);
            Assert.AreEqual(20, histogram.Max);
        }

        [Test, Timeout(5000), Description("Test the Histogram.Min property")]
        public void TestMin()
        {
            List<int> elements = new () { 1, 2, 3, 4, 5, 6 };
            Histogram histogram = new (elements);
            Assert.AreEqual(1, histogram.Min);

            elements = new () { -1, -2, -3, -4, -5, -6 };
            histogram = new (elements);
            Assert.AreEqual(-6, histogram.Min);

            elements = new () { 5, 10, 15, 20 };
            histogram = new (elements);
            Assert.AreEqual(5, histogram.Min);
        }

        [Test, Timeout(5000), Description("Test the Histogram.Count property")]
        public void TestCount()
        {
            List<int> elements = new () { 1, 1, 1, 2, 3, 4, 4 };
            Histogram histogram = new (elements);
            Assert.AreEqual(7, histogram.Count);

            elements = new () { -1, -2, -3, -4, -5, -6 };
            histogram = new (elements);
            Assert.AreEqual(6, histogram.Count);

            elements = new () { 5, 10, 15, 20 };
            histogram = new (elements);
            Assert.AreEqual(4, histogram.Count);
        }

        [Test, Timeout(5000), Description("Test the Histogram.Count property")]
        public void TestChanceOf()
        {
            List<int> elements = new () { 1, 1, 1, 2, 3, 3 };
            Histogram histogram = new (elements);
            Assert.AreEqual(0, histogram.ChanceOf(0), .01);
            Assert.AreEqual(3.0/6.0, histogram.ChanceOf(1), .01);
            Assert.AreEqual(1.0/6.0, histogram.ChanceOf(2), .01);
            Assert.AreEqual(2.0/6.0, histogram.ChanceOf(3), .01);
            Assert.AreEqual(0, histogram.ChanceOf(4), .01);
            Assert.AreEqual(0, histogram.ChanceOf(5), .01);
            Assert.AreEqual(0, histogram.ChanceOf(100), .01);

            elements = new () { 10, 10, 10, 5 };
            histogram = new (elements);
            Assert.AreEqual(0, histogram.ChanceOf(0), .01);
            Assert.AreEqual(0, histogram.ChanceOf(-50), .01);
            Assert.AreEqual(3.0/4.0, histogram.ChanceOf(10), .01);
            Assert.AreEqual(1.0/4.0, histogram.ChanceOf(5), .01);
        }

    }
}