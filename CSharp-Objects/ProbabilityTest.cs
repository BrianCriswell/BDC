using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDC.CSharp_Objects.Tests
{
    [TestClass]
    public class ProbabilityTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinomialProbabilityNLessThanOne()
        {
            Probability.BinomialProbability(0, 0, 0.0d);
            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinomialProbabilityXLessThanZero()
        {
            Probability.BinomialProbability(1, -1, 0.0d);
            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinomialProbabilityXGreaterThanN()
        {
            Probability.BinomialProbability(1, 2, 0.0d);
            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinomialProbabilityPLessThanZero()
        {
            Probability.BinomialProbability(1, 2, 0.0d);
            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinomialProbabilityPGreaterThanOne()
        {
            Probability.BinomialProbability(1, 2, 0.0d);
            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void BinomialProbabilityCycle()
        {
            Assert.AreEqual<double>(0.015625d, Probability.BinomialProbability(6, 0, .5));
            Assert.AreEqual<double>(0.09375d, Probability.BinomialProbability(6, 1, .5));
            Assert.AreEqual<double>(0.234375d, Probability.BinomialProbability(6, 2, .5));
            Assert.AreEqual<double>(0.3125d, Probability.BinomialProbability(6, 3, .5));
            Assert.AreEqual<double>(0.234375d, Probability.BinomialProbability(6, 4, .5));
            Assert.AreEqual<double>(0.09375d, Probability.BinomialProbability(6, 5, .5));
            Assert.AreEqual<double>(0.015625, Probability.BinomialProbability(6, 6, .5));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CombinationNLessThanOne()
        {
            Probability.Combination(0, 0);
            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CombinationKLessThanZero()
        {
            Probability.Combination(1, -1);
            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CombinationKGreaterThanN()
        {
            Probability.Combination(1, 2);
            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void CombinationCycle()
        {
            Assert.AreEqual<double>(1.0d, Probability.Combination(20, 0));
            Assert.AreEqual<double>(20.0d, Probability.Combination(20, 1));
            Assert.AreEqual<double>(190.0d, Probability.Combination(20, 2));
            Assert.AreEqual<double>(1140.0d, Probability.Combination(20, 3));
            Assert.AreEqual<double>(4845.0d, Probability.Combination(20, 4));
            Assert.AreEqual<double>(15504.0d, Probability.Combination(20, 5));
            Assert.AreEqual<double>(38760.0d, Probability.Combination(20, 6));
            Assert.AreEqual<double>(77520.0d, Probability.Combination(20, 7));
            Assert.AreEqual<double>(125970.0d, Probability.Combination(20, 8));
            Assert.AreEqual<double>(167960.0d, Probability.Combination(20, 9));
            Assert.AreEqual<double>(184756.0d, Probability.Combination(20, 10));
            Assert.AreEqual<double>(167960.0d, Probability.Combination(20, 11));
            Assert.AreEqual<double>(125970.0d, Probability.Combination(20, 12));
            Assert.AreEqual<double>(77520.0d, Probability.Combination(20, 13));
            Assert.AreEqual<double>(38760.0d, Probability.Combination(20, 14));
            Assert.AreEqual<double>(15504.0d, Probability.Combination(20, 15));
            Assert.AreEqual<double>(4845.0d, Probability.Combination(20, 16));
            Assert.AreEqual<double>(1140.0d, Probability.Combination(20, 17));
            Assert.AreEqual<double>(190.0d, Probability.Combination(20, 18));
            Assert.AreEqual<double>(20.0d, Probability.Combination(20, 19));
            Assert.AreEqual<double>(1.0d, Probability.Combination(20, 20));
        }
    }
}
