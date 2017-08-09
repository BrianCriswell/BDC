using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDC.CSharp_Objects.Tests
{
    [TestClass]
    public class HeapTest
    {
        const int MAX_VALUE = 10000;

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "You cannot perform 'Peek' on an empty Heap.")]
        public void PeekEmpty()
        {
            MaxHeap<int> max = new MaxHeap<int>();
            max.Peek();
            Assert.Fail("Exception should have skipped this.");
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "You cannot perform 'Poll' on an empty Heap.")]
        public void PollEmpty()
        {
            MaxHeap<int> max = new MaxHeap<int>();
            max.Poll();
            Assert.Fail("Exception should have skipped this.");
        }

        [TestMethod]
        public void MinHeapKeepFirst()
        {
            MinHeap<int> min = new MinHeap<int>();
            for(int i = 1; i <= MAX_VALUE; i++)
            {
                min.Add(i);
                Assert.AreEqual<int>(1, min.Peek());
                Assert.AreEqual<int>(i, min.Count);
            }
        }

        [TestMethod]
        public void MinHeapCycle()
        {
            MinHeap<int> min = new MinHeap<int>();
            for (int i = MAX_VALUE; i >= 1; i--)
            {
                min.Add(i);
                Assert.AreEqual<int>(i, min.Peek());
                Assert.AreEqual<int>(MAX_VALUE + 1 - i, min.Count);
            }

            for(int i = 1; i <= MAX_VALUE; i++)
            {
                Assert.AreEqual<int>(i, min.Poll());
                Assert.AreEqual<int>(MAX_VALUE - i, min.Count);
            }
        }

        [TestMethod]
        public void MaxHeapKeepFirst()
        {
            MaxHeap<int> max = new MaxHeap<int>();
            for (int i = MAX_VALUE; i >= 1; i--)
            {
                max.Add(i);
                Assert.AreEqual<int>(MAX_VALUE, max.Peek());
                Assert.AreEqual<int>(MAX_VALUE + 1 - i, max.Count);
            }
        }

        [TestMethod]
        public void MaxHeapCycle()
        {
            MaxHeap<int> max = new MaxHeap<int>();
            for (int i = 1; i <= MAX_VALUE; i++)
            {
                max.Add(i);
                Assert.AreEqual<int>(i, max.Peek());
                Assert.AreEqual<int>(i, max.Count);
            }
            for (int i = MAX_VALUE; i >= 1; i--)
            {
                Assert.AreEqual<int>(i, max.Poll());
                Assert.AreEqual<int>(i-1, max.Count);
            }
        }
    }
}